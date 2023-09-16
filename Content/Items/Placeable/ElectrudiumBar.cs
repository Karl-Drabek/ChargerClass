using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Placeable
{
	public class ElectrudiumBar : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;

            ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;
            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 5, ItemID.ChlorophyteBar, 3);
        }

        public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ElectrudiumBar>());
            Item.width = 8;
            Item.height = 7;
            Item.value = Item.sellPrice(0, 0, 42, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Placeable.ElectrudiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}