using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ChargerClass.Common.Extensions
{
    public static class Extensions{

        public static void Explode(this Projectile projectile, int explosionHeight, int explosionWidth){
            int tempMaxPen = projectile.maxPenetrate;
            int tempPen = projectile.penetrate;
            int height = projectile.height;
            int width = projectile.width;

            projectile.Resize(explosionHeight, explosionWidth);
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;

            projectile.Damage();
			SoundEngine.PlaySound(SoundID.Item14, projectile.position);
			for (int i = 0; i < explosionHeight * explosionWidth / 100; i++) {
				Dust dust = Dust.NewDustDirect(projectile.position, explosionWidth, explosionHeight, DustID.Smoke, 0f, 0f, 100, default, 2f);
                dust = Dust.NewDustDirect(projectile.position, explosionHeight, explosionHeight, DustID.Torch, 0f, 0f, 100, default, 3f);
				dust.noGravity = true;
				dust = Dust.NewDustDirect(projectile.position, explosionHeight, explosionHeight, DustID.Torch, 0f, 0f, 100, default, 2f);
                dust.noGravity = true;
			}
            
            projectile.tileCollide = true;
            projectile.penetrate = tempPen;
            projectile.maxPenetrate = tempMaxPen;
            projectile.Resize(height, width);
        }
    }
}