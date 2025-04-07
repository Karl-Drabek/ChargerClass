using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class RubberbandGunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		type = ModContent.ProjectileType<RubberbandProjectile>();
	}
}