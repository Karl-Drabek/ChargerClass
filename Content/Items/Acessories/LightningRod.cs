using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Acessories;

public class LightningRod : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(60, 2)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults()
	{
            Item.width = 17;
            Item.height = 21;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 0, 12, 0);
            Item.rare =  ItemRarityID.Blue;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().LightningRod = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.CopperBarRecipeGroup, 12);
		recipe.AddIngredient(ItemID.Wire, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}