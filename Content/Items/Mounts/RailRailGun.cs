using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Mounts;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Mounts;

public class RailRailGun : ChargedWeapon
{
	public override void SafeSetDefaults() {
		Item.width = 218;
		Item.height = 86;
		Item.useTime = 20;
		Item.useAnimation = 20;
		chargeAmount = 100;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.rare = ItemRarityID.Red;
		Item.UseSound = SoundID.Item79;
		Item.mountType = ModContent.MountType<ExampleMount>();
		Item.shoot = ModContent.ProjectileType<RailRailGunHoldout>();
		Item.shootSpeed = 1f;
		Item.noUseGraphic = true;
		noAmmoProjectile = ModContent.ProjectileType<RailRailGunLaser>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Railgun>());
		recipe.AddIngredient(ItemID.MechanicalWagonPiece);
		recipe.AddIngredient(ItemID.FragmentVortex, 14);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
