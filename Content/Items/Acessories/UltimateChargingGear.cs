using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Content.Items.Acessories
{
	public class UltimateChargingGear : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 35, 0, 0);
            Item.rare =  ItemRarityID.Pink;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().UltimateChargingGear = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SecretStimulants>());
			recipe.AddIngredient(ModContent.ItemType<TrackingSpecs>());
			recipe.AddIngredient(ModContent.ItemType<ShootingGlove>());
			recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 15);
            recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofFlight, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(TileID.Autohammer);
            recipe.Register();
		}
	}
}