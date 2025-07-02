using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class MythrilBlowgun : ChargedWeapon
{
	public const int CRIT_INCREASE = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_INCREASE);
	public override void SafeSetDefaults()
	{
		Item.width = 84;
		Item.height = 20;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 80, 0);
		Item.useTime = 27;

		Item.damage = 35;
		Item.crit = 0;
		Item.knockBack = 2f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<MythrilBlowgunHoldout>();
		Item.shootSpeed = 14f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.MythrilBar, 10);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
