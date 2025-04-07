using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SupremeCalamari : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 26;
		Item.height = 82;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Red;

		chargeAmount = 500;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 22, 0, 0);
		Item.useTime = 54;

		Item.damage = 1470;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<SupremeCalamariHoldout>();
		Item.shootSpeed = 20f;
		noAmmoProjectile = ModContent.ProjectileType<Projectiles.SupremeCalamariProjectile>();

		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<PremeCalamari>());
		recipe.AddIngredient(ItemID.LunarBar, 16);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
