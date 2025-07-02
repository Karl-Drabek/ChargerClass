using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class LongBow : ChargedWeapon
{
	public static readonly int CritChanceIncrease = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncrease);

	public override void SafeSetDefaults()
	{
		Item.width = 16;
		Item.height = 58;
		Item.scale = 0.9f;
		Item.rare = ItemRarityID.Blue;

		chargeAmount = 450;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 0, 30);

		Item.damage = 34;
		Item.crit = 4;
		Item.knockBack = 0f;
		Item.useTime = 32;

		Item.shoot = ModContent.ProjectileType<LongBowHoldout>();
		Item.shootSpeed = 12f;
		Item.useAmmo = AmmoID.Arrow;
	}
}
