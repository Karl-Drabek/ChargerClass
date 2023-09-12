using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles
{
	public class IceSpikeProjectile : ModProjectile
	{

		public override void SetDefaults()
		{
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override Color? GetAlpha(Color lightColor) {
            return new Color(155, 155, 155, 0) * Projectile.Opacity;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hitInfo, int damage){
            target.AddBuff(BuffID.Frostburn, 180);
		}

        public override void Kill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
	}
}