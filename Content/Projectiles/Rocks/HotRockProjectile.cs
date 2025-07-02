using ChargerClass.Common.Configs;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Rocks;

public class HotRockProjectile : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 8;
		Projectile.height = 8;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 0;
		Projectile.light = 0.25f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;
		Projectile.scale = 0.75f;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(BuffID.OnFire, 30);
	}

	public override void AI()
	{
		Projectile.rotation += Projectile.ai[1];
		Projectile.rotation = ClampAngle(Projectile.rotation);
		if (Projectile.ai[0]++ > 10)
			Projectile.velocity.Y += 0.14f;
		if (Main.rand.NextBool(15))
			Dust.NewDustDirect(
				Projectile.position,
				Projectile.height,
				Projectile.width,
				DustID.Torch
			);
		if (Main.rand.NextBool(15)){
			Dust dust = Dust.NewDustDirect(
				Projectile.position,
				Projectile.height,
				Projectile.width,
				DustID.Smoke
			);
			dust.noGravity = true;
			dust.scale = Main.rand.NextFloat(0.6f, 0.8f);
		}
	}

	public override void OnSpawn(IEntitySource source)
	{
		Projectile.ai[1] = Main.rand.NextFloat(-MathHelper.ToRadians(10), MathHelper.ToRadians(10));
	}

	float ClampAngle(float angle)
	{
		angle %= MathHelper.Pi * 2;
		if (angle < 0)
			angle += MathHelper.Pi * 2;
		return angle;
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
}
