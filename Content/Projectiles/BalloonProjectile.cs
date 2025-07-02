using ChargerClass.Common.Configs;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.DamageClasses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class BalloonProjectile : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 15;
		Projectile.height = 15;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 15;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;

		AIType = ProjectileID.WoodenArrowFriendly;
	}

	public override void AI()
	{
		float bias = Projectile.ai[0] * -1 / 5;
		Projectile.ai[0] += Main.rand.NextFloat(-0.05f + bias, 0.05f + bias);
		Projectile.velocity = Projectile.velocity.RotatedBy(Projectile.ai[0]);
	}

	public override void OnKill(int timeLeft)
	{
		if (timeLeft > 15)
		{
			Explosions.ExplodeCircle(
				Projectile.position,
				(timeLeft - 15) / 2,
				(timeLeft - 15) / 2,
				ChargerDamageClass.Instance,
				Projectile,
				knockback: (timeLeft - 15) / 3,
				redParticles: false
			);
		}
		else
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
}
