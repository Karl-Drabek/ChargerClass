using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class HolyLightTail : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 11;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = ItemRarityID.Yellow;
            
            Item.shootSpeed = 6;
        }

        public override void AI(Projectile projectile, int payloadType){
            if(projectile.ai[2]++ > 10){
                projectile.ai[2] = 0;
                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.position, Vector2.Normalize(projectile.velocity).RotatedBy(MathHelper.ToRadians(90  * (Main.rand.NextBool() ? -1 : 1))) * 3, ModContent.ProjectileType<HolyCrossProjectile>(), projectile.damage, 0);
            }
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<PrismaticTail>(), 25);
            recipe.AddIngredient(ItemID.FragmentSolar);
            recipe.AddIngredient(ItemID.FragmentNebula);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.Register();
        }
    }