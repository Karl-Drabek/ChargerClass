using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class Overcharger : ModItem
{
	public static readonly int OverChargeMax = 3;
	public static readonly int OverChargeAmount = 3;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(OverChargeAmount, OverChargeMax);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
            Item.width = 40;
            Item.height = 50;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Lime;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasOvercharger = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.CrystalShard, 5);
		recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 6);
		recipe.AddIngredient(ModContent.ItemType<BasicCircuitry>(), 8);
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.SilverBarRecipeGroup, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
}