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
	public class ChargeRepository : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 6)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 11;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().ChargeRepository = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(ChargerClassGeneralSystem.TitaniumBarRecipeGroup, 6);
			recipe.AddIngredient(ModContent.ItemType<BasicCircuitry>(), 8);
			recipe.AddRecipeGroup(ChargerClassGeneralSystem.GoldBarRecipeGroup, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
		}
	}
}