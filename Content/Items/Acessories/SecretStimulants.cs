using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Acessories
{
	public class SecretStimulants : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SecretStimulants");
			Tooltip.SetDefault("Chance to increase charge level by 1 (crit chance)");
		}

		public override void SetDefaults()
		{
            Item.width = 19;
            Item.height = 18;
            Item.maxStack = 1;
            Item.value = 1000000;
            Item.rare = 6;	
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().SecretStimulants = true;
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