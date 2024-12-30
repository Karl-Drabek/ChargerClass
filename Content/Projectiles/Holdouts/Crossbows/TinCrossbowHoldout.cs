using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Crossbows;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class TinCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.TinCanChance = Utils.Clamp(TinCrossbow.TinCanChance * chargeLevel, 0, 100);
	}
}
