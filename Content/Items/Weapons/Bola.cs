using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class Bola : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 32;
		Item.height = 44;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 300;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 16;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 2);

		Item.damage = 17;
		Item.crit = 0;
		Item.knockBack = 0f;
		Item.maxStack = 999;
		Item.consumable = true;
		shootSelf = true;

		Item.shoot = ModContent.ProjectileType<BolaHoldout>();
		Item.shootSpeed = 10f;
		noAmmoProjectile = ModContent.ProjectileType<Projectiles.BolaProjectile>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.StoneBlock, 2);
		recipe.AddRecipeGroup(RecipeGroupID.Wood, 4);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}
