using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;

namespace ChargerClass.Content.Projectiles.Rocks
{
	public class ExplodingRockProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 1;
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
		public override void Kill(int timeLeft) {
            Explosions.ExplodeCircle(Projectile.position, (int)(Projectile.ai[2] * 20), (int)(Projectile.ai[2] * 3), ChargerDamageClass.Instance, Projectile, knockback: (int)(Projectile.ai[2] * 0.1f));
        }
	}
}