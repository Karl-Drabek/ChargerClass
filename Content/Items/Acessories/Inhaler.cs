using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Consumables;

namespace ChargerClass.Content.Items.Acessories
{
	public class Inhaler : ModItem
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
            Item.value = Item.sellPrice(0, 0, 16, 0);
            Item.rare =  ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().Inhaler	 = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ModContent.ItemType<Rubber>());
			recipe.AddIngredient(ModContent.ItemType<StaminaPotion>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}