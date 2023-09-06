using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

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
            Projectile.DamageType = DamageClass.Ranged;
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
            //I think by setting these to less than 0 it will have no problem hitting as many entities as it would like when it is resized
			Projectile.maxPenetrate = -1;
			Projectile.penetrate = -1;

			int explosionArea = 50;
			Vector2 oldSize = Projectile.Size;

            //I'm not totally sure why this is necessary but it was in the example mod and I think makes the damage more centered
			Projectile.position = Projectile.Center; //Center the projectile's hitbox
			Projectile.Size += new Vector2(explosionArea); //resize the projectile
			Projectile.Center = Projectile.position; //offset the projectile again

            
			Projectile.tileCollide = false;
			Projectile.velocity *= 0.01f;//seems like velocity should just be 0 but this was also in the example mod so I will trust it

			Projectile.Damage(); //damage the entities
			Projectile.scale = 0.01f; //Once again I don't know why this is here but it was in example mod

			Projectile.position = Projectile.Center; //same as before but returns the projectile to its old size.
			Projectile.Size = oldSize;
			Projectile.Center = Projectile.position;
            //It dies shortly after so I don't know why this is neccessary except that maybe it shows for one more frame.
        }
	}
}