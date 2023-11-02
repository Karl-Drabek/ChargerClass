using Terraria;
using Terraria.ID;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class HypodermicNeedle : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 3);
            Item.rare = ItemRarityID.White;
            DartSheetPlacement = 0;
            Pen = 1;
            Item.damage = 6;
            Item.knockBack = 1f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.SilverBarRecipeGroup, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }