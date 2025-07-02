using ChargerClass.Common.Configs;
using ChargerClass.Content.Buffs;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class SnailProjectile : ModProjectile
{
	private NPC _target;
	private int _damage;
	private Vector2 _offset;

	private static Asset<Texture2D> snail_reg,
		snail_glow,
		snail_magma;

	public override void SetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 6;
	}

	public override void Load()
	{
		Main.instance.LoadNPC(NPCID.Snail);
		Main.instance.LoadNPC(NPCID.GlowingSnail);
		Main.instance.LoadNPC(NPCID.MagmaSnail);
		snail_reg = TextureAssets.Npc[NPCID.Snail];
		snail_glow = TextureAssets.Npc[NPCID.GlowingSnail];
		snail_magma = TextureAssets.Npc[NPCID.MagmaSnail];
	}

	public override void SetDefaults()
	{
		Projectile.width = 30;
		Projectile.height = 20;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.scale = 0.75f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;
	}

	/*
	public override void ModifyDamageHitbox(ref Rectangle hitbox)
	{
		if (Projectile.ai[2] != 0)
		{
			hitbox.Width = 42;
			hitbox.Height = 24;
		}
	}
	*/

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		Projectile.position -= Projectile.velocity;
		_target = target;
		_offset = Projectile.Center - _target.Center;
		_damage = hit.Damage / (Projectile.ai[2] == 0 ? 10 : 6);
		Projectile.tileCollide = false;
		Projectile.netUpdate = true;
	}

	public override void OnSpawn(IEntitySource source)
	{
		Projectile.ai[1] = Main.rand.NextFloat(-MathHelper.ToRadians(10), MathHelper.ToRadians(10));
		Projectile.light = Projectile.ai[2] == 0 ? 0 : 0.5f;
		Projectile.netUpdate = true;
	}

	float ClampAngle(float angle)
	{
		angle %= MathHelper.Pi * 2;
		if (angle < 0)
			angle += MathHelper.Pi * 2;
		return angle;
	}

	public override bool? CanHitNPC(NPC target) => _target is null; //don't hit an NPC after locking on

	public override void AI()
	{
		if (_target is null)
		{
			Projectile.rotation += Projectile.ai[1];
			Projectile.rotation = ClampAngle(Projectile.rotation);
			if (Projectile.ai[0]++ > 10)
			{
				Projectile.velocity.Y += 0.14f;
			}
		}
		else if (!_target.active)
		{ //destroy the projectile if the target died.
			Projectile.Kill();
			return;
		}
		else
		{
			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 0;
				}
			}
			if (Projectile.timeLeft % 20 == 0)
			{
				_target.SimpleStrikeNPC(_damage, _offset.X > 0 ? 0 : 1);
				switch (Projectile.ai[2])
				{
					case 2:
						_target.AddBuff(BuffID.OnFire3, 60);
						break;
					case 1:
						_target.AddBuff(BuffID.Venom, 60);
						break;
					default:
						_target.AddBuff(BuffID.Slimed, 60);
						break;
				}
				_target.AddBuff(ModContent.BuffType<SuperSlimed>(), 60);
				for (int i = 0; i < 3; ++i)
				{
					Dust.NewDustPerfect(Projectile.position, DustID.Blood);
				}
			}
			Projectile.Center = _target.Center + _offset;
		}
		if (Main.rand.NextBool(5))
			Dust.NewDustDirect(
				Projectile.position,
				Projectile.width,
				Projectile.height,
				Projectile.ai[2] switch
				{
					0 => DustID.Snail,
					1 => DustID.GlowingSnail,
					2 => DustID.Torch,
					_ => DustID.Dirt,
				},
				Scale: 0.85f
			);
	}

	public override void OnKill(int timeLeft)
	{
		Collision.HitTiles(
			Projectile.position + Projectile.velocity,
			Projectile.velocity,
			Projectile.width,
			Projectile.height
		);
		if (ChargerClassConfig.Instance.AudioToggle)
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
	}

	public override bool PreDraw(ref Color lightColor)
	{
		SpriteEffects spriteEffects = SpriteEffects.None;
		if (Projectile.spriteDirection == -1)
			spriteEffects = SpriteEffects.FlipHorizontally;

		Texture2D texture = Projectile.ai[2] switch
		{
			0 => snail_reg.Value,
			1 => snail_glow.Value,
			2 => snail_magma.Value,
			_ => null,
		};

		int frameHeight = texture.Height / Main.projFrames[Type];
		int startY = frameHeight * Projectile.frame;

		Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

		Vector2 origin = sourceRectangle.Size() / 2f;

		// If image isn't centered or symmetrical you can specify origin of the sprite
		// (0,0) for the upper-left corner
		//float offsetX = texture.Width / 2;
		//origin.X = Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX;

		// If sprite is vertical
		//float offsetY = 20f;
		//origin.Y = (Projectile.spriteDirection == 1 ? sourceRectangle.Height - offsetY : offsetY);


		Color drawColor = Projectile.GetAlpha(lightColor);

		Main.EntitySpriteDraw(
			texture,
			Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
			sourceRectangle,
			drawColor,
			Projectile.rotation,
			origin,
			Projectile.scale,
			spriteEffects,
			0
		);
		return false;
	}
}
