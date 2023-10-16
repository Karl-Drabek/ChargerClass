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
	public class PixieDust : ModProjectile
	{
        float rotation = 0;
		public override void SetDefaults()
		{
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 255;
            Projectile.alpha = 0;
            Projectile.light = 1.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
            
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void OnSpawn(IEntitySource source){
            rotation = Main.rand.NextFloat(MathHelper.ToRadians(-5f), MathHelper.ToRadians(5f));
        }
		public override void AI(){
            Projectile.velocity.Y = 2.5f;
            Projectile.alpha += 1;
            Projectile.rotation += rotation;
        }
	}
}