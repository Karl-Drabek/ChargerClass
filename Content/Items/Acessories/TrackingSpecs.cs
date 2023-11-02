using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories
{
	public class TrackingSpecs : ModItem
	{
		public static readonly int CritChanceIncrease = 2;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncrease);
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 26;
            Item.height = 24;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 12, 0, 0);
            Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().HasTrackingSpecs = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedDot>());
			recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 12);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
			recipe.AddIngredient(ItemID.SniperScope);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
		}
	}
}