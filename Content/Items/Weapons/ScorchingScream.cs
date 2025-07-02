using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class ScorchingScream : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 58;
		Item.height = 22;
		Item.scale = .75f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 250;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 1, 25);
		Item.useTime = 28;

		Item.damage = 28;
		Item.crit = 0;
		Item.knockBack = 3f;

		ticsBetweenShots = 4;
		repeatShot = true;
		innacuracy = 10;

		Item.shoot = ModContent.ProjectileType<ScorchingScreamHoldout>();
		Item.shootSpeed = 6f;
		noAmmoProjectile = ProjectileID.FlamesTrap;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.HellstoneBar, 14);
		recipe.AddIngredient(ModContent.ItemType<Bellows>(), 1);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 2f);
}
