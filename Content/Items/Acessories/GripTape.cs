using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class GripTape : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grip Tape");
			Tooltip.SetDefault("Deal 1% extra damage per charge level");
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
			player.GetModPlayer<ChargeModPlayer>().GripTape = true;
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