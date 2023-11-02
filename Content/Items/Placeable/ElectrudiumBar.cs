using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Placeable;

public class ElectrudiumBar : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;

            ItemID.Sets.SortingPriorityMaterials[Item.type] = ItemID.Sets.SortingPriorityMaterials[ItemID.Meteorite];
            ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 5, ItemID.ChlorophyteBar, 3);
        }

        public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ElectrudiumBar>());
            Item.width = 8;
            Item.height = 7;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ElectrudiumOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }