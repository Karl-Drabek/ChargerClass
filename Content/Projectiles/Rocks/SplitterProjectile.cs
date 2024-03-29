using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Projectiles.Rocks;

public class SplitterProjectile : ModProjectile
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
            Projectile.timeLeft = 20;
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

        public override void AI(){
            if(Projectile.timeLeft <= 1){
                for(int i = 0; i < 2; i++){ //after the time runs out the projectile makes two smaller projectiles.
                     Projectile.NewProjectile(new EntitySource_Parent(Projectile),
                        Projectile.Center, 
                        Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(40)), 
                        ModContent.ProjectileType<SplitterBrokenProjectile>(), 
                        (int)(Projectile.damage * 0.75f), 
                        Projectile.knockBack, 
                        Projectile.owner);
                }
                Projectile.Kill();
            }
        }

        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
}