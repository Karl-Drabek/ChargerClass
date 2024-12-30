using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class ReinforcedSlingshot : ChargedWeapon
{
	public static readonly int DamageIncrease = 3;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DamageIncrease);

	public override void SafeSetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.White;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 26;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 3, 0);

		Item.damage = 22;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<ReinforcedSlingshotHoldout>();
		Item.shootSpeed = 6f;
		Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(0f, 0f);

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe();
		recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Slingshots.WoodSlingshot>(), 1);
		recipe.AddRecipeGroup(RecipeGroupID.IronBar, 4);
		recipe.AddTile(TileID.Anvils);
		recipe.Register();
	}
}
