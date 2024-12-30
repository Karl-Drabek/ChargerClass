using ChargerClass.Content.Projectiles.Holdouts.Blowers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers;

public class BagpipeBlaster : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 52;
		Item.height = 42;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 90;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 20, 55);
		Item.useTime = 42;
		ticsBetweenShots = 3;
		repeatShot = true;

		Item.damage = 6;
		Item.crit = 0;
		Item.knockBack = 1f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<BagpipeBlasterHoldout>();
		Item.shootSpeed = 12f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Leather, 5);
		recipe.AddIngredient(ItemID.BreathingReed, 1);
		recipe.AddIngredient(ItemID.Blowgun, 1);
		recipe.AddIngredient(ModContent.ItemType<Balloon>(), 1);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}
