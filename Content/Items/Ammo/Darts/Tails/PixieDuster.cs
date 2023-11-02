using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using Terraria.DataStructures;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class PixieDuster : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 5;
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.Orange;
            
            Item.shootSpeed = 4;
        }

        public override void AI(Projectile projectile, int payloadType){
            Projectile dust = Projectile.NewProjectileDirect(new EntitySource_Misc("No Desired Inheritance"), projectile.position, default, ModContent.ProjectileType<PixieDust>(), 35, 0);
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.PixieDust);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
    }