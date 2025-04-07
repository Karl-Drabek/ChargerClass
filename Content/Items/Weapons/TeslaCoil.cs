using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class TeslaCoil : ChargedWeapon
{

	public override void SafeSetDefaults()
	{
		Item.width = 60;
		Item.height = 28;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Yellow;

		chargeAmount = 500;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.useTime = 25;

		Item.damage = 340;
		Item.crit = 6;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<TeslaCoilHoldout>();
		Item.shootSpeed = 1f;
	}
}
