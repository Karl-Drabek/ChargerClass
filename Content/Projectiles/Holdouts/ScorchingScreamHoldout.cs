using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class ScorchingScreamHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.hostile = false;
		proj.friendly = true;
		proj.scale = 0.25f;
	}
}