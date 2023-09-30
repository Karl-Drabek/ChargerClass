    using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips
{
	public class LihzahrdTip : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.White;
            DartSheetPlacement = 11;
            Pen = 3;
            Item.damage = 20;
            Item.knockBack = 4f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ItemID.WoodenSpike);
            recipe.Register();
        }
    }
}