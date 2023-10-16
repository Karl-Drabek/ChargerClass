using System;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles
{
	public class RocketStormProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

        public const int Speed = 10;
        private const float rotationSpeed = 0.1f;
        const float speed = 7;
		public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;

			Projectile.aiStyle = 0;
			Projectile.DamageType = ChargerDamageClass.Instance;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 600;
		}

		public override void OnSpawn(IEntitySource source){
            Projectile.velocity.Normalize();
            Projectile.velocity *= speed;
        }

		public override void AI() {
			float maxDetectRadius = 1000f;

			NPC closestNPC = Targeting.FindClosestNPCBiasBoss(Projectile.Center, maxDetectRadius);
			if (closestNPC == null) return;

            float directionToNPC = (closestNPC.Center - Projectile.Center).ToRotation();
            float difference = directionToNPC - Projectile.velocity.ToRotation();
			if(difference > Math.PI) difference = -(float)Math.PI * 2 + difference;
			if(difference < -Math.PI) difference = (float)Math.PI * 2 - difference;
            float rotation = difference switch{
                > rotationSpeed => rotationSpeed,
                < -rotationSpeed => -rotationSpeed,
                _ => difference
            };
			Projectile.velocity = Projectile.velocity.RotatedBy(rotation);
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

        public override void Kill(int timeLeft) {
            Explosions.ExplodeCircle(Projectile.position, 100, 200, ChargerDamageClass.Instance, Projectile, knockback: 2f);
        }
	}
}