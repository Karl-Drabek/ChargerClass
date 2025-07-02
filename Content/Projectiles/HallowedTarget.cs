using System;
using ChargerClass.Common.Extensions;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Steamworks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class HallowedTarget : ModProjectile
{
	public static readonly float rotationSpeed = 5f;

	private int distanceSqauredForCollide;

	public override void SetDefaults()
	{
		Projectile.width = 32;
		Projectile.height = 32;
		Projectile.aiStyle = -1;
		Projectile.friendly = false;
		Projectile.hostile = false;
		Projectile.timeLeft = 1200;
		Projectile.alpha = 0;
		Projectile.light = 0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		distanceSqauredForCollide = Projectile.width * Projectile.width / 4;
	}

	private int direction;

	public override void OnSpawn(IEntitySource source)
	{
		direction = Main.rand.NextBool() ? 1 : -1;
	}

	public override void AI()
	{
		if (Main.rand.NextBool(1, 5))
		{
			Vector2 pos =
				Projectile.position
				+ new Vector2(Main.rand.Next(Projectile.height), Main.rand.Next(Projectile.width));
			Dust dust = Dust.NewDustPerfect(pos, DustID.GoldFlame);
			dust.scale = 0.7f;
		}

		Projectile.rotation += direction * MathHelper.ToRadians(rotationSpeed);
		Projectile.rotation = ClampAngle(Projectile.rotation);

		Projectile.velocity *= 0.98f;

		Lighting.AddLight(Projectile.position, new Vector3(255 / 255f, 205 / 255f, 0 / 255f));

		for (int k = 0; k < Main.maxProjectiles; k++)
		{
			Projectile target = Main.projectile[k];
			if (target.friendly)
			{
				float squareDistanceToProj = Vector2.DistanceSquared(
					target.Center,
					Projectile.Center
				);
				if (squareDistanceToProj <= distanceSqauredForCollide)
				{
					ChargerProjectile proj = target.GetGlobalProjectile<ChargerProjectile>();
					if (proj.HallowedEffect) {
						proj.HallowedEffect = false;
						proj.HallowedTargetEffect = true;
						target.velocity *= 2;
						target.damage *= 2;
						target.knockBack *= 2;
						target.CritChance *= 2;
						Projectile.Kill();
					}
				}
			}
		}
	}

	float ClampAngle(float angle)
	{
		angle %= MathHelper.Pi * 2;
		if (angle < 0)
			angle += MathHelper.Pi * 2;
		return angle;
	}
}
