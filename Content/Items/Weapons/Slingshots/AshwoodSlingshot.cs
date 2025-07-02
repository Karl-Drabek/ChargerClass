using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class AshwoodSlingshot : ChargedWeapon
{
	public static readonly int HellfireChance = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(HellfireChance);

	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 300;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 20;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 20);

		Item.damage = 30;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<AshwoodSlingshotHoldout>();
		Item.shootSpeed = 6f;
		Item.useAmmo = ModContent.ItemType<Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.AshWood, 10);
		recipe.AddIngredient(ModContent.ItemType<Rubber>(), 5);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}
