using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class BolaHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.ai[2] = 30 * chargeLevel;
	}
}