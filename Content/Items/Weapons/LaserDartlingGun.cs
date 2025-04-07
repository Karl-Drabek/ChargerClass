using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class LaserDartlingGun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 82;
		Item.height = 36;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Yellow;
		Item.value = Item.sellPrice(0, 14, 0, 0);

		Item.useTime = 22;
		Item.UseSound = SoundID.Item1;

		chargeAmount = 180;
		Item.damage = 94;
		Item.crit = 12;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<LaserDartlingGunHoldout>();
		Item.shootSpeed = 16f;
		noAmmoProjectile = ProjectileID.RayGunnerLaser;

		ticsBetweenShots = 2;
		repeatShot = true;
		innacuracy = 5;

		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<BloontoniumBlaster>());
		recipe.AddIngredient(ItemID.LihzahrdPowerCell, 4);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
