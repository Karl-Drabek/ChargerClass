using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class ConsumingLens : ChargedWeapon
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

		Item.shoot = ModContent.ProjectileType<ConsumingLensHoldout>();
		noAmmoProjectile = ModContent.ProjectileType<ConsumingLensLaser>();
		Item.shootSpeed = 16f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.BlackLens, 4);
		recipe.AddIngredient(ItemID.Lens, 4);
		recipe.AddIngredient(ItemID.DemoniteBar, 6);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}