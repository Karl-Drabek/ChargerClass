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
			DisplayName.SetDefault("Extension Cord");
			Tooltip.SetDefault("Increase Charge speed by 10%. Keep 10% charge on crits.");
		}

		public override void SetDefaults()
		{
            Item.width = 19;
            Item.height = 17;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().ExtensionCord = true;
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