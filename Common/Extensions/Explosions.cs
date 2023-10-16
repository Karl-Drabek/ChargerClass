using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace ChargerClass.Common.Extensions
{
    public static class Explosions{

        public static void ExplodeSquare(this Projectile projectile, int explosionHeight, int explosionWidth, int damage = -1){
            int tempMaxPen = projectile.maxPenetrate;
            int tempPen = projectile.penetrate;
            int height = projectile.height;
            int width = projectile.width;
            int tempDamage = projectile.damage;

            projectile.Resize(explosionHeight, explosionWidth);
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            if(damage != -1) projectile.damage = damage;
            projectile.Damage();
			SoundEngine.PlaySound(SoundID.Item14, projectile.position);
			for (int i = 0; i < explosionHeight * explosionWidth / 100; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, explosionWidth, explosionHeight, DustID.Smoke, 0f, 0f, 100, default, 2f);
                dust = Dust.NewDustDirect(projectile.position, explosionHeight, explosionHeight, DustID.Torch, 0f, 0f, 100, default, 3f);
				dust.noGravity = true;
				dust = Dust.NewDustDirect(projectile.position, explosionHeight, explosionHeight, DustID.Torch, 0f, 0f, 100, default, 2f);
                dust.noGravity = true;
			}
            if(damage != -1) projectile.damage = tempDamage;
            projectile.tileCollide = true;
            projectile.penetrate = tempPen;
            projectile.maxPenetrate = tempMaxPen;
            projectile.Resize(height, width);
        }

        public static void ExplodeCircle(Vector2 position, int explosionRadius, int damage, DamageClass damageType, Entity source, float critChance = 0, float knockback = 0f, bool damageVariation = false, float luck = 0, bool noPlayerInteraction = false){
            int distanceSquared = explosionRadius * explosionRadius;
            for (int k = 0; k < Main.maxNPCs; k++) {
                NPC target = Main.npc[k];
                if(target.friendly || !target.active || target.dontTakeDamage) continue;
                if (Vector2.DistanceSquared(target.Center, position) < distanceSquared){
                    int hitDirection = (target.Center.X < position.X)? -1 : 1;
                    target.SimpleStrikeNPC(damage, hitDirection, Main.rand.NextBool((int)critChance, 100), knockback, damageType, damageVariation, luck, noPlayerInteraction);
                }
            }
            int count = distanceSquared / 500;
            for (int i = 0; i < count; i++) {
                float posx = Main.rand.NextFloat(-explosionRadius, explosionRadius);
                float posy = Main.rand.NextFloat(-explosionRadius, explosionRadius);
                if(posx * posx + posy * posy < distanceSquared){
                    spawnDust(new Vector2(position.X + posx, position.Y + posy));
                    Gore.NewGoreDirect(new EntitySource_Parent(source), new Vector2(position.X + posx, position.Y + posy),  default, Main.rand.Next(61, 64), Main.rand.NextFloat(1f, (explosionRadius / 200) + 1));
                    SoundEngine.PlaySound(in SoundID.Item14, position);
                    SoundEngine.PlaySound(in SoundID.Item62, position);
                }
            }
            void spawnDust(Vector2 position){
                Dust dust = Dust.NewDustDirect(position, 0, 0, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                dust.velocity *= 1.4f;
                dust = Dust.NewDustDirect(position, 0, 0, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                dust.noGravity = true;
                dust.velocity *= 7f;
                dust = Dust.NewDustDirect(position, 0, 0, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                dust.velocity *= 3f;
            }
        }
    }
}