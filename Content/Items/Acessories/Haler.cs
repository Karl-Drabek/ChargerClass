using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class Haler : ModItem
{
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(Exhaler.ChargeVelocityIncrease, Exhaler.ChargeDamageIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 36;
            Item.height = 40;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 4, 10, 0);
            Item.rare =  ItemRarityID.LightRed;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().Haler = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.TitaniumBarRecipeGroup, 6);
		recipe.AddIngredient(ModContent.ItemType<Exhaler>());
		recipe.AddIngredient(ModContent.ItemType<Inhaler>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
	}
}