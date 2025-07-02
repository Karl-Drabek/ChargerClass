using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class ChlorophyteBlowgun : ChargedWeapon
{
	public const int DAMAGE_INCREASE = 6;
	public const int CRIT_INCREASE = 12;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_INCREASE, DAMAGE_INCREASE);
	public override void SafeSetDefaults()
	{
		Item.width = 86;
		Item.height = 32;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.Lime;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 4, 80, 0);
		Item.useTime = 30;

		Item.damage = 44;
		Item.crit = 2;
		Item.knockBack = 4f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<ChlorophyteBlowgunHoldout>();
		Item.shootSpeed = 14f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
