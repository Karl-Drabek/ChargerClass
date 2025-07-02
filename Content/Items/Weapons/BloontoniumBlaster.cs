using ChargerClass.Content.Items.Ammo;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class BloontoniumBlaster : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 54;
		Item.height = 22;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Pink;
		Item.value = Item.sellPrice(0, 22, 0, 0);

		Item.useTime = 22;
		Item.UseSound = SoundID.Item1;

		chargeAmount = 180;
		Item.damage = 11;
		Item.crit = 12;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<BloontoniumBlasterHoldout>();
		Item.shootSpeed = 16f;
		Item.useAmmo = ModContent.ItemType<BloontoniumDart>();

		ticsBetweenShots = 2;
		repeatShot = true;
		innacuracy = 5;

		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<DartlingGun>());
		recipe.AddIngredient(ModContent.ItemType<DepleatedBloontonium>(), 40);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
