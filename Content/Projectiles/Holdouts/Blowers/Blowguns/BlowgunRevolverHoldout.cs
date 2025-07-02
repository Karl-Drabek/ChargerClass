using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class BlowgunRevolverHoldout : ChargeWeaponHoldout
{
	public override void SafeModifyShootStats(
		Player player,
		Item item,
		ref Vector2 position,
		ref Vector2 velocity,
		ref int type,
		ref int damage,
		ref float knockback,
		int chargeLevel
	)
	{
		knockback += chargeLevel * BlowgunRevolver.KNOCKBACK_INCREASE;
		Vector2 normal = velocity;
		normal.Normalize();
		player.velocity -= velocity / 10;
	}

	public override void SafeSetDefaults() { }
}
