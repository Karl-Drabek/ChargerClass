using ChargerClass.Content.Items.Ammo;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class HydraRocketLauncher : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 54;
		Item.height = 26;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Red;
		Item.value = Item.sellPrice(0, 18, 0, 0);

		Item.useTime = 36;
		Item.UseSound = SoundID.Item1;

		chargeAmount = 180;
		Item.damage = 10;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<HydraRocketLauncherHoldout>();
		Item.shootSpeed = 16f;
		Item.useAmmo = ModContent.ItemType<RocketPod>();

		ticsBetweenShots = 2;
		repeatShot = true;
		innacuracy = 5;

		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<BloontoniumBlaster>());
		recipe.AddIngredient(ItemID.ProximityMineLauncher);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
