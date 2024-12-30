using ChargerClass.Content.Items.Weapons.Crossbows;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class PlatinumCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override bool CanConsumeAmmo(Item item, Player player, int chargeLevel) =>
		!Main.rand.NextBool(Utils.Clamp(PlatinumCrossbow.AmmoChance * chargeLevel, 0, 100), 100);
}
