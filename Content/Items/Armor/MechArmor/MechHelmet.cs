using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Acessories;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.MechArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class MechHelmet : ModItem
	{
		public static int MaxChargeIncrease = 8;
		public static int ChargeSpeedIncrease = 12;
		public static int CritChanceIncrease = 7;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease, ChargeSpeedIncrease, CritChanceIncrease);

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 17, 50, 0);
			Item.defense = 13;
		}
		public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
			player.GetModPlayer<ChargeModPlayer>().MaxCharge += MaxChargeIncrease / 100f;
			player.GetCritChance<ChargerDamageClass>() += CritChanceIncrease / 100f;
		}

		public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 16);
			recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 8);
			recipe.AddIngredient(ModContent.ItemType<Respirator>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}