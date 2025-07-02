using ChargerClass.Content.Items.Placeable;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class MegaMortar : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 46;
		Item.height = 70;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Yellow;

		chargeAmount = 500;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 14, 0, 0);
		Item.useTime = 36;

		Item.damage = 488;
		Item.crit = 0;
		Item.knockBack = 6f;

		Item.shoot = ModContent.ProjectileType<MegaMortarHoldout>();
		Item.shootSpeed = 20f;
		noAmmoProjectile = ModContent.ProjectileType<MegaMortarProjectile>();

		Item.noUseGraphic = true;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<HandCannon>());
		recipe.AddIngredient(ModContent.ItemType<MolotovMortar>());
		recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 20);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
