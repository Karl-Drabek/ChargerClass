using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories;

public class Capacitor : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 9;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 6, 0);
            Item.rare = ItemRarityID.White;	
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().Capacitor = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wire, 12);
		recipe.AddIngredient(ItemID.ClayBlock, 12);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
	}
}