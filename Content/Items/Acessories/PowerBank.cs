using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Placeable;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories
{
	public class PowerBank : ModItem
	{
		public static readonly int MaxChargeIncrease = 15;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxChargeIncrease, Overcharger.OverChargeAmount, Overcharger.OverChargeMax);

		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 8)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 21;
            Item.height = 21;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 18, 0, 0);
            Item.rare = ItemRarityID.Cyan;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().HasPowerBank = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentStardust, 2);
			recipe.AddIngredient(ItemID.FragmentVortex, 2);
			recipe.AddIngredient(ModContent.ItemType<CarBattery>());
			recipe.AddIngredient(ModContent.ItemType<Overcharger>());
			recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 12);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
		}
	}
}