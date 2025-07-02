using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class HandCannonHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		if (Main.rand.NextBool(Utils.Clamp(HandCannon.FragChance * chargeLevel, 0, 100), 100))
			proj.ai[2] = 1f;
	}

	public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset)
	{
		muzzleOffset *= 30;
	}
}
