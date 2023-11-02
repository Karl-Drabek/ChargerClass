using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories
{
	public class IronLung : ModItem
	{
		public static readonly int MaxChargeIncrease = 15;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease);
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(15, 6)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 2, 80);
            Item.rare =  ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().HasIronLung = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wire, 6);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 24);
			recipe.AddRecipeGroup(ChargerClassGeneralSystem.GoldBarRecipeGroup, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}