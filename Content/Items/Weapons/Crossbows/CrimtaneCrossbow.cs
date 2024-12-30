using ChargerClass.Content.Projectiles.Holdouts.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class CrimtaneCrossbow : ChargedWeapon
{
	public static readonly int DamageIncrease = 7;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DamageIncrease);

	public override void SafeSetDefaults()
	{
		Item.width = 37;
		Item.height = 17;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;

		chargeAmount = 450;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 25;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 36, 0);

		Item.damage = 43;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<CrimtaneCrossbowHoldout>();
		Item.shootSpeed = 11f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.CrimtaneBar, 8);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
