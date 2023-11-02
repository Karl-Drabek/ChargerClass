using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables;

public class OpticVoltaicScrap : ModItem
{
	public static readonly int MaxOpticVoltaicScrap = 10;
	public static readonly int ChargeLevelDecrease = 2;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeLevelDecrease);

	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 10;
	}

	public override void SetDefaults() {
		Item.CloneDefaults(ItemID.LifeFruit);
		Item.width = 34;
            Item.height = 48;
		Item.rare = ItemRarityID.LightRed;
		Item.value = Item.sellPrice(0, 1, 25, 0);
	}
	public override bool? UseItem(Player player) {
		if (player.GetModPlayer<ChargeModPlayer>().OpticVoltaicScrapCount >= MaxOpticVoltaicScrap) return null;
		player.GetModPlayer<ChargeModPlayer>().OpticVoltaicScrapCount++;
		CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), +ChargeLevelDecrease);
		return true;
	}

	public override void AddRecipes() {
		CreateRecipe()
			.AddIngredient<VoltaicNugget>()
			.AddIngredient(ItemID.SoulofSight)
			.AddIngredient(ItemID.SoulofLight)
			.AddTile(TileID.DemonAltar)
			.Register();
	}
}