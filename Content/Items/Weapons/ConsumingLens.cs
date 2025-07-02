using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class ConsumingLens : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 30;
		Item.height = 34;
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

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);
}