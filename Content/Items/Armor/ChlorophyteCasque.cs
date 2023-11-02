using ChargerClass.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Head)]
public class ChlorophyteCasque : ModItem
{
	public static int StatIncreasePerLevel = 3;
	public static int MaxLevels = 5;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(StatIncreasePerLevel, StatIncreasePerLevel * MaxLevels);
	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Lime;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.defense = 11;
	}

	public override void UpdateEquip(Player player) {
            player.GetModPlayer<ChargeModPlayer>().HasChlorophyteCasque = true;
	}
	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
	}

	public override void UpdateArmorSet(Player player) {
		player.setBonus = Language.GetTextValue("ArmorSetBonus.Chlorophyte");
		player.AddBuff(BuffID.LeafCrystal, 18000);
	}

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
}