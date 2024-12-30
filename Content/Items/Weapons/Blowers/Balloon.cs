using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts.Blowers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers;

public class Balloon : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 300;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 3);
		Item.useTime = 24;

		Item.damage = 33;
		Item.crit = 2;
		Item.knockBack = 2f;
		Item.maxStack = 999;
		Item.consumable = true;
		blowWeapon = true;
		shootSelf = true;

		Item.shoot = ModContent.ProjectileType<BalloonHoldout>();
		Item.shootSpeed = 4f;
		noAmmoProjectile = ModContent.ProjectileType<BalloonProjectile>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Rubber>(), 3);
		recipe.AddTile(TileID.Furnaces);
		recipe.Register();
	}
}
