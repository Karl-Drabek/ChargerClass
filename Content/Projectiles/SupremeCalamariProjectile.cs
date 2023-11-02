using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
namespace ChargerClass.Content.Projectiles;

public class SupremeCalamariProjectile : ModProjectile
{

	public override void SetDefaults()
	{
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
            Projectile.light = 1.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            
            AIType = ProjectileID.WoodenArrowFriendly;
        }
}