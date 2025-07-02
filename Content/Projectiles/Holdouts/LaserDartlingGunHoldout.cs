using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class LaserDartlingGunHoldout : AnimatedChargeWeaponHoldout
{
	public override void SafestSetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 2;
	}

	public override void SafestSetDefaults()
	{
		Projectile.scale = 0.75f;
	}

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		proj.hostile = false;
		proj.friendly = true;
		proj.penetrate = 6;
		proj.usesLocalNPCImmunity = true;
		proj.localNPCHitCooldown = 10;
	}

	public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset)
	{
		muzzleOffset *= 40;
		muzzleOffset += new Vector2(0, 1);
	}
}
