using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories;

public class HydrogenGas : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 11;
            Item.height = 23;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 2, 20, 0);
            Item.rare =  ItemRarityID.Green;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HydrogenBreath = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CloudinaBottle);
		recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
	}
}