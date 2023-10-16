using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.ElectrudiumArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class ElectrudiumHelmet : ModItem
	{
		public static int ChargeSpeedIncrease = 2;
		public static int SetDamageIncrease = 10;
        public static int SetMaxChargeIncrease = 5;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease);
        public static LocalizedText SetBonusText { get; private set; }

		public override void SetStaticDefaults() {
			SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(SetDamageIncrease, SetMaxChargeIncrease);
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 2, 40, 0);
			Item.defense = 4;
		}

		public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += 0.05f;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<ElectrudiumChainmail>() && legs.type == ModContent.ItemType<ElectrudiumGreaves>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = SetBonusText.Value;
			player.GetModPlayer<ChargeModPlayer>().MaxCharge += 0.1f;
		}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ElectrudiumBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}