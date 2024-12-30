using ChargerClass.Content.Items.Weapons.Slingshots;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class WoodSlingshotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		int chargeLevel = GetChargeLevel(player);
		crit += chargeLevel * WoodSlingshot.CritChanceIncrease;
	}
}
