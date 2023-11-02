using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Projectiles;

public class HandCannonBombProjectile : ModProjectile
{
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.Bomb}";

	public override void SetDefaults()
	{
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 60;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            
            AIType = ProjectileID.WoodenArrowFriendly;
        }
        float rotation;
	public override void OnSpawn(IEntitySource source){
            if(source is EntitySource_Parent parent && parent.Entity is not Terraria.Projectile) rotation = Main.rand.NextFloat(3f, 7f) * (Main.rand.NextBool() ? 1 : -1);
        }

	public override void AI(){
            Projectile.ai[1] += MathHelper.ToRadians(rotation);
            Projectile.rotation = Projectile.ai[1];
        }

        public override void OnKill(int timeLeft) {
            Explosions.ExplodeCircle(Projectile.position, 60, Projectile.damage * 2, ChargerDamageClass.Instance, Projectile, knockback: 3f);
            if(Projectile.ai[2] == 1f) for(int i = 0; i < 6; i++){
				Projectile proj = Projectile.NewProjectileDirect(new EntitySource_Parent(Projectile),
				Projectile.Center, (Vector2.UnitX * 5).RotatedBy(MathHelper.ToRadians(i * 60)), ModContent.ProjectileType<HandCannonBombProjectile>(), Projectile.damage, Projectile.knockBack);
                    proj.friendly = proj.hostile = false;
                    proj.timeLeft = 25;
                    proj.aiStyle = 0;
                    proj.tileCollide = false;
			}
        }
}