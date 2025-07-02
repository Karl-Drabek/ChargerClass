using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SuperSlimer : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.Green;

		chargeAmount = 110;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 31, 0);
		Item.useTime = 30;

		ticsBetweenShots = 4;
		repeatShot = true;

		Item.damage = 4;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<SuperSlimerHoldout>();
		Item.shootSpeed = 8f;
		Item.useAmmo = ModContent.ItemType<Ammo.BottledSlime>();
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Items.Weapons.SuperSoaker>(), 1);
		recipe.AddIngredient(ItemID.SlimeGun, 1);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}

	public override Vector2? HoldoutOffset() => new Vector2(-4f, 2f);
}
