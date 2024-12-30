using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class HellfireCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.Hellfire = true;
		chargerProj.ExplosionSize = 60 * chargeLevel;
	}
}
