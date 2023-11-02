using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class LunarTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.Cyan;
            DartSheetPlacement = 12;
            Pen = 5;
            Item.damage = 23;
            Item.knockBack = 5f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.LunarBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }