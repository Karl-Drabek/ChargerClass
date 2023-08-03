using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class BreathingAid : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BreathingAid");
			Tooltip.SetDefault("Increase max charge and charge speed by 25%. Adds a keybind to automatically increase charge for blowing weapons by 2 levels. Increase projectile speed by 25% and damage by 3% for blowing weapons.");
		}

		public override void SetDefaults()
		{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().BreathingAid = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}