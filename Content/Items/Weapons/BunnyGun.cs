using ChargerClass.Content.Items.Ammo;
using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class BunnyGun : ChargedWeapon
{
	public override void SafeSetStaticDefualts()
	{
		ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
	}

	public override void SafeSetDefaults()
	{
		Item.width = 88;
		Item.height = 42;
		Item.scale = 1f;
		Item.rare = -12;

		chargeAmount = 100;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 10, 40, 0);
		Item.useTime = 12;

		ticsBetweenShots = 3;
		repeatShot = true;
		innacuracy = 3;

		Item.shoot = ModContent.ProjectileType<BunnyGunHoldout>();
		Item.shootSpeed = 10f;
		Item.useAmmo = ModContent.ItemType<SoulofBunnies>();
		ignoreAmmo = true;
	}

	public override Vector2? HoldoutOffset() => new Vector2(-6f, 8f);
}
