using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Steamworks;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class SnailGunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void ModifyOtherStats(
		int chargeLevel,
		Player player,
		ref int owner,
		ref float ai0,
		ref float ai1,
		ref float ai2
	)
	{
		if (Main.rand.NextFloat(0, 1) < 1 - chargeLevel * 0.025)
		{
			ai2 = 0;
		}
		else
		{
			ai2 = Main.rand.NextBool(2) ? 1 : 2;
		}
	}

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer0
	)
	{
		Projectile.timeLeft = 60 + chargeLevel * 20;
	}

	public override Vector2 GetMuzzleOffset() => new Vector2(20, 0);
}
