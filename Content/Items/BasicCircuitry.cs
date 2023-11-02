using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Content.Items
{
	public class BasicCircuitry : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults() {
            Item.width = 24;
            Item.height = 38;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 33, 0);
            Item.rare = ItemRarityID.Green;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ElectrudiumBar>());
            recipe.AddIngredient(ItemID.GoldBar);
            recipe.AddIngredient(ItemID.Wire);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}