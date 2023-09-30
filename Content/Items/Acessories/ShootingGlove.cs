using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Acessories
{
	public class ShootingGlove : ModItem
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
            Item.value = Item.sellPrice(0, 0, 24, 0);
            Item.rare = ItemRarityID.Green;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().ShootingGlove = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LeatherGlove>());
            recipe.AddIngredient(ModContent.ItemType<GripTape>());
			recipe.AddRecipeGroup(ChargerClassGeneralSystem.ShadowScaleRecipeGroup, 6);
			recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
		}
	}
}