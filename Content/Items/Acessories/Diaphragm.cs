using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class Diaphragm : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(30, 3)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 14;
            Item.height = 17;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;	
			Item.accessory = true;
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