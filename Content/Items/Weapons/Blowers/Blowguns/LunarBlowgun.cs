using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class LunarBlowgun : ChargedWeapon
{
	public const int DAMAGE_INCREASE = 8;
	public const int CRIT_INCREASE = 16;
	public const int KNOCKBACK_INCREASE = 1;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_INCREASE, DAMAGE_INCREASE, KNOCKBACK_INCREASE);
	public override void SafeSetDefaults()
	{
		Item.width = 84;
		Item.height = 56;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.Red;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 18, 0, 0);
		Item.useTime = 22;

		Item.damage = 75;
		Item.crit = 4;
		Item.knockBack = 6f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<LunarBlowgunHoldout>();
		Item.shootSpeed = 20f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.LunarBar, 14);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
