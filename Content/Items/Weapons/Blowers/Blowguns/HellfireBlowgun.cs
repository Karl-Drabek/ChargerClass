using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class HellfireBlowgun : ChargedWeapon
{
	public static readonly int CritChanceIncreases = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncreases);

	public override void SafeSetDefaults()
	{
		Item.width = 82;
		Item.height = 20;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 25, 0);

		Item.damage = 26;
		Item.crit = 6;
		Item.knockBack = 4f;
		Item.useTime = 26;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<HellfireBlowgunHoldout>();
		Item.shootSpeed = 16f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.HellstoneBar, 10);
		recipe.AddIngredient(ItemID.Blowgun, 1);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
