using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class PhantomBlowgun : ChargedWeapon
{
	public const int DAMAGE_INCREASE = 7;
	public const int CRIT_INCREASE = 14;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CRIT_INCREASE, DAMAGE_INCREASE);
	public override void SafeSetDefaults()
	{
		Item.width = 88;
		Item.height = 22;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Pink;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 16, 40, 0);
		Item.useTime = 28;

		Item.damage = 562;
		Item.crit = 2;
		Item.knockBack = 4f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<PhantomBlowgunHoldout>();
		Item.shootSpeed = 18f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.SoulofFright, 4);
		recipe.AddIngredient(ItemID.SoulofNight, 4);
		recipe.AddIngredient(ItemID.SpectreBar, 10);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
