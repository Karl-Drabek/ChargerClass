using ChargerClass.Common.ModSystems;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables
{
	public class CosmicVoltaicFragment : ModItem
	{
		public static readonly int MaxCosmicVoltaicFragment = 10;
		public static readonly int ChargeSpeedIncrease = 5;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxCosmicVoltaicFragment);

		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 10;
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.sellPrice(0, 1, 65, 0);
		}
		public override bool? UseItem(Player player) {
			if (player.GetModPlayer<ChargeModPlayer>().CosmicVoltaicFragmentCount >= MaxCosmicVoltaicFragment) return null;
			player.GetModPlayer<ChargeModPlayer>().CosmicVoltaicFragmentCount++;
			CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), ChargeSpeedIncrease);
			return true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddRecipeGroup(ChargerClassGeneralSystem.VoltaicScrapRecipeGroup)
				.AddIngredient(ItemID.FragmentNebula)
				.AddIngredient(ItemID.FragmentVortex)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}