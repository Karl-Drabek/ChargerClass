using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class ExoticEscargot : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults() {
            Item.width = 8;
            Item.height = 7;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 12, 0);
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ItemID.TruffleWorm);
            recipe.AddIngredient(ItemID.Escargot);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();
        }
    }