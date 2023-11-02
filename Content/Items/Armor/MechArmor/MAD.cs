using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using ChargerClass.Content.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.MechArmor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Body)]

public class MAD : ModItem
{

	public static int MaxChargeIncrease = 17;
	public static int ChargeBossDamageIncrease = 15;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease, ChargeBossDamageIncrease);

	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Yellow;
		Item.value = Item.sellPrice(0, 34, 0, 0);
		Item.defense = 23;
	}

	public override void UpdateEquip(Player player) {
            player.GetModPlayer<ChargeModPlayer>().MADChest = true;
		player.GetModPlayer<ChargeModPlayer>().MaxCharge += MaxChargeIncrease / 100f;
	}

	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return head.type == ModContent.ItemType<MechHelmet>() && legs.type == ModContent.ItemType<MechLeggings>();
	}

	public override void UpdateArmorSet(Player player) {
		player.setBonus = this.GetLocalization("SetBonus").Value;
		player.GetModPlayer<ChargeModPlayer>().MADSet = true;
	}

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 30);
		recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 15);
		recipe.AddIngredient(ModContent.ItemType<HydraRocketLauncher>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
}