using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SnailGun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 60;
		Item.height = 30;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 500;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 12, 60);
		Item.useTime = 24;

		Item.damage = 420;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<SnailGunHoldout>();
		Item.shootSpeed = 14f;
		noAmmoProjectile = ModContent.ProjectileType<SnailProjectile>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<SuperSlimer>());
		recipe.AddIngredient(ModContent.ItemType<ExoticEscargot>());
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
