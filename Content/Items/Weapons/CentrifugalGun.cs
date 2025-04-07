using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class CentrifugalGun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 82;
		Item.height = 36;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;
		Item.value = Item.sellPrice(0, 0, 1, 40);

		Item.useTime = 40;
		Item.UseSound = SoundID.Item1;

		chargeAmount = 225;
		Item.damage = 73;
		Item.crit = 0;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<CentrifugalGunHoldout>();
		Item.shootSpeed = 15f;
		Item.useAmmo = AmmoID.Bullet;

		ticsBetweenShots = 5;
		repeatShot = true;
		innacuracy = 5;

		Item.noUseGraphic = true;
	}
}
