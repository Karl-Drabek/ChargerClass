using ChargerClass.Content.Projectiles.Holdouts.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class LeadCrossbow : ChargedWeapon
{
	public static readonly int KnockbackIncrease = 15;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(KnockbackIncrease);

	public override void SafeSetDefaults()
	{
		Item.width = 37;
		Item.height = 13;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 500;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 4, 20);

		Item.damage = 40;
		Item.crit = 0;
		Item.knockBack = 6f;
		Item.useTime = 33;

		Item.shoot = ModContent.ProjectileType<LeadCrossbowHoldout>();
		Item.shootSpeed = 10f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.LeadBar, 7);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
