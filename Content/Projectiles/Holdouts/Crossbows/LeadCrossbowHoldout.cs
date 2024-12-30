using ChargerClass.Content.Items.Weapons.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class LeadCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		knockback *= chargeLevel * (LeadCrossbow.KnockbackIncrease / 100f + 1);
	}
}
