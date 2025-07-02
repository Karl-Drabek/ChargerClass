using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class NectarNailGun : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 0.7f;
		Item.rare = ItemRarityID.Orange;

		chargeAmount = 235;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 2, 0);
		Item.useTime = 22;

		ticsBetweenShots = 3;
		repeatShot = true;

		Item.damage = 7;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<NectarNailGunHoldout>();
		Item.shootSpeed = 12f;
		Item.useAmmo = ModContent.ItemType<Ammo.NectarNail>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(0f, 6f);
}
