using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class CarBattery : ModItem
{
	public static readonly int maxChargeIncrease = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(maxChargeIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(16, 3)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
            Item.width = 15;
            Item.height = 17;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 2, 60, 0);
            Item.rare = ItemRarityID.Green;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasCarBattery = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 4);
		recipe.AddIngredient(ModContent.ItemType<BasicCircuitry>(), 4);
		recipe.AddIngredient(ModContent.ItemType<Capacitor>());
		recipe.AddIngredient(ModContent.ItemType<AAABattery>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
	}
}