using System.Security.Cryptography.X509Certificates;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class TitaniumBlowgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * TitaniumBlowgun.CRIT_INCREASE;
	}

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.TitaniumEffect = true;
	}

}
