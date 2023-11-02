using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories
{
	public class Charger : ModItem
	{
		public static readonly int ChargeSpeedIncrease = 5;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeSpeedIncrease);
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 14;
            Item.height = 19;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().HasCharger = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wire, 8);
			recipe.AddIngredient(ModContent.ItemType<ElectrudiumBar>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}