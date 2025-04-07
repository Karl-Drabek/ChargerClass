using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class BlowgunRevolver : ChargedWeapon
{
	public const int KNOCKBACK_INCREASE = 2;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(KNOCKBACK_INCREASE);
	public override void SafeSetDefaults()
	{
		Item.width = 82;
		Item.height = 20;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.useTime = 26;
		ticsBetweenShots = 4;
		repeatShot = true;

		Item.damage = 286;
		Item.crit = 6;
		Item.knockBack = 0f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<BlowgunRevolverHoldout>();
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddRecipeGroup(ChargerClassGeneralSystem.HardmodeOreBlowguns);
		recipe.AddIngredient(ItemID.Revolver);
		recipe.AddTile(TileID.AdamantiteForge);
		recipe.Register();
	}
}
