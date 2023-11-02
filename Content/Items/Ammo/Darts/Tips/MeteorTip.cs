using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class MeteorTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.Blue;
            DartSheetPlacement = 1;
            Pen = 1;
            Item.damage = 8;
            Item.knockBack = 1.5f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.MeteoriteBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }