using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class RayOfBloonLaser : LaserProjectile
{
	public override void SafeSetDefaults() {
		Projectile.width = 26;
		Projectile.height = 28;
		Projectile.timeLeft = 60;
		InitialOffset = 50;
		TotalFrames = 2;
		TicsPerFrame = 4;
		TextureAsset = ModContent.Request<Texture2D>("ChargerClass/Content/Projectiles/RayOfBloonLaser");
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
		target.immune[Projectile.owner] = 5;
		for(int i = 0; i < 10; i++){
			Vector2 dustVel = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90)) * ((float)Main.rand.NextDouble() + 1f);
			Dust dust = Dust.NewDustDirect(target.Center - new Vector2(Projectile.width, Projectile.height) / 2, Projectile.width, Projectile.height, DustID.SolarFlare, dustVel.X, dustVel.Y);
			dust.noGravity = true;
		}
	}

	public override Color GetLaserColor(Color lightColor) => Color.White;

	public override void SpawnDusts(Player player){
		Vector2 origin = player.Center - new Vector2(Projectile.width, Projectile.height) / 2;

		Dust dust;
		for (int i = InitialOffset; i < Distance; i += Spacing){
			if(Main.rand.NextBool(10)){
				dust = Dust.NewDustDirect(origin + Projectile.velocity * i, Projectile.width, Projectile.height, DustID.YellowTorch);
				dust.noGravity = true;
			}
		}
		for(int i = 0; i < 3; i++){
			Vector2 dustVel = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90)) * ((float)Main.rand.NextDouble() + 1f) * 2f;
			dust = Dust.NewDustDirect(origin + Projectile.velocity * (Distance + Spacing), Projectile.width, Projectile.height, DustID.SolarFlare, dustVel.X, dustVel.Y);
			dust.noGravity = true;
			dust = Dust.NewDustDirect(origin + Projectile.velocity * (InitialOffset + Spacing), Projectile.width, Projectile.height, DustID.SolarFlare, dustVel.X, dustVel.Y);
			dust.noGravity = true;
			dust.scale = 0.7f;
			dust = Dust.NewDustDirect(origin + InitialOffset * Projectile.velocity, Projectile.width, Projectile.height, DustID.Smoke);
			dust.noGravity = true;
			dust.fadeIn = 0f;
		}
	}

	public override void CastLights(Player player) {
		DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
		Utils.PlotTileLine(player.Center + InitialOffset * Projectile.velocity, player.Center + Projectile.velocity * Distance , 26, DelegateMethods.CastLight);
	}
}