using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class EbonwoodSlingshotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		chargerProj.EbonwoodValue = 20 + chargeLevel * 5;
	}
}
