using ChargerClass.Content.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Old.Projectiles;

public class RefractinatorLaser : LaserProjectile
{
	public override void SafeSetDefaults()
	{
		Projectile.width = 26;
		Projectile.height = 28;
		Projectile.timeLeft = 60;
		InitialOffset = 70;
		collide = false;
		TextureAsset = ModContent.Request<Texture2D>(
			"ChargerClass/Content/Projectiles/RefractinatorLaser"
		);
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 5;
	}

	public override Color GetLaserColor(Color lightColor) => new(255, 255, 255, 175);

	public override void CastLights(Player player)
	{
		DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
		Utils.PlotTileLine(
			player.Center + InitialOffset * Projectile.velocity,
			player.Center + Projectile.velocity * Distance,
			26,
			DelegateMethods.CastLight
		);
	}
}
