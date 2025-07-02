using ChargerClass.Content.Items.Ammo;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class DragonsBreath : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 16;
		Item.height = 30;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 50;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 2);
		Item.useTime = 32;

		Item.damage = 6;
		Item.crit = 0;
		Item.knockBack = 0f;
		Item.maxStack = 1;
		Item.useAmmo = ModContent.ItemType<Kerosene>();
		blowWeapon = true;

		ticsBetweenShots = 3;
		repeatShot = true;

		Item.shoot = ModContent.ProjectileType<DragonsBreathHoldout>();
		Item.shootSpeed = 12f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.MolotovCocktail);
		recipe.AddIngredient(ModContent.ItemType<ConcentratedGelSolution>());
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
