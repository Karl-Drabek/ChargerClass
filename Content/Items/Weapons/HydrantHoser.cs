using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class HydrantHoser : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 64;
		Item.height = 28;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Yellow;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 5, 0);
		Item.useTime = 26;

		Item.damage = 355;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<HydrantHoserHoldout>();
		Item.shootSpeed = 14f;
		noAmmoProjectile = ModContent.ProjectileType<HydrantHoserLaser>();
	}
}
