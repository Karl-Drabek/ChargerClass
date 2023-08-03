using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class PowerBank : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PowerBank");
			Tooltip.SetDefault("Increase Max charge by 15%. Gain 3% bonus max Charge for each shot fired at full charge (max 3). This resets if a shot is not fired to full charge or after 3 seconds. Crits have a chance to stun enemies.");
		
			
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 8)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		}

		public override void SetDefaults()
		{
            Item.width = 21;
            Item.height = 21;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().PowerBank = true;
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