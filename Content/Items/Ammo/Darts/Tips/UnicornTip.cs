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
	public class UnicornTip : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.Blue;
            DartSheetPlacement = 4;
            Pen = 3;
            Item.damage = 11;
            Item.knockBack = 1f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.UnicornHorn);
            recipe.Register();
        }
    }
}