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
	public class CropDusterProjectile : ModProjectile
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
            Projectile.timeLeft = 55;
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
            Projectile.velocity *= 0.98f;
            Projectile.alpha += 5;
            Projectile.rotation += rotation;
        }

        
		public override void OnKill(int timeLeft){
            Dust.NewDustDirect(Projectile.position, 0, 0, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
            Gore.NewGoreDirect(new EntitySource_Parent(Projectile), Projectile.position, default, Main.rand.Next(61, 64));
        }
	}
}