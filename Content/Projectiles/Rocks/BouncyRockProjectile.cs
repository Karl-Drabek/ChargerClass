using System;
using ChargerClass.Common.Configs;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Rocks;

public class BouncyRockProjectile : ModProjectile
{
	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 600;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;
		Projectile.scale = 0.75f;
	}

	private int bounces = 5;

	public override void AI()
	{
		Projectile.rotation += Projectile.ai[1];
		Projectile.rotation = ClampAngle(Projectile.rotation);
		if (Projectile.ai[0]++ > 10)
			Projectile.velocity.Y += 0.14f;
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

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		bounces--;

		for (int i = 0; i < 15; ++i)
		{
			Dust dust = Dust.NewDustDirect(
				Projectile.position,
				Projectile.width,
				Projectile.height,
				DustID.TintableDust,
				newColor: new(0, 255, 244)
			);
			dust.scale = Main.rand.NextFloat(0.6f, 0.8f);
		}
		Collision.HitTiles(
			Projectile.position,
			Projectile.velocity,
			Projectile.width,
			Projectile.height
		);
		if (ChargerClassConfig.Instance.AudioToggle)
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);


		if (bounces <= 0)
			Projectile.Kill();
		else
		{
			// If the projectile hits the left or right side of the tile, reverse the X velocity
			if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
			{
				Projectile.velocity.X = -oldVelocity.X;
			}

			// If the projectile hits the top or bottom side of the tile, reverse the Y velocity
			if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
			{
				Projectile.velocity.Y = -oldVelocity.Y;
			}
		}

		return false;
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
