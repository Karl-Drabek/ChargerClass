using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class BreathingAid : ModItem
{
	public static readonly int StatIncrease = 25;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(StatIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 18, 50, 0);
            Item.rare =  ItemRarityID.Yellow;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasBreathingAid = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<IronLung>());
		recipe.AddIngredient(ModContent.ItemType<Diaphragm>());
		recipe.AddIngredient(ModContent.ItemType<Respirator>());
		recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 12);
		recipe.AddIngredient(ItemID.SpectreBar, 6);
            recipe.AddIngredient(ItemID.SoulofMight, 4);
		recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
	}
}