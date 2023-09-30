using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Content.Items.Acessories
{
	public class ChargerEmblem : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
            Item.width = 9;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 24, 0, 0);
            Item.rare = ItemRarityID.Pink;	
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().ChargerEmblem = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RangerEmblem, 8);
			recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 10);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
		}
	}
}