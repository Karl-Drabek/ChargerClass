using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class AirgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() {
		Projectile.scale = 0.75f;
	 }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.CatchCritters = true;
	}

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * Airgun.CritChanceIncreases;
	}
}
