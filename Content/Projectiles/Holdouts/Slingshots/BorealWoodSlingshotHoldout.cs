using Terraria;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class BorealWoodSlingshotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		if (Main.rand.NextBool(Utils.Clamp(BorealWoodSlingshot.Frostburn * (chargeLevel + 2), 0, 100), 100))
			chargerProj.Frostburn = true;
	}
}