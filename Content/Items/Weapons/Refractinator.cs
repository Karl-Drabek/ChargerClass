using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class Refractinator : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 124;
		Item.height = 38;
		Item.scale = 0.75f;
		Item.rare = ItemRarityID.Yellow;

		chargeAmount = 600;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 5, 0);
		Item.useTime = 24;

		Item.damage = 52;
		Item.crit = 0;
		Item.knockBack = 1f;

		ticsBetweenShots = 3;
		repeatShot = true;
		innacuracy = 1;

		Item.shoot = ModContent.ProjectileType<RefractinatorHoldout>();
		Item.shootSpeed = 15f;
		noAmmoProjectile = ModContent.ProjectileType<RefractinatorLaser>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(-14f, -4f);
}
