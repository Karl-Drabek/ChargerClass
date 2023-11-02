using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class HallowedTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.LightRed;
            DartSheetPlacement = 7;
            Pen = 3;
            Item.damage = 14;
            Item.knockBack = 2.5f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }