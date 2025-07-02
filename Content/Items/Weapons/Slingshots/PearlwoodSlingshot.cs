using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class PearlwoodSlingshot : ChargedWeapon
{
	public static readonly int ConfuseChance = 15;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ConfuseChance);

	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 250;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 22;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 20);

		Item.damage = 42;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<PearlwoodSlingshotHoldout>();
		Item.shootSpeed = 6f;
		Item.useAmmo = ModContent.ItemType<Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Pearlwood, 10);
		recipe.AddIngredient(ModContent.ItemType<Rubber>(), 5);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}
