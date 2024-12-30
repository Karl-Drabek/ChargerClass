using ChargerClass.Content.Projectiles.Holdouts.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class DemoniteCrossbow : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 37;
		Item.height = 17;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 28;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 36, 0);

		Item.damage = 42;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<DemoniteCrossbowHoldout>();
		Item.shootSpeed = 12f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.DemoniteBar, 8);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
