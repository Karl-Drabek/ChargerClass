using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class BoneTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.White;
            DartSheetPlacement = 2;
            Pen = 2;
            Item.damage = 9;
            Item.knockBack = 1f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.Bone, 1);
            recipe.Register();
        }
    }