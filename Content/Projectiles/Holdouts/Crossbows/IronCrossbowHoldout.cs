using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Crossbows;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class IronCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.Tetnus = Main.rand.NextBool(Utils.Clamp(IronCrossbow.InflictChance * chargeLevel, 0, 100), 100);
	}
}
