using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class BetsysBackwash : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 10;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = ItemRarityID.Lime;
            AIStyle = 0;
            
            Item.shootSpeed = 4f;
        }

        public override void AI(Projectile projectile, int payloadType){
            projectile.rotation = projectile.velocity.RotatedBy((float)Math.PI /2).ToRotation();
            for(int i = 0; i < 5; i++){
                Projectile fireball = Projectile.NewProjectileDirect(new EntitySource_Parent(projectile), projectile.Center - Vector2.Normalize(projectile.velocity), (Vector2.Normalize(projectile.velocity) * -10).RotatedByRandom(MathHelper.ToRadians(90)), ProjectileID.Fireball, projectile.damage / 25, 0f);
                fireball.friendly = true;
                fireball.hostile = false;
                fireball.scale = Main.rand.NextFloat(1f, 2.5f);
                fireball.timeLeft = Main.rand.Next(15, 25);
                fireball.usesLocalNPCImmunity = true;
		    fireball.localNPCHitCooldown = 10;
            }
        }
    }