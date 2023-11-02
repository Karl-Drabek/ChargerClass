using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class SpectreTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = ItemRarityID.Lime;
            DartSheetPlacement = 10;
            Pen = 3;
            Item.damage = 18;
            Item.knockBack = 1f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.SpectreBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }