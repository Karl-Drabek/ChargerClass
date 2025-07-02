using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class MolotovMortar : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 58;
		Item.height = 20;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 420;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 2, 30);

		Item.damage = 4;
		Item.crit = 0;
		Item.knockBack = 0f;
		Item.useTime = 48;

		ticsBetweenShots = 5;
		repeatShot = true;

		Item.shoot = ModContent.ProjectileType<MolotovMortarHoldout>();
		Item.shootSpeed = 5f;
		Item.useAmmo = ItemID.MolotovCocktail;
	}

	public override Vector2? HoldoutOffset() => new Vector2(-10f, 6f);
}
