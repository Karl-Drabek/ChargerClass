using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Buffs;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Projectiles;

public class BolaProjectile : ModProjectile
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
            Projectile.timeLeft = 120;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hitInfo, int damage){
            if(hitInfo.Crit)target.AddBuff(ModContent.BuffType<Bound>(), (int)Projectile.ai[2]);
        
        }

        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
}