using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class PotatoCannon : ChargedWeapon
{
	public static readonly int HotPotatoChance = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(HotPotatoChance);

	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;

		chargeAmount = 400;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 28;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 2, 30);

		Item.damage = 34;
		Item.crit = 0;
		Item.knockBack = 3f;

		Item.shoot = ModContent.ProjectileType<PotatoCannonHoldout>();
		Item.shootSpeed = 8f;
		Item.useAmmo = ModContent.ItemType<Ammo.Potato>();
	}
}
