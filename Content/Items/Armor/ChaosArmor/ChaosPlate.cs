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
[AutoloadEquip(EquipType.Body)]
public class ChaosPlate : ModItem
{
	public static int ChargeSpeedIncrease = 18;
	public static int MaxChargeIncrease = 12;
	public static int ChargeDamageIncrease = 16;
        public static int ChargeCritChanceIncreasePerLevel = 5;
	public static int MaxCritIncrease = 5;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxChargeIncrease, ChargeDamageIncrease, ChargeCritChanceIncreasePerLevel, ChargeCritChanceIncreasePerLevel * MaxCritIncrease);

	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Red;
		Item.value = Item.sellPrice(0, 14, 0, 0);
		Item.defense = 27;
	}

	public override void UpdateEquip(Player player) {
            player.GetDamage<ChargerDamageClass>() += ChargeDamageIncrease / 100f;
		player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
		var modPlayer = player.GetModPlayer<ChargeModPlayer>();
		modPlayer.MaxCharge += MaxChargeIncrease / 100f;
		modPlayer.HasChaosPlate = true;
	}

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 24);
		recipe.AddIngredient(ItemID.LunarBar, 16);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
}