using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables;

public class VoltaicNugget : ModItem
{
	public static readonly int MaxVoltaicNuggets = 20;
	public static readonly int MaxChargeIncrease = 25;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease);

	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 10;
	}

	public override void SetDefaults() {
		Item.CloneDefaults(ItemID.LifeFruit);
		Item.width = 22;
            Item.height = 28;
		Item.rare = ItemRarityID.Green;
		Item.value = Item.sellPrice(0, 0, 85, 0);
	}
	public override bool? UseItem(Player player) {
		if (player.GetModPlayer<ChargeModPlayer>().VoltaicNuggetCount >= MaxVoltaicNuggets) return null;
		player.GetModPlayer<ChargeModPlayer>().VoltaicNuggetCount++;
		CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), MaxChargeIncrease);
		return true;
	}

	public override void AddRecipes() {
		CreateRecipe()
			.AddIngredient<ElectrudiumBar>(4)
			.AddIngredient(ItemID.FallenStar, 1)
			.AddTile(TileID.Anvils)
			.Register();
	}
}