using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Placeable
{
	public class DartAssemblyStation : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.DartAssemblyStationTile>());
            Item.width = 8;
            Item.height = 7;
            Item.value = Item.sellPrice(0, 0, 42, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 60);
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.SilverBarRecipeGroup, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}