using System;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class RefractinatorLaser : ModProjectile
{
	const float detectRaidus = 2500;
	const float rotationSpeed = 0.015f;
	const float speed = 7.5f;

	const int maxSplits = 3;

	public override void SetStaticDefaults()
	{
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
	}

	public override void SetDefaults()
	{
		Projectile.width = 6;
		Projectile.height = 6;
		Projectile.aiStyle = 0;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = 1;
		Projectile.timeLeft = 900;
		Projectile.light = 1.0f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 5;
		Projectile.usesIDStaticNPCImmunity = true;
		Projectile.idStaticNPCHitCooldown = 600;
	}

	public override void OnSpawn(IEntitySource source)
	{
		Projectile.velocity.Normalize();
		Projectile.velocity *= speed;
	}

	public override void AI()
	{
		Color color = getColor();
		Lighting.AddLight(Projectile.Center, color.R / 255, color.G / 255, color.B / 255);
		if (Projectile.owner != Main.myPlayer)
			return;
		NPC closestNPC = Targeting.FindClosestNPC(Projectile.position, detectRaidus);
		if (closestNPC != null)
		{
			float directionToNPC = (closestNPC.Center - Projectile.Center).ToRotation();
			float difference = directionToNPC - Projectile.velocity.ToRotation();
			if (difference > Math.PI)
				difference = -(float)Math.PI * 2 + difference;
			if (difference < -Math.PI)
				difference = (float)Math.PI * 2 - difference;
			float rotation = difference switch
			{
				> rotationSpeed => rotationSpeed,
				< -rotationSpeed => -rotationSpeed,
				_ => difference,
			};
			Projectile.velocity = Projectile.velocity.RotatedBy(rotation);
		}
		Projectile.rotation = Projectile.velocity.ToRotation();
		Projectile.netUpdate = true;
	}

	private void SpawnDust(int count)
	{
		for (int i = 0; i < count; ++i)
		{
			Dust dust = Dust.NewDustDirect(
				Projectile.position,
				Projectile.width,
				Projectile.height,
				DustID.RainbowTorch,
				newColor: getColor()
			);
			dust.noGravity = true;
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 3;
		SpawnDust(20);
		if (Projectile.ai[1]++ < maxSplits)
		{
			float difference = 360 / (float)Math.Pow(2, Projectile.ai[1] + 1);
			Projectile.NewProjectileDirect(
				Projectile.GetSource_FromThis(),
				Projectile.position,
				Projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-30, -30))),
				Projectile.type,
				Projectile.damage / 2,
				Projectile.knockBack,
				Projectile.owner,
				Projectile.ai[0] - difference,
				Projectile.ai[1]
			);
			Projectile.NewProjectileDirect(
				Projectile.GetSource_FromThis(),
				Projectile.position,
				Projectile.velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(30, 45))),
				Projectile.type,
				Projectile.damage / 2,
				Projectile.knockBack,
				Projectile.owner,
				Projectile.ai[0] + difference,
				Projectile.ai[1]
			);
		}

		Projectile.Kill();
	}

	public override bool OnTileCollide(Vector2 oldVelocity)
	{
		SpawnDust(5);
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

		return false;
	}

	private Color getColor() =>
		(Projectile.ai[1] == 0) ? Color.White : HsvToRgb(Projectile.ai[0], 1f, 1f);

	public override bool PreDraw(ref Color lightColor)
	{
		Texture2D texture = TextureAssets.Projectile[Type].Value;
		Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
		Vector2 origin = sourceRectangle.Size() / 2f;

		Color drawColor = getColor();
		drawColor.A = 0;
		for (int i = Projectile.oldPos.Length - 1; i >= 0; i -= 3)
		{
			drawColor.A += 51;
			Color curColor =
				drawColor * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
			Vector2 pos = Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f;
			SpriteEffects spriteEffects =
				(Projectile.oldSpriteDirection[i] == 1)
					? SpriteEffects.None
					: SpriteEffects.FlipHorizontally;
			Main.EntitySpriteDraw(
				texture,
				pos,
				sourceRectangle,
				curColor,
				Projectile.oldRot[i],
				origin,
				Projectile.scale,
				spriteEffects,
				0
			);
		}

		return false;
	}

	static Color HsvToRgb(float h, float s, float v)
	{
		// Keeps h from going over 360
		h = h - ((int)(h / 360) * 360);

		int i;
		float f,
			p,
			q,
			t;
		if (s == 0)
		{
			// achromatic (grey)
			return new Color(v, v, v);
		}
		h /= 60; // sector 0 to 5

		i = (int)h;
		f = h - i; // factorial part of h
		p = v * (1 - s);
		q = v * (1 - s * f);
		t = v * (1 - s * (1 - f));

		return i switch
		{
			0 => new Color(v, t, p),
			1 => new Color(q, v, p),
			2 => new Color(p, v, t),
			3 => new Color(p, q, v),
			4 => new Color(t, p, v),
			_ => new Color(v, p, q),
		};
	}
}
