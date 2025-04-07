using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class RubberbandGun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 220;
		Item.useTime = 32;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 1, 20);

		ticsBetweenShots = 8;
		repeatShot = true;
		innacuracy = 2;

		Item.damage = 2;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<RubberbandGunHoldout>();
		Item.shootSpeed = 4f;
		Item.useAmmo = ModContent.ItemType<Rubberband>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Wood, 15);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
