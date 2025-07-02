using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using Terraria.DataStructures;
using System;

namespace ChargerClass.Content.Projectiles;

public class PixieDust : ModProjectile
{
	float rotation = 0;
	public override void SetDefaults()
	{
		Projectile.width = 15;
		Projectile.height = 15;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 10;
		Projectile.timeLeft = 255;
		Projectile.alpha = 0;
		Projectile.light = 1.0f;
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
		Projectile.velocity.Y = 5f;
		Projectile.alpha += 1;
		Projectile.rotation += rotation;
		if (Main.rand.NextBool(6)){
			Dust dust = Dust.NewDustDirect(
				Projectile.position,
				Projectile.height,
				Projectile.width,
				57,
				Projectile.velocity.X / 4,
				Projectile.velocity.Y / 4,
				Scale: Main.rand.NextFloat(1, 2)
			);
			dust.scale = Main.rand.NextFloat(0.8f, 1f);
			//dust.noGravity = true;
		}
	}
}