using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.ChaosArmor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Legs)]
public class ChaosLeggings : ModItem
{
	public static int ChargeSpeedIncrease = 14;
	public static int MaxChargeIncrease = 8;
	public static int ChargeDamageIncrease = 12;
        public static int MovementSpeedIncrease = 20;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxChargeIncrease, ChargeDamageIncrease, MovementSpeedIncrease);

	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Red;
		Item.value = Item.sellPrice(0, 10, 50, 0);
		Item.defense = 19;
	}
	public override void UpdateEquip(Player player) {
            player.GetDamage<ChargerDamageClass>() += ChargeDamageIncrease / 100f;
		player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
		player.moveSpeed += MovementSpeedIncrease / 100f;
		player.GetModPlayer<ChargeModPlayer>().MaxCharge += MaxChargeIncrease / 100f;
	}

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 16);
		recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
}