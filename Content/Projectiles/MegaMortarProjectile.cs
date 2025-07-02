using ChargerClass.Common.Extensions;
using ChargerClass.Content.DamageClasses;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class MegaMortarProjectile : ModProjectile
{
	const float speed = 50f;

	public override void SetDefaults()
	{
		Projectile.width = 15;
		Projectile.height = 15;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 480;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;

		AIType = ProjectileID.WoodenArrowFriendly;
	}

	public override void OnSpawn(IEntitySource source)
	{
		Projectile.velocity = new(0, -speed);
	}

	public override void AI()
	{
		for (int i = 0; i < 9; ++i)
		{
			Dust.NewDustPerfect(Projectile.position, DustID.Smoke);
		}
		for (int i = 0; i < 3; ++i)
		{
			Dust.NewDustPerfect(Projectile.position, DustID.Torch);
		}
		if (++Projectile.ai[0] == 60)
		{
			//phase 2, at top
			Projectile.velocity = new(0, speed);
			Projectile.position.X = Projectile.ai[1];
		}
	}

	public override void OnKill(int timeLeft)
	{
		Explosions.ExplodeCircle(
			Projectile.position,
			25 * (int)(Projectile.ai[2] + 1),
			Projectile.damage,
			ChargerDamageClass.Instance,
			Projectile,
			knockback: Projectile.knockBack
		);
	}
}
