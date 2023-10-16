using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables
{
	public class FrightfulVoltaicScrap : ModItem
	{
		public static readonly int MaxFrightfulVoltaicScrap = 10;
		public static readonly int ChargeSpeedIncrease = 5;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxFrightfulVoltaicScrap);

		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 1, 25, 0);
		}
		public override bool? UseItem(Player player) {
			if (player.GetModPlayer<ChargeModPlayer>().FrightfulVoltaicScrapCount >= MaxFrightfulVoltaicScrap) return null;
			player.GetModPlayer<ChargeModPlayer>().FrightfulVoltaicScrapCount++;
			CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), ChargeSpeedIncrease);
			return true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<VoltaicNugget>(1)
				.AddIngredient(ItemID.SoulofFright)
				.AddIngredient(ItemID.SoulofNight)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}