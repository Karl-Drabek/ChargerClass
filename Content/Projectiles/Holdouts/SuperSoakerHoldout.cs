using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class SuperSoakerHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

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
		type = ProjectileID.WaterGun;
	}

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		if (modPlayer.Player.ZoneDesert || modPlayer.Player.ZoneSnow)
			proj.timeLeft = 15;
		proj.friendly = true;
	}

	public override Vector2 GetMuzzleOffset() => new Vector2(32, -2);
}
