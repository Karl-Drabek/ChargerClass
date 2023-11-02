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
public class TitaniumCasque : ModItem
{
	public static int ChargeSpeedIncrease = 17;
        public static int MaxChargeIncrease = 7;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, MaxChargeIncrease);
	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.LightRed;
		Item.value = Item.sellPrice(0, 2, 40, 0);
		Item.defense = 7;
	}

	public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
		player.GetModPlayer<ChargeModPlayer>().MaxCharge += MaxChargeIncrease / 100f;
	}
	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
	}

	public override void UpdateArmorSet(Player player) {
		player.setBonus = Language.GetTextValue("ArmorSetBonus.Titanium");
		player.onHitTitaniumStorm = true;
	}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TitaniumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
}