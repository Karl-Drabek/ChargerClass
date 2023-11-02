using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class TitaniumTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.Orange;
            DartSheetPlacement = 6;
            Pen = 2;
            Item.damage = 12;
            Item.knockBack = 2f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.TitaniumBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }