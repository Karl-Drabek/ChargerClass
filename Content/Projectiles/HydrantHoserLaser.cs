using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Projectiles;

public class HydrantHoserLaser : LaserProjectile
{
	public override void SafeSetDefaults()
	{
		Projectile.width = 26;
		Projectile.height = 28;
		Projectile.timeLeft = 60;
		InitialOffset = 70;
		TextureAsset = ModContent.Request<Texture2D>("ChargerClass/Content/Projectiles/HydrantHoserLaser");
	}

	public override void SpawnDusts(Player player)
	{
		Vector2 origin = player.Center - new Vector2(Projectile.width, Projectile.height) / 2;
		for (int i = InitialOffset; i < Distance; i += Spacing) {
			if (Main.rand.NextBool(4)) {
				Dust.NewDustDirect(origin + Projectile.velocity * i, Projectile.width, Projectile.height, DustID.Water);
			}
		}
		for (int i = 0; i < 3; i++) {
			Vector2 dustVel = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90)) * ((float)Main.rand.NextDouble() + 1f) * 2f;
			Dust.NewDustDirect(origin + Projectile.velocity * (Distance + Spacing), Projectile.width, Projectile.height, 154, dustVel.X, dustVel.Y);
			Dust.NewDustDirect(origin + Projectile.velocity * (InitialOffset + Spacing), Projectile.width, Projectile.height, 154, dustVel.X, dustVel.Y);
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 5;
		for (int i = 0; i < 10; i++) {
			Vector2 dustVel = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90)) * ((float)Main.rand.NextDouble() + 1f);
			Dust.NewDustDirect(target.Center - new Vector2(Projectile.width, Projectile.height) / 2, Projectile.width, Projectile.height, DustID.BlueFairy, dustVel.X, dustVel.Y);
		}
	}
}