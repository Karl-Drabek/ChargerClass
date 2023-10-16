using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.FestiveArmor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class FestiveLeggings : ModItem
	{
		public static int ChargeSpeedIncrease = 7;

		public static int ChargeDamageIncrease = 5;

		public static int MoveSpeedIncrease = 15;

		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease, ChargeDamageIncrease, MoveSpeedIncrease);

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(0, 12, 0, 0);
			Item.defense = 5;
		}
		public override void UpdateEquip(Player player) {
            player.GetAttackSpeed<ChargerDamageClass>() += ChargeSpeedIncrease / 100f;
			player.GetDamage<ChargerDamageClass>() += ChargeDamageIncrease / 100f;
			player.moveSpeed += MoveSpeedIncrease / 100f;
		}

		public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChristmasCheer>(), 600);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}