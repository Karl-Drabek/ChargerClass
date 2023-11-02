using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Consumables;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class Exhaler : ModItem
{
	public static readonly int ChargeDamageIncrease = 2;
	public static readonly int ChargeVelocityIncrease = 25;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeVelocityIncrease, ChargeDamageIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 10;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 16, 0);
            Item.rare =  ItemRarityID.Blue;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasExhaler = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bottle);
		recipe.AddIngredient(ModContent.ItemType<Rubber>());
		recipe.AddIngredient(ModContent.ItemType<ChargePotion>(), 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
	}
}