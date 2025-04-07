using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;

namespace ChargerClass.Content.Projectiles;

public class RocketBalloonProjectile : ModProjectile
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
		Projectile.timeLeft = 20;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;

		AIType = ProjectileID.WoodenArrowFriendly;
	}

	public override void AI(){
		float bias = Projectile.ai[0] * -1 / 5;
		Projectile.ai[0] += Main.rand.NextFloat(-0.05f + bias, 0.05f + bias);
		Projectile.velocity = Projectile.velocity.RotatedBy(Projectile.ai[0]);
	}

	public override void OnKill(int timeLeft)
	{
		Explosions.ExplodeCircle(Projectile.position, timeLeft, timeLeft * 5, ChargerDamageClass.Instance, Projectile, knockback: timeLeft);
	}
}