using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.FestiveArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class FestiveBreastplate : ModItem
	{
		public static int MaxChargeIncrease = 3;
		public static int ChargeDamageIncrease = 10;
        public static int ChargeSpeedIncrease = 5;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease, ChargeDamageIncrease, ChargeSpeedIncrease);

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 16, 0, 0);
			Item.defense = 24;
		}

		public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
			player.GetDamage<ChargerDamageClass>() += ChargeDamageIncrease / 100f;
			player.GetModPlayer<ChargeModPlayer>().MaxCharge += MaxChargeIncrease / 100f;
		}

		public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChristmasCheer>(), 800);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}