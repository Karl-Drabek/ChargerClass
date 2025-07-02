using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using ChargerClass.Content.Projectiles.Rocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class EbonwoodSlingshot : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 350;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 28;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 20);

		Item.damage = 26;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<EbonwoodSlingshotHoldout>();
		Item.shootSpeed = 6f;
		Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.Ebonwood, 10);
		recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
		recipe.AddTile(TileID.WorkBenches);
		recipe.Register();
	}
}
