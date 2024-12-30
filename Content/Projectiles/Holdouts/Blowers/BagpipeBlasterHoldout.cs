using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers;

public class BagpipeBlasterHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		Vector2 dir = velocity.RotatedBy(MathHelper.ToRadians(90));
		dir.Normalize();
		position += (float)Main.rand.NextDouble() * 18 * dir * player.direction;
	}
}
