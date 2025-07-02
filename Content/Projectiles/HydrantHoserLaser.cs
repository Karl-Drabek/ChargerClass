using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class HydrantHoserLaser : LaserProjectile
{
	public override void SafeSetDefaults()
	{
		Projectile.width = 76;
		Projectile.height = 26;
		centerWidth = 30;
		endsWidth = 22;
		Projectile.timeLeft = 60;
		InitialOffset = 60;
		TextureAsset = ModContent.Request<Texture2D>(
			"ChargerClass/Content/Projectiles/HydrantHoserLaser"
		);
	}

	public override void SpawnDusts(Player player)
	{
		Vector2 origin = player.Center;
		for (int i = InitialOffset; i < Distance; i += centerWidth)
		{
			if (Main.rand.NextBool(4))
			{
				Dust.NewDustDirect(
					origin + Projectile.velocity * i,
					endsWidth,
					endsWidth,
					DustID.Water
				);
			}
		}
		for (int i = 0; i < 3; i++)
		{
			Vector2 dustVel =
				Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90))
				* ((float)Main.rand.NextDouble() + 1f)
				* 2f;
			Dust.NewDustPerfect(origin + Projectile.velocity * Distance, DustID.Rain);
			Dust.NewDustPerfect(origin + Projectile.velocity * InitialOffset, DustID.Rain);
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 5;
		for (int i = 0; i < 10; i++)
		{
			Vector2 dustVel =
				Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90))
				* ((float)Main.rand.NextDouble() + 1f);
			Dust.NewDustDirect(
				target.Center - new Vector2(Projectile.width, Projectile.height) / 2,
				Projectile.width,
				Projectile.height,
				DustID.BlueFairy,
				dustVel.X,
				dustVel.Y
			);
		}
	}
}
