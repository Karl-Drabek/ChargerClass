using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class HellfireBlowgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.Hellfire = true;
	}

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * HellfireBlowgun.CritChanceIncreases;
	}
}
