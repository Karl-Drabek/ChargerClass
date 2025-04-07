using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class MythrilBlowgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * MythrilBlowgun.CRIT_INCREASE;
	}
}
