using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Ammo.Darts;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles
{
	public class BombBayProjectile : ModProjectile
	{
        DartComponent Payload;
        float rotation = 0;

		public override void SetDefaults()
		{
            Projectile.width = 15;
            Projectile.height = 15;
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

        public override void OnSpawn(IEntitySource source){
            rotation = Main.rand.NextFloat(MathHelper.ToRadians(-5f), MathHelper.ToRadians(5f));
            Payload = (DartComponent)ItemLoader.GetItem((int)Projectile.ai[0]);
        }

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone){
            Payload.OnHitNPC(Projectile, target, hit, damageDone, 1);
        }

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers){
            modifiers.SetMaxDamage(0);
        }
		public override void AI(){
            Projectile.velocity.Y += 0.35f;
            Projectile.velocity.X *= 0.98f;
            Projectile.rotation += rotation;
        }

        
		public override void OnKill(int timeLeft){
            Payload.OnKill(Projectile, timeLeft);
            int distanceSquared = 1600;
            for (int k = 0; k < Main.maxNPCs; k++) {
                NPC target = Main.npc[k];
                if(target.friendly || !target.active || target.dontTakeDamage) continue;
                if (Vector2.DistanceSquared(target.Center, Projectile.position) < distanceSquared){
                    int hitDirection = (target.Center.X < Projectile.position.X)? -1 : 1;
                    int damageDone = target.SimpleStrikeNPC(Projectile.damage, hitDirection, Main.rand.NextBool((int)Projectile.CritChance, 100), Projectile.knockBack, Projectile.DamageType);
                    Payload.OnHitNPC(Projectile, target, new NPC.HitInfo(), damageDone, 1f);
                }
            }
            for (int i = 0; i < 10; i++) {
                float posx = Main.rand.NextFloat(-40, 40);
                float posy = Main.rand.NextFloat(-40, 40);
                if(posx * posx + posy * posy < distanceSquared){
                    spawnDust(new Vector2(Projectile.position.X + posx, Projectile.position.Y + posy));
                    if(Main.rand.NextBool(1, 3)) Gore.NewGoreDirect(new EntitySource_Parent(Projectile), new Vector2(Projectile.position.X + posx, Projectile.position.Y + posy),  default, Main.rand.Next(61, 64), Main.rand.NextFloat(1f, 1.5f));
                    SoundEngine.PlaySound(in SoundID.Item14, Projectile.position);
                    SoundEngine.PlaySound(in SoundID.Item62, Projectile.position);
                }
            }
            void spawnDust(Vector2 position){
                Dust dust;
                for(int i = 1; i < 3; i++){
                    dust = Dust.NewDustDirect(position, 0, 0, DustID.Smoke, 0f, 0f, 100, Color.Red, 1f);
                    dust.velocity *= 1.4f;
                }
                dust = Dust.NewDustDirect(position, 0, 0, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                dust.noGravity = true;
                dust.velocity *= 7f;
                dust = Dust.NewDustDirect(position, 0, 0, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                dust.velocity *= 3f;
            }
        }
	}
}