using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class GodKillerCocktail : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 12;
            Item.value = Item.sellPrice(0, 0, 4, 10);
            Item.rare = ItemRarityID.Lime;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.AddIngredient(ModContent.ItemType<DartFrogDebilitator>(), 5);
            recipe.AddIngredient(ModContent.ItemType<DeathFactor>(), 5);
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.IchorCannisters, 5);
            recipe.AddIngredient(ModContent.ItemType<JellyfishCannister>(), 5);
            recipe.AddIngredient(ModContent.ItemType<CryoCannister>(), 5);
            recipe.AddIngredient(ModContent.ItemType<LavaCannister>(), 5);
            recipe.AddIngredient(ModContent.ItemType<RadioactiveParsel>(), 5);  
            recipe.AddIngredient(ItemID.FragmentSolar);
            recipe.AddIngredient(ItemID.FragmentNebula);
            recipe.AddIngredient(ItemID.FragmentVortex);
            recipe.AddIngredient(ItemID.FragmentStardust);
             recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}