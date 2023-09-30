using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class ExtensionCord : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 19;
            Item.height = 17;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = ItemRarityID.Pink;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().ExtensionCord = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BasicCircuitry>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Charger>());
			recipe.AddIngredient(ModContent.ItemType<LightningRod>());
            recipe.AddIngredient(ItemID.SoulofSight, 4);
			recipe.AddIngredient(ItemID.SoulofLight, 4);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
		}
	}
}