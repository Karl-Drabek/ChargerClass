using ChargerClass.Content.Items.Weapons.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class SilverCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		velocity *= 1 + chargeLevel * SilverCrossbow.StatIncrease / 100f;
	}

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * SilverCrossbow.StatIncrease;
	}
}
