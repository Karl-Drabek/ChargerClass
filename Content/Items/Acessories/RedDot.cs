using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class RedDot : ModItem
{
	public static readonly int CritChanceIncrease = 1;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1, 80, 0);
            Item.rare = ItemRarityID.LightRed;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasRedDot = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BlackLens, 6);
		recipe.AddRecipeGroup(ChargerClassGeneralSystem.TitaniumBarRecipeGroup, 6);
		recipe.AddIngredient(ItemID.SoulofNight, 2);
		recipe.AddIngredient(ItemID.SoulofSight, 2);
		recipe.AddIngredient(ItemID.SoulofLight, 2);
		recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
}