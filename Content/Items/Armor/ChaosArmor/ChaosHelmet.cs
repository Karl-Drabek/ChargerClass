using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.ChaosArmor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Head)]
public class ChaosHelmet : ModItem
{
	public static int ChargeSpeedIncrease = 13;

	public static int MaxChargeIncrease = 7;
	public static int ChargeDamageIncrease = 8;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxChargeIncrease, ChargeDamageIncrease);
        public static LocalizedText SetBonusText { get; private set; }

	public override void SetStaticDefaults() {
		SetBonusText = this.GetLocalization("SetBonus");
	}
	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Red;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.defense = 14;
	}

	public override void UpdateEquip(Player player) {
            player.GetModPlayer<ChargeModPlayer>().ChaosSet = true;
	}
	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return body.type == ModContent.ItemType<ChaosPlate>() && legs.type == ModContent.ItemType<ChaosLeggings>();
	}

	public override void UpdateArmorSet(Player player) {
		player.setBonus = SetBonusText.Value;
		player.GetModPlayer<ChargeModPlayer>().MaxCharge += 0.1f;
	}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 12);
		recipe.AddIngredient(ItemID.LunarBar, 8);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
}