using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Ammo;

public class Kerosene : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 99;
	}

	public override void SetDefaults()
	{
		Item.width = 10;
		Item.height = 32;

		Item.damage = 5;
		Item.DamageType = ChargerDamageClass.Instance;

		Item.maxStack = 999;
		Item.consumable = true;
		Item.knockBack = 1f;
		Item.value = Item.sellPrice(0, 0, 0, 4);
		Item.rare = ItemRarityID.White;
		Item.shoot = ProjectileID.PurificationPowder;

		Item.ammo = Item.type;
	}

	public override void OnConsumedAsAmmo(Item weapon, Player player){
		player.GetModPlayer<ChargeModPlayer>().UseKarosene();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(100);
		recipe.AddIngredient(ItemID.Gel, 100);
		recipe.AddIngredient(ModContent.ItemType<ConcentratedGelSolution>(), 1);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}