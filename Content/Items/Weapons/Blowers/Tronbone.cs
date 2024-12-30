using ChargerClass.Content.Projectiles.Holdouts.Blowers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers;

public class Tronbone : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 76;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 10, 0);
		Item.useTime = 32;
		repeatShot = true;

		Item.damage = 32;
		Item.crit = 2;
		Item.knockBack = 1f;

		blowWeapon = true;
		Item.shoot = ModContent.ProjectileType<TronboneHoldout>();
		Item.shootSpeed = 8f;
		noAmmoProjectile = ModContent.ProjectileType<Projectiles.TronboneSonicProjectile>();
		ticsBetweenShots = 1;
	}
}
