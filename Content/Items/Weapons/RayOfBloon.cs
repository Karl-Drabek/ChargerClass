using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;

namespace ChargerClass.Content.Items.Weapons;

public class RayOfBloon : ChargedWeapon
{

	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;

		chargeAmount = 200;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 40);
		Item.useTime = 42;

		Item.damage = 5;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<RayOfBloonHoldout>();
		noAmmoProjectile = ModContent.ProjectileType<RayOfBloonLaser>();
		Item.shootSpeed = 16f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<LaserDartlingGun>());
		recipe.AddIngredient(ItemID.FragmentSolar, 16);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}