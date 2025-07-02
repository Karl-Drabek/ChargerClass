using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class DragonsBreathHoldout : ChargeWeaponHoldout
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
		Projectile flame1 = Projectile.NewProjectileDirect(
			source,
			position,
			velocity.RotatedByRandom(MathHelper.ToRadians(5)),
			ProjectileID.Flames,
			damage,
			knockback
		);
		return false;
	}

	public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset)
	{
		muzzleOffset *= 20;
	}
}
