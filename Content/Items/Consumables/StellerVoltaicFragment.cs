using ChargerClass.Common.ModSystems;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables;

public class StellerVoltaicFragment : ModItem
{
	public static readonly int MaxStellerVoltaicFragments = 10;
	public static readonly int MaxChargeIncrease = 25;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease);

	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 10;
	}

	public override void SetDefaults() {
		Item.CloneDefaults(ItemID.LifeFruit);
		Item.rare = ItemRarityID.Cyan;
		Item.value = Item.sellPrice(0, 1, 65, 0);
	}
	public override bool? UseItem(Player player) {
		if (player.GetModPlayer<ChargeModPlayer>().StellerVoltaicFragmentCount >= MaxStellerVoltaicFragments) return null;
		player.GetModPlayer<ChargeModPlayer>().StellerVoltaicFragmentCount++;
		CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), MaxChargeIncrease);
		return true;
	}

	public override void AddRecipes() {
		CreateRecipe()
			.AddRecipeGroup(ChargerClassGeneralSystem.VoltaicScrapRecipeGroup)
			.AddIngredient(ItemID.FragmentSolar)
			.AddIngredient(ItemID.FragmentStardust)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}