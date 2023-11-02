using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class ChargerEmblem : ModItem
{
	public static readonly int DamageIncrease = 20;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DamageIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}

	public override void SetDefaults()
	{
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 24, 0, 0);
            Item.rare = ItemRarityID.Pink;	
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasChargerEmblem = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RangerEmblem, 8);
		recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 10);
		recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
	}
}