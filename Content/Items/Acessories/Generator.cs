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
	public class Generator : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(30, 4)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 23;
            Item.height = 22;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.rare = ItemRarityID.Cyan;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().Generator = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentNebula, 3);
			recipe.AddIngredient(ItemID.FragmentSolar, 3);
			recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 16);
			recipe.AddIngredient(ModContent.ItemType<ChargeRepository>());
			recipe.AddIngredient(ModContent.ItemType<ExtensionCord>());
			recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 6);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
		}
	}
}