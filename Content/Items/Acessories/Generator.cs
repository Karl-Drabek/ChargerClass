using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class Generator : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Generator");
			Tooltip.SetDefault("Increase Charge speed by 15%. Keep 10% charge on crits. Enemies have a chance to drop charge on death.");


			
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(30, 4)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 23;
            Item.height = 22;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().Generator = true;
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