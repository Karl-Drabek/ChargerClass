using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class SuperSlimerProjectile : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 2;
		Projectile.height = 2;
		Projectile.aiStyle = 60;
		Projectile.alpha = byte.MaxValue;
		Projectile.penetrate = -1;
		Projectile.extraUpdates = 4;
		Projectile.ignoreWater = true;
	}

	public override void OnSpawn(IEntitySource source)
	{
		Projectile.ai[1] = Main.rand.Next(10, 31) * 0.1f;
	}

	public override void AI()
	{
		if (Main.rand.NextBool(15))
			Dust.NewDustPerfect(
				Projectile.position,
				DustID.Wet,
				Projectile.velocity / 2,
				0,
				new(0, 255, 0),
				Scale: Main.rand.NextFloat(0.5f, 1f)
			);
		for (int i = 0; i < 10; ++i)
		{
			Dust dust = Dust.NewDustPerfect(
				Projectile.position
					+ new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f)),
				172,
				new(0, 0),
				0,
				new(0, 255, 0),
				Scale: Main.rand.NextFloat(0.5f, 1f)
			);
			dust.noGravity = true;
		}
	}
	
	public override void OnKill(int timeLeft)
	{
		for (int i = 0; i < 30; ++i)
		{
			Dust dust = Dust.NewDustDirect(
				Projectile.position,
				Projectile.width,
				Projectile.height,
				DustID.Wet,
				Projectile.velocity.X / 4,
				Projectile.velocity.Y / 4,
				0,
				new(0, 255, 0),
				Scale: Main.rand.NextFloat(0.5f, 1f)
			);
			dust.noGravity = true;
		}
		for (int i = 0; i < 15; ++i)
		{
			Dust dust = Dust.NewDustDirect(
				Projectile.position,
				Projectile.width,
				Projectile.height,
				DustID.DungeonWater,
				Projectile.velocity.X / 4,
				Projectile.velocity.Y / 4,
				0,
				new(0, 255, 0),
				Scale: Main.rand.NextFloat(0.5f, 1f)
			);
			dust.noGravity = true;
		}
	}
}
