using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Slingshots;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class PearlwoodSlingshotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		if (Main.rand.NextBool(Utils.Clamp(PearlwoodSlingshot.ConfuseChance * chargeLevel, 0, 100), 100))
			chargerProj.Confused = true;
	}
}
