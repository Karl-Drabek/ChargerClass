using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class MultiShot : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 60;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;

		chargeAmount = 155;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 34;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 4, 50, 0);

		Item.damage = 24;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<MultiShotHoldout>();
		Item.shootSpeed = 9f;
		Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Slingshots.TripleShot>(), 3);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
