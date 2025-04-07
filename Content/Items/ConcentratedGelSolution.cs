using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class ConcentratedGelSolution : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 26;

		Item.maxStack = 999;
		Item.value = Item.sellPrice(0, 0, 0, 12);
		Item.rare = ItemRarityID.Orange;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Gel, 4);
		recipe.AddTile(TileID.AdamantiteForge);
		recipe.Register();
	}
}