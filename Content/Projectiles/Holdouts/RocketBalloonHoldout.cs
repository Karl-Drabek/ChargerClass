using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class RocketBalloonHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.timeLeft += chargeLevel * 30;
		if ((proj.timeLeft > 15) && Main.rand.NextBool(Utils.Clamp((int)proj.timeLeft, 0, 2500), 2500)) {
			proj.hostile = true;
			proj.Kill();
		}
	}

}