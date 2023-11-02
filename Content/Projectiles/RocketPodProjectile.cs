using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Buffs;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;

namespace ChargerClass.Content.Projectiles
{
	public class RocketPodProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 120;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void AI(){
            Projectile.rotation = Projectile.velocity.RotatedBy(MathHelper.ToRadians(90)).ToRotation();
            Dust.NewDustPerfect(Projectile.Center, DustID.GreenTorch);
        }

        public override void Kill(int timeLeft) {
            Explosions.ExplodeCircle(Projectile.position, 100, Projectile.damage, ChargerDamageClass.Instance, Projectile, Projectile.knockBack);
        }
	}
}