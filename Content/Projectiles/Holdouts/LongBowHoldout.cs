using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class LongBowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += LongBow.CritChanceIncrease * GetChargeLevel(player);
	}

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.PenOnCrit = true;
	}
}