using ChargerClass.Content.Items.Weapons.Blowers;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class RocketBalloon : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 60;
		Item.height = 30;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Pink;

		chargeAmount = 500;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 14, 0, 0);
		Item.useTime = 26;

		Item.damage = 200;
		Item.crit = 10;
		Item.knockBack = 0f;
		Item.maxStack = 999;

		Item.consumable = true;
		shootSelf = true;

		Item.shoot = ModContent.ProjectileType<RocketBalloonHoldout>();
		Item.shootSpeed = 14f;
		noAmmoProjectile = ModContent.ProjectileType<RocketBalloonProjectile>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.SoulofFright, 16);
		recipe.AddIngredient(ModContent.ItemType<Balloon>());
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
