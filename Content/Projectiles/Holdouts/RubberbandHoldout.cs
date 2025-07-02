using ChargerClass.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class RubberbandHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override bool Shoot(
		Player player,
		Item item,
		EntitySource_ItemUse_WithAmmo source,
		Vector2 position,
		Vector2 velocity,
		int type,
		int damage,
		float knockback,
		int chargeLevel
	)
	{
		if (Main.rand.NextBool(Utils.Clamp(chargeLevel * Rubberband.SnapChance, 0, 100), 100))
		{
			player.Hurt(PlayerDeathReason.ByPlayerItem(player.whoAmI, item), 1, -player.direction);
			return false;
		}
		return true;
	}

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
		type = ModContent.ProjectileType<RubberbandProjectile>();
	}
}
