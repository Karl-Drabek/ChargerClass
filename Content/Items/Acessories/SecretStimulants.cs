using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Consumables;

namespace ChargerClass.Content.Items.Acessories;

public class SecretStimulants : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
	}
	public override void SetDefaults()
	{
            Item.width = 19;
            Item.height = 18;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 3, 60, 0);
            Item.rare =  ItemRarityID.LightRed;
		Item.accessory = true;
	}

	public override void UpdateAccessory(Player player, bool hideVisual) {
		player.GetModPlayer<ChargeModPlayer>().SecretStimulants = true;
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<StaminaPotion>(), 6);
		recipe.AddIngredient(ModContent.ItemType<ChargePotion>(), 6);
		recipe.AddIngredient(ModContent.ItemType<ImpatiencePotion>(), 6);
            recipe.AddIngredient(ItemID.CrystalShard, 8);
		recipe.AddIngredient(ItemID.PixieDust, 6);
		recipe.AddIngredient(ItemID.UnicornHorn, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}