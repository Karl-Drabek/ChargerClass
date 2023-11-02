using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Head)]
public class AdamantiteCasque : ModItem
{
	public static int ChargeSpeedIncrease = 15;
        public static int MaxChargeIncrease = 10;

	public static int SetCritIncreasePerLevel = 4;
	public static int MaxCritIncrease = 5;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxChargeIncrease);
        public static LocalizedText SetBonusText { get; private set; }

	public override void SetStaticDefaults() {
		SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(SetCritIncreasePerLevel, SetCritIncreasePerLevel * MaxCritIncrease);
	}
	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.LightRed;
		Item.value = Item.sellPrice(0, 1, 80, 0);
		Item.defense = 7;
	}

	public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
		player.GetModPlayer<ChargeModPlayer>().MaxCharge += MaxChargeIncrease / 100f;
	}
	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
	}

	public override void UpdateArmorSet(Player player) {
		player.setBonus = SetBonusText.Value;
		player.GetModPlayer<ChargeModPlayer>().MythrilArmorSet = true;
	}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
}