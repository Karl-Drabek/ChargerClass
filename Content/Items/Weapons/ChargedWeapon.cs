using System.Collections.Generic;
using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public abstract class ChargedWeapon : ModItem
{
	public int bonusCharge = 0;
	public bool repeatShot;
	public int noAmmoProjectile = 0;
	public int ticsBetweenShots = 1;
	public int chargeAmount;
	public bool blowWeapon;
	public bool shootSelf = false;
	public bool consumeNext = false;
	public int shootID;
	public int lastConsumedProjectileType;
	public Item lastConsumedAmmo;
	public bool ignoreAmmo = false;
	public int innacuracy = 0;

	public sealed override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
		SafeSetStaticDefualts();
	}

	public float GetChargeAmount(Player player) =>
		player
			.GetModPlayer<ChargeModPlayer>()
			.GetChargeAmountModifier()
			.ApplyTo(((ChargedWeapon)player.HeldItem.ModItem).chargeAmount);

	public sealed override void ModifyShootStats(Player player, ref Vector2 position,
		ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
	{
		lastConsumedProjectileType = type;
		type = Item.shoot;
	}

	public sealed override bool CanConsumeAmmo(Item ammo, Player player)
	{
		lastConsumedAmmo = ammo;
		return false;
	}

	public override bool ConsumeItem(Player player)
	{
		if(shootSelf){
			if(consumeNext){
				consumeNext = false;
				return true;
			}return false;
		}else return true;
	}

	public virtual void SafeSetStaticDefualts() { }

	public sealed override void SetDefaults()
	{
		blowWeapon = false;
		chargeAmount = 10;
		Item.useAnimation = 10;
		Item.useTime = 10;
		repeatShot = false;
		innacuracy = 0;
		SafeSetDefaults(); //allows members to set defualts here
		Item.noMelee = true;
		Item.channel = true;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.DamageType = ChargerDamageClass.Instance;
	}

	public virtual void SafeSetDefaults() { }

	public sealed override void ModifyWeaponCrit(Player player, ref float crit)
	{
		if (player.heldProj == -1)
			return;
		ChargeWeaponHoldout weapon = (ChargeWeaponHoldout)Main.projectile[player.heldProj].ModProjectile;
		if (weapon == null)
			return;
		float percentCharged = weapon.Charge / ChargeModPlayer.DefaultCharge;
		crit += 10 * percentCharged;
		weapon.ModifyWeaponCrit(player, ref crit);
	}

	public sealed override void ModifyWeaponDamage(Player player, ref StatModifier damage)
	{
		if (player.heldProj == -1)
			return;
		ChargeWeaponHoldout weapon = (ChargeWeaponHoldout)Main.projectile[player.heldProj].ModProjectile;
		if (weapon == null)
			return;
		float percentCharged = weapon.Charge / ChargeModPlayer.DefaultCharge;
		damage *= percentCharged;
		weapon.ModifyWeaponDamage(player, ref damage);
	}

	public sealed override void ModifyWeaponKnockback(Player player, ref StatModifier knockBack)
	{
		if (player.heldProj == -1)
			return;
		ChargeWeaponHoldout weapon = (ChargeWeaponHoldout)Main.projectile[player.heldProj].ModProjectile;
		if (weapon == null)
			return;
		float percentCharged = weapon.Charge / ChargeModPlayer.DefaultCharge;
		knockBack *= percentCharged;
		weapon.ModifyWeaponKnockback(player, ref knockBack);
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		for (int i = 0; i < tooltips.Count; i++)
		{
			if (blowWeapon && tooltips[i].Name == "Damage") {
				tooltips.Insert(i + 1, new TooltipLine(Mod, "BlowWeapon", $"Blowing weapon"));
			}
			if (tooltips[i].Name == "Speed") {
				tooltips.Insert(i, new TooltipLine(Mod, "ChargeValue", $"{ChargeAmountDescription(chargeAmount)} charge levels"));
				return;
			}
		}
	}

	public string ChargeAmountDescription(int chargeAmount) => chargeAmount switch {
			< 150 => "Tiny",
			< 250 => "Small",
			< 350 => "Normal",
			< 500 => "Large",
			< 650 => "Huge",
			_ => "Ginormous",
		};
}
