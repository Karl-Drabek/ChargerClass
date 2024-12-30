using System;
using ChargerClass.Common.Configs;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts;

public abstract class ChargeWeaponHoldout : ModProjectile
{
	private const float AimResponsiveness = 1f;
	private const int SoundInterval = 20;
	public sealed override void SetDefaults()
	{
		SafeSetDefaults();
		Projectile.hide = true;
		Projectile.tileCollide = false;
		Projectile.friendly = false;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
	}

	private float Timer
	{
		get => Projectile.ai[0];
		set => Projectile.ai[0] = value;
	}
	private float Shots
	{
		get => Projectile.ai[1];
		set => Projectile.ai[1] = value;
	}
	public float Charge
	{
		get => Projectile.ai[2];
		set => Projectile.ai[2] = value;
	}
	public int GetChargeLevel(Player player) => (int)(Charge / GetChargeAmount(player));

	public float GetChargeAmount(Player player) =>
		player
			.GetModPlayer<ChargeModPlayer>()
			.GetChargeAmountModifier()
			.ApplyTo(((ChargedWeapon)player.HeldItem.ModItem).chargeAmount);

	public sealed override void AI()
	{
		Player player = Main.player[Projectile.owner];
		Item heldItem = player.HeldItem;
		ChargedWeapon chargedWeapon = (ChargedWeapon)heldItem.ModItem;
		ChargeModPlayer modPlayer = player.GetModPlayer<ChargeModPlayer>();
		Vector2 rrp = player.RotatedRelativePoint(player.MountedCenter, true);

		UpdateAnimation();
		PlaySounds();
		UpdatePlayerVisuals(player, rrp);

		if (Projectile.owner == Main.myPlayer) { //this stuff only works for the projectiles owner
			if (player.noItems || player.CCed)
				Projectile.Kill(); // Cursed (player.noItems), "Crowd Controlled" (the Frozen debuff).
			if (!player.channel) { //shooting
				if (--Timer <= 0) {
					if (--Shots < 0)
						Projectile.Kill();
					else
						Shoot(player, modPlayer, heldItem, rrp);
					Timer = heldItem.useTime;
				}
			}
			else { //charging
				if(!player.HasAmmo(heldItem)) Projectile.Kill();
				int maxCharge = modPlayer.GetMaxCharge();
				ChargedWeapon chargeWeapon = (ChargedWeapon)player.HeldItem.ModItem;
				if (chargeWeapon.bonusCharge > 0) {
					Charge += chargeWeapon.bonusCharge;
					chargeWeapon.bonusCharge = 0;
				}
				if (Charge < maxCharge)
					Charge += 300 / CombinedHooks.TotalUseTime(chargeWeapon.Item.useTime, player, player.HeldItem);
				else
					Charge = maxCharge;
				if (Charge > (chargedWeapon.chargeAmount / 4)){
					Shots = 1;
					Timer = 1;
				}else{
					Shots = 0;
					Timer = 1;
				}
			}
			UpdateAim(rrp, player.HeldItem.shootSpeed);
		}

		Projectile.timeLeft = 2; //keeps projectile alive
	}

	public void Shoot(Player player, ChargeModPlayer modPlayer, Item item, Vector2 pos)
	{
		int chargeLevel = GetChargeLevel(player);

		ChargedWeapon chargedWeapon = (ChargedWeapon)item.ModItem;

		float shootSpeed = item.shootSpeed + chargedWeapon.lastConsumedAmmo.shootSpeed;
		float chargeSpeed = shootSpeed * (float)Math.Clamp((float)Charge / ChargeModPlayer.DefaultCharge, 0.5, 1.0);
		Vector2 velocity = Vector2.Normalize(Main.MouseWorld - player.Center) * chargeSpeed;

		int damage = player.GetWeaponDamage(item) + chargedWeapon.lastConsumedAmmo.damage;
		float knockback = player.GetWeaponKnockback(item) + chargedWeapon.lastConsumedAmmo.knockBack;

		modPlayer.ModifyProjectileSpeed(ref velocity);
		modPlayer.ModifyChargeLevel(ref chargeLevel, player.GetWeaponCrit(item));
		EntitySource_ItemUse_WithAmmo source = new(player, item, item.useAmmo);

		if (chargedWeapon.lastConsumedAmmo.consumable && CanConsumeAmmo(item, player, chargeLevel))
		{
			player.ConsumeItem(chargedWeapon.lastConsumedAmmo.type);
		}

		ChargedShoot(
			player,
			modPlayer,
			source,
			pos,
			velocity,
			chargedWeapon.lastConsumedProjectileType,
			damage,
			knockback,
			item,
			chargeLevel,
			chargedWeapon
		);

		modPlayer.ShootInfo(item, (int)Charge);
	}

	private void ChargedShoot(Player player, ChargeModPlayer modPlayer, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, Item item, int chargeLevel, ChargedWeapon chargedWeapon)
	{
		Vector2 muzzleOffset = Vector2.Normalize(velocity);
		ModifyMuzzleOffset(ref muzzleOffset);
		if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			position += muzzleOffset;
		CombinedHooks.ModifyShootStats(player, item, ref position, ref velocity, ref type, ref damage, ref knockback);
		type = chargedWeapon.lastConsumedProjectileType;
		SafeModifyShootStats(player, item, ref position, ref velocity, ref type, ref damage, ref knockback, chargeLevel);
		if (CombinedHooks.Shoot(player, item, source, position, velocity, type, damage, knockback)
			&& Shoot(player, item, source, position, velocity, type, damage, knockback, chargeLevel)) {
			int owner = Projectile.owner;
			float ai0, ai1, ai2;
			ai0 = ai1 = ai2 = 0f;
			ModifyOtherStats(chargeLevel, player, ref owner, ref ai0, ref ai1, ref ai2);
			if (ChargerClassConfig.Instance.ShotInfoToggle)
				Main.NewText($"Shot Stats:\n    Charge Levels: {chargeLevel}\n    Speed: {(int)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y)}\n    Damage: {damage}\n    Knock Back: {(int)knockback}\n    Crit Chance: {player.GetWeaponCrit(item)}");
			Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, owner, ai0, ai1, ai2);
			CombinedPostProjectileEffects(proj, player, modPlayer, chargeLevel);
		}
	}

	public void CombinedPostProjectileEffects(Projectile proj, Player player, ChargeModPlayer modPlayer, int chargeLevel)
	{
		ChargerProjectile chargerProj = proj.GetGlobalProjectile<ChargerProjectile>();
		PostProjectileEffects(chargeLevel, proj, chargerProj, modPlayer);
		modPlayer.PostProjectileEffects(((ChargedWeapon)player.HeldItem.ModItem).blowWeapon, (int)Charge, chargeLevel, proj, chargerProj);
	}

	public virtual void PlaySounds()
	{
		if (Projectile.soundDelay <= 0)
		{
			Projectile.soundDelay = SoundInterval;
			SoundEngine.PlaySound(SoundID.Item15, Projectile.position);
		}
	}

	public virtual void UpdatePlayerVisuals(Player player, Vector2 playerHandPos)
	{
		// Place the Prism directly into the player's hand at all times.
		Projectile.Center = playerHandPos;
		// The beams emit from the tip of the Prism, not the side. As such, rotate the sprite by pi/2 (90 degrees).
		Projectile.rotation = Projectile.velocity.ToRotation(); // + MathHelper.PiOver2;
		Projectile.spriteDirection = Projectile.direction;

		player.ChangeDir(Projectile.direction);
		player.heldProj = Projectile.whoAmI;
		player.itemTime = 2;
		player.itemAnimation = 2;

		// If you do not multiply by Projectile.direction, the player's hand will point the wrong direction while facing left.
		player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
	}

	public virtual void UpdateAim(Vector2 source, float speed)
	{
		// Get the player's current aiming direction as a normalized vector.
		Vector2 aim = Vector2.Normalize(Main.MouseWorld - source);
		if (aim.HasNaNs())
			aim = -Vector2.UnitY;

		// Change a portion of the Prism's current velocity so that it points to the mouse. This gives smooth movement over time.
		aim = Vector2.Normalize(Vector2.Lerp(Vector2.Normalize(Projectile.velocity), aim, AimResponsiveness));
		aim *= speed;

		if (Projectile.velocity != aim)
		{
			Projectile.netUpdate = true;
			Projectile.velocity = aim;
		}
	}

	public sealed override bool PreDraw(ref Color lightColor)
	{
		DrawSprite(ref lightColor);
		return false;
		/*SpriteEffects effects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
		Texture2D texture = TextureAssets.Projectile[Type].Value;
		int frameHeight = texture.Height / Main.projFrames[Projectile.type];
		int spriteSheetOffset = frameHeight * Projectile.frame;
		Vector2 sheetInsertPosition = (Projectile.Center + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition).Floor();

		// The Prism is always at full brightness, regardless of the surrounding light. This is equivalent to it being its own glowmask.
		// It is drawn in a non-white color to distinguish it from the vanilla Last Prism.
		Color drawColor = Color.Green;
		Main.EntitySpriteDraw(texture, sheetInsertPosition, new Rectangle?(new Rectangle(0, spriteSheetOffset, texture.Width, frameHeight)), drawColor, Projectile.rotation, new Vector2(texture.Width / 2f, frameHeight / 2f), Projectile.scale, effects, 0f);
		return false;*/
	}
	public virtual void SafeSetDefaults() { }
	public virtual void UpdateAnimation() { }
	public virtual void DrawSprite(ref Color lightColor) { }
	public virtual void ModifyMuzzleOffset(ref Vector2 muzzleOffset) { }
	public virtual void ModifyOtherStats(int chargeLevel, Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2) { }
	public virtual void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer) { }
	public virtual void ModifyWeaponCrit(Player player, ref float crit) { }
	public virtual void ModifyWeaponDamage(Player player, ref StatModifier damage) { }
	public virtual void ModifyWeaponKnockback(Player player, ref StatModifier knockback) { }
	public virtual void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel) { }
	public virtual bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel) => true;
	public virtual bool CanConsumeAmmo(Item item, Player player, int chargeLevel) => true;
}