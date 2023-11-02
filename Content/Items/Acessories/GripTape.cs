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
	public class GripTape : ModItem
	{
		public static readonly int ChargeDamageIncrease = 1;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeDamageIncrease);

		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 1, 20);
            Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().HasGripTape = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Rubber>(), 8);
            recipe.AddIngredient(ItemID.Gel, 12);
			recipe.AddIngredient(ItemID.SandBlock, 24);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}