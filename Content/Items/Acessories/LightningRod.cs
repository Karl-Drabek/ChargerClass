using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class LightningRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lightning Rod");
			Tooltip.SetDefault("Enemies have a chance to drop charge on death.");


			
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(60, 2)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 17;
            Item.height = 21;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().LightningRod = true;
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