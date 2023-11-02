using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Items.Placeable;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Acessories;

public class AAABattery : ModItem
{
	public static readonly int maxChargeIncrease = 5;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(maxChargeIncrease);
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(30, 4)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
            Item.width = 9;
            Item.height = 20;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 46, 0);
            Item.rare = ItemRarityID.Green;	
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().HasAAABattery = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.CopperBarRecipeGroup, 12);
		recipe.AddIngredient(ModContent.ItemType<ElectrudiumBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}