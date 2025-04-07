using ChargerClass.Content.Items.Ammo;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class DartlingGun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 54;
		Item.height = 22;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;
		Item.value = Item.buyPrice(0, 14, 0, 0);

		Item.useTime = 24;
		Item.UseSound = SoundID.Item1;

		chargeAmount = 200;
		Item.damage = 68;
		Item.crit = 4;
		Item.knockBack = 0f;

		Item.shoot = ModContent.ProjectileType<DartlingGunHoldout>();
		Item.shootSpeed = 14f;
		Item.useAmmo = ModContent.ItemType<MonkeyDart>();

		ticsBetweenShots = 2;
		repeatShot = true;
		innacuracy = 5;

		Item.noUseGraphic = true;
	}
}
