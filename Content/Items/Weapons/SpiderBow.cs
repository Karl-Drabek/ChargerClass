using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SpiderBow : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 40;
		Item.height = 70;
		Item.scale = 0.8f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 240;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.useTime = 29;

		Item.damage = 43;
		Item.crit = 8;
		Item.knockBack = 2f;

		Item.shoot = ModContent.ProjectileType<SpiderBowHoldout>();
		Item.shootSpeed = 16f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.SpiderFang, 28);
		recipe.AddIngredient(ModContent.ItemType<CompoundBow>());
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
