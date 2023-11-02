using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;

namespace ChargerClass.Content.Projectiles
{
	public class HolyCrossProjectile : ModProjectile
	{

        public static readonly float rotationSpeed = 7.5f;

		public override void SetDefaults()
		{
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 360;
            Projectile.alpha = 0;
            Projectile.light = 1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 0;

            
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        private bool shooting = false;
        private NPC target;
        private bool direction;

        private Vector2 targetPos;

        public override void AI(){
            if(Main.rand.NextBool(1,3)){
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
                dust.noGravity = true;
                dust.scale = 0.7f;
            }
            if(!shooting){
                Projectile.rotation += MathHelper.ToRadians(rotationSpeed);
                Projectile.rotation = ClampAngle(Projectile.rotation);
                Projectile.velocity *= 0.975f;
                if(++Projectile.ai[0] >= 40){
                    if(target is null) target = Targeting.FindClosestNPC(Projectile.position, 1000);
                    if(target is null) return;
                    Vector2 toNPC = target.position - Projectile.position;
                    if(toNPC.Length() > 1000){
                        target = null;
                        return;
                    }
                    if(Math.Abs(Projectile.rotation - ClampAngle(toNPC.ToRotation())) < MathHelper.ToRadians(rotationSpeed) * 2){;
                        shooting = true;
                        Projectile.velocity = Vector2.Normalize(toNPC) * 40;
                        Projectile.rotation = Projectile.velocity.ToRotation();
                        Projectile.ai[0] = 0;
                        targetPos = target.position;
                        direction = targetPos.X - Projectile.position.X < 0;
                        target = null;
                    }
                }
            }else{
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SolarFlare);
                dust.noGravity = true;
                dust.scale = 0.7f;
                if(targetPos.X - Projectile.position.X < 0 != direction){
                    Projectile.velocity *= 0.9f;
                    if(++Projectile.ai[0] >= 20){
                        shooting = false;
                        Projectile.ai[0] = 0;
                    }
                }
            }
        }

        float ClampAngle(float angle){
            angle %=  MathHelper.Pi * 2;
            if(angle < 0) angle += MathHelper.Pi * 2;
            return angle;
        }

        public override void Kill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
	}
}