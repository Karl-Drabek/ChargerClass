using ChargerClass.Content.Projectiles.Holdouts.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class HellfireCrossbow : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 37;
		Item.height = 13;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 300;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 27;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 48, 0);

		Item.damage = 83;
		Item.crit = 0;
		Item.knockBack = 3f;

		Item.shoot = ModContent.ProjectileType<HellfireCrossbowHoldout>();
		Item.shootSpeed = 13f;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ItemID.HellstoneBar, 14);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
