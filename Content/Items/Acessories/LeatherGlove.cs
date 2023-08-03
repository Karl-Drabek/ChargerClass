using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class LeatherGlove : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leather Glove");
			Tooltip.SetDefault("Critcial Hits deal 2% extra damage per Charge level");
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
			player.GetModPlayer<ChargeModPlayer>().LeatherGlove = true;
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