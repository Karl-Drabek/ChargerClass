using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class Rubberband : ChargedWeapon
{
	public static readonly int SnapChance = 1;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SnapChance);

	public override void SafeSetDefaults()
	{
		Item.width = 36;
		Item.height = 22;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 300;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.useTime = 12;
		Item.value = Item.sellPrice(0, 0, 0, 1);

		Item.damage = 14;
		Item.crit = 0;
		Item.knockBack = 0f;
		Item.maxStack = 999;

		Item.consumable = true;
		shootSelf = true;

		Item.shoot = ModContent.ProjectileType<RubberbandHoldout>();
		Item.shootSpeed = 6f;
		Item.ammo = Item.type;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Rubber>(), 1);
		recipe.AddTile(TileID.Furnaces);
		recipe.Register();
	}
}
