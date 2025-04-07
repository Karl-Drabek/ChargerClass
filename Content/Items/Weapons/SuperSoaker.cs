using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SuperSoaker : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;

		chargeAmount = 90;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 90);
		Item.useTime = 26;

		ticsBetweenShots = 4;
		repeatShot = true;

		Item.damage = 5;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<SuperSoakerHoldout>();
		Item.shootSpeed = 8f;
		Item.useAmmo = ItemID.BottledWater;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Rubber>(), 200);
		recipe.AddIngredient(ItemID.WaterGun, 1);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
