using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class BellowsAirProjectile : ModProjectile
{
	float rotation = 0;

	public override void SetDefaults()
	{
		Projectile.width = 15;
		Projectile.height = 15;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 3;
		Projectile.timeLeft = 60;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;
		Projectile.hide = true;

		AIType = ProjectileID.WoodenArrowFriendly;
	}

	public override void OnSpawn(IEntitySource source)
	{
		rotation = Main.rand.NextFloat(MathHelper.ToRadians(-5f), MathHelper.ToRadians(5f));
	}

	public override void AI()
	{
		Projectile.velocity *= 0.98f;
		Projectile.alpha += 5;
		Projectile.rotation += rotation;
		if (Main.rand.NextBool(2))
			Dust.NewDustDirect(
				Projectile.position,
				Projectile.height,
				Projectile.width,
				DustID.Smoke,
				Scale: Main.rand.NextFloat(1, 2)
			);
	}

	public override void OnKill(int timeLeft)
	{
		Dust.NewDustDirect(Projectile.position, 0, 0, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
		Gore.NewGoreDirect(
			new EntitySource_Parent(Projectile),
			Projectile.position,
			default,
			Main.rand.Next(61, 64)
		);
	}
}
