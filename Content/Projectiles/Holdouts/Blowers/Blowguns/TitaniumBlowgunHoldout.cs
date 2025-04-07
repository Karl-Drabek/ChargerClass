using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class TitaniumBlowgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * TitaniumBlowgun.CRIT_INCREASE;
	}

}
