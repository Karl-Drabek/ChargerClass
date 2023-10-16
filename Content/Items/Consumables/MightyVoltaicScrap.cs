using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables
{
	public class MightyVoltaicScrap : ModItem
	{
		public static readonly int MaxMightyVoltaicScrap = 10;
		public static readonly int MaxChargeIncrease = 25;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease, MaxMightyVoltaicScrap);

		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 1, 25, 0);
		}
		public override bool? UseItem(Player player) {
			if (player.GetModPlayer<ChargeModPlayer>().MightyVoltaicScrapCount >= MaxMightyVoltaicScrap) return null;
			player.GetModPlayer<ChargeModPlayer>().MightyVoltaicScrapCount++;
			CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), MaxChargeIncrease);
			return true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<VoltaicNugget>(1)
				.AddIngredient(ItemID.SoulofMight)
				.AddIngredient(ItemID.SoulofFlight)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}