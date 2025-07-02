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
	public override void SafeSetDefaults()
	{
		Item.width = 218;
		Item.height = 86;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Red;

		chargeAmount = 100;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item79;
		Item.value = Item.buyPrice(0, 8, 0, 0);
		Item.useTime = 20;

		Item.damage = 30;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<RailRailGunHoldout>();
		Item.shootSpeed = 1f;
		noAmmoProjectile = ModContent.ProjectileType<RailRailGunLaser>();
		Item.noUseGraphic = true;
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

	public override bool? UseItem(Player player)
	{
		if (player.mount.Type != ModContent.MountType<RailRailGunMount>())
		{
			player.mount.SetMount(ModContent.MountType<RailRailGunMount>(), player);
		}
		return true;
	}
}
