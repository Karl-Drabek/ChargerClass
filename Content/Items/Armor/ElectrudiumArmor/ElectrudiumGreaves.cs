using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.ElectrudiumArmor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Legs)]
public class ElectrudiumGreaves : ModItem
{
	public static int ChargeSpeedIncrease = 3;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease);

	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.sellPrice(0, 3, 20, 0);
		Item.defense = 5;
	}
	public override void UpdateEquip(Player player) {
            player.GetDamage<ChargerDamageClass>() += 0.05f;
	}

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ElectrudiumBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
}