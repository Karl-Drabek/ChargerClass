using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Consumables;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Acessories
{
	public class Haler : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 13;
            Item.height = 19;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 6, 30, 0);
            Item.rare =  ItemRarityID.LightRed;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().Haler = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.TitaniumBarRecipeGroup, 6);
			recipe.AddIngredient(ModContent.ItemType<Exhaler>());
			recipe.AddIngredient(ModContent.ItemType<Inhaler>());
			recipe.AddIngredient(ModContent.ItemType<HydrogenGas>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
		}
	}
}