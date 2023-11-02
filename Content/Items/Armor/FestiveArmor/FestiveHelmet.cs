using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.FestiveArmor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Head)]
public class FestiveHelmet: ModItem
{
	public static int MaxChargeIncrease = 3;
	public static int ChargeCritChanceIncrase = 10;
        public static int ChargeSpeedIncrease = 5;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease, ChargeCritChanceIncrase, ChargeSpeedIncrease);
        public static LocalizedText SetBonusText { get; private set; }

	public override void SetStaticDefaults() {
		SetBonusText = this.GetLocalization("SetBonus");
	}
	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Yellow;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.defense = 12;
	}

	public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
		player.GetCritChance<ChargerDamageClass>() += ChargeCritChanceIncrase / 100f;
		var modPlayer = player.GetModPlayer<ChargeModPlayer>();
		modPlayer.MaxCharge += MaxChargeIncrease / 100f;
	}
	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return body.type == ModContent.ItemType<FestiveBreastplate>() && legs.type == ModContent.ItemType<FestiveLeggings>();
	}

	public override void UpdateArmorSet(Player player) {
		player.setBonus = SetBonusText.Value;
		player.GetModPlayer<ChargeModPlayer>().FestiveSet = true;
	}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChristmasCheer>(), 400);
		recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
}