using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles
{
	public class RailgunLaser : LaserProjectile
	{
		public override void SafeSetDefaults() {
			Projectile.width = 26;
			Projectile.height = 28;
			Projectile.timeLeft = 60;
			InitialOffset = 70;
			TextureAsset = ModContent.Request<Texture2D>("ChargerClass/Content/Projectiles/RailgunLaser");
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			target.immune[Projectile.owner] = 5;
		}
	}
}