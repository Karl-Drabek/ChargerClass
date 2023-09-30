using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class RadioactiveParsel : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 10;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.LightPurple;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 25);
            recipe.AddIngredient(ModContent.ItemType<RadioactiveDebris>());
            recipe.Register();
        }
    }
}