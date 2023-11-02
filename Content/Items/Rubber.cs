using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class Rubber : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults() {
            Item.width = 8;
            Item.height = 7;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ItemID.Gel, 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }