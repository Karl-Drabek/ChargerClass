using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class ShadewoodSlingshot : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 450;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 26;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 20);

		Item.damage = 12;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<ShadeWoodSlingshotHoldout>();
		Item.shootSpeed = 6f;
		Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(0f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Shadewood, 10);
		recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}
