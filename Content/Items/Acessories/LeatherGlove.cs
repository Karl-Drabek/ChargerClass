using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories
{
	public class LeatherGlove : ModItem
	{
		public static readonly int BonusCritDamage = 2;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(BonusCritDamage);
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}
		public override void SetDefaults()
		{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 17, 20);
            Item.rare = ItemRarityID.White;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<ChargeModPlayer>().LeatherGlove = true;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Leather, 12);
			recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}