using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class RailgunLaser : LaserProjectile
{
	public override void SafeSetDefaults()
	{
		Projectile.width = 26;
		Projectile.height = 28;
		centerWidth = 30;
		endsWidth = 22;
		Projectile.timeLeft = 60;
		InitialOffset = 70;
		collide = false;
		TextureAsset = ModContent.Request<Texture2D>(
			"ChargerClass/Content/Projectiles/RailgunLaser"
		);
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 5;
	}

	public override Color GetLaserColor(Color lightColor) => Color.White;

	public override void CastLights(Player player)
	{
		DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
		Utils.PlotTileLine(player.Center + InitialOffset * Projectile.velocity, player.Center + Projectile.velocity * Distance, 26, DelegateMethods.CastLight);
	}
}