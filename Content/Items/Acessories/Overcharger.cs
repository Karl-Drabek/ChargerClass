using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class Overcharger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Overcharger");
			Tooltip.SetDefault("Gain 3% bonus max Charge for each shot fired at full charge (max 3). This effect resets if a shot is not fired to full charge or after 3 seconds.");
		
			
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(20, 4)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 19;
            Item.height = 19;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().CarBattery = true;
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