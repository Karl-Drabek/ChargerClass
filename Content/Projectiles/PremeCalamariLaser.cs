using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class PremeCalamariLaser : LaserProjectile
{
	public override void SafeSetDefaults() {
		Projectile.width = 26;
		Projectile.height = 28;
		Projectile.timeLeft = 60;
		InitialOffset = 70;
		TextureAsset = ModContent.Request<Texture2D>("ChargerClass/Content/Projectiles/PremeCalamariLaser");
	}

	public override void SpawnDusts(Player player){
		Vector2 origin = player.Center - new Vector2(Projectile.width, Projectile.height) / 2;
		for (int i = InitialOffset; i < Distance; i += Spacing){
			if(Main.rand.NextBool(30)){
				Dust dust = Dust.NewDustDirect(origin + Projectile.velocity * i, Projectile.width, Projectile.height, DustID.Granite);
				dust.scale = 0.75f;
			}
		}
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
		target.immune[Projectile.owner] = 5;
	}
}