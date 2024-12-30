using ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class OrichalcumBlowgun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 84;
		Item.height = 20;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 20, 0);
		Item.useTime = 28;

		Item.damage = 362;
		Item.crit = 0;
		Item.knockBack = 2f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<OrichalcumBlowgunHoldout>();
		Item.shootSpeed = 14f;
		Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.OrichalcumBar, 12);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
