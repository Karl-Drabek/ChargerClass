using ChargerClass.Common.Configs;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Rocks;

public class SplitterProjectile : ModProjectile
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
		Projectile.timeLeft = 20;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.scale = 0.75f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;
	}

	public override void AI()
	{
		Projectile.rotation += Projectile.ai[1];
		Projectile.rotation = ClampAngle(Projectile.rotation);
		if (Projectile.ai[0]++ > 10)
			Projectile.velocity.Y += 0.14f;
		if (Projectile.timeLeft <= 1)
		{
			for (int i = 0; i < 2; i++)
			{ //after the time runs out the projectile makes two smaller projectiles.
				Projectile.NewProjectile(
					new EntitySource_Parent(Projectile),
					Projectile.Center,
					Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(40)),
					ModContent.ProjectileType<SplitterBrokenProjectile>(),
					(int)(Projectile.damage * 0.75f),
					Projectile.knockBack,
					Projectile.owner
				);
			}
			for (int i = 0; i < 10; ++i)
			{
				Dust.NewDustDirect(
					Projectile.position,
					Projectile.width,
					Projectile.height,
					DustID.Stone,
					Projectile.velocity.X,
					Projectile.velocity.Y,
					Scale: 0.7f
				);
			}
			Projectile.Kill();
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
