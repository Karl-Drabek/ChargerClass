using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class CompoundBow : ChargedWeapon
{
	public static readonly int VelocityIncrease = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(VelocityIncrease);

	public override void SafeSetDefaults()
	{
		Item.width = 28;
		Item.height = 72;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 450;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 6, 90);

		Item.damage = 16;
		Item.crit = 5;
		Item.knockBack = 0f;
		Item.useTime = 26;

		Item.shoot = ModContent.ProjectileType<CompoundBowHoldout>();
		Item.shootSpeed = 12f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddRecipeGroup(ChargerClassGeneralSystem.CopperBarRecipeGroup, 6);
		recipe.AddRecipeGroup(ChargerClassGeneralSystem.SilverBarRecipeGroup, 4);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
