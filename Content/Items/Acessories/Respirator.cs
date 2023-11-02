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
	public class Respirator : ModItem
	{
		public static readonly int DamageIncrease = 15;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DamageIncrease);
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 20;
            Item.height = 15;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1, 70, 0);
            Item.rare =  ItemRarityID.Pink;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().HasRespirator = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 4);
			recipe.AddIngredient(ItemID.PixieDust, 6);
			recipe.AddIngredient(ItemID.Cloud, 60);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
		}
	}
}