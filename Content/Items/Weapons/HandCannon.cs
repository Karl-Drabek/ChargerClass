using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class HandCannon : ChargedWeapon
{
	public static readonly int FragChance = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(FragChance);

	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 650;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 5, 50);
		Item.useTime = 32;

		Item.damage = 112;
		Item.crit = 5;
		Item.knockBack = 10f;

		Item.shoot = ModContent.ProjectileType<HandCannonHoldout>();
		Item.shootSpeed = 8f;
		Item.useAmmo = ModContent.ItemType<Ammo.MiniCannonball>();
	}
}
