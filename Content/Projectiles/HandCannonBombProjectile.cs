using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;

namespace ChargerClass.Content.Projectiles
{
	public class HandCannonBombProjectile : ModProjectile
	{

		public override void SetDefaults()
		{
            Projectile.width = 15;
            Projectile.height = 15;
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

        public override void Kill(int timeLeft) {
            Explosions.ExplodeCircle(Projectile.position, 60, Projectile.damage * 2, ChargerDamageClass.Instance, Projectile, knockback: 3f);
        }
	}
}