using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class Refractinator : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 60;
		Item.height = 30;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Yellow;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 5, 0);
		Item.useTime = 24;

		Item.damage = 280;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<RefractinatorHoldout>();
		Item.shootSpeed = 15f;
		noAmmoProjectile = ModContent.ProjectileType<RefractinatorLaser>();
	}
}
