using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads;

public class DartCannister : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 0;
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.Glass, 25);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }