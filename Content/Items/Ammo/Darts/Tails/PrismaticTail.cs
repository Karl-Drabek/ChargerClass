using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class PrismaticTail : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 3;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.Orange;
            AIStyle = 0;
            
            Item.shootSpeed = 4f;
        }

        public override void OnSpawn(Projectile projectile, IEntitySource source){
            if(source is EntitySource_ItemUse_WithAmmo playerSource) projectile.owner = playerSource.Player.whoAmI;
            projectile.light = 1f;
        }

	public override void AI(Projectile projectile, int payloadType){
            projectile.rotation = projectile.velocity.RotatedBy((float)Math.PI /2).ToRotation();
            if(projectile.penetrate <= 1){
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, Main.rand.NextBool() ? DustID.PinkTorch : DustID.BlueTorch, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                dust.noGravity = true;
                return;
            }
            if(projectile.ai[2]++ > 20){
                Projectile dart = Projectile.NewProjectileDirect(new EntitySource_Parent(projectile), projectile.position, projectile.velocity.RotatedBy(MathHelper.ToRadians(-20)) * 0.75f, 
                    projectile.type, projectile.damage, projectile.knockBack, projectile.owner);
                projectile.ai[2] = 0;
                dart.penetrate = 1;
                dart.alpha = 255;
                dart.timeLeft = 90;
                dart = Projectile.NewProjectileDirect(new EntitySource_Parent(projectile), projectile.position, projectile.velocity.RotatedBy(MathHelper.ToRadians(20)) * 0.75f, 
                    projectile.type, projectile.damage, projectile.knockBack, projectile.owner);
                projectile.ai[2] = 0;
                dart.penetrate = 1;
                dart.alpha = 255;
                dart.timeLeft = 90;
            }
        }

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.Geode);
            recipe.AddIngredient(ItemID.CrystalShard, 5);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
    }