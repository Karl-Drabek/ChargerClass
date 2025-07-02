using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class AdamantiteBlowgun : ChargedWeapon
{
	public const int DAMAGE_INCREASE = 6;
	public const int HATE_DAMAGE_INCREASE = 4;
	public override LocalizedText Tooltip =>
		base.Tooltip.WithFormatArgs(DAMAGE_INCREASE, HATE_DAMAGE_INCREASE);

	public override void SafeSetDefaults()
	{
		Item.width = 86;
		Item.height = 20;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 40, 0);
		Item.useTime = 26;

		Item.damage = 39;
		Item.crit = 0;
		Item.knockBack = 3f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<AdamantiteBlowgunHoldout>();
		Item.shootSpeed = 16f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.AdamantiteBar, 12);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
