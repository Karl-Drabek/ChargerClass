using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class HydraRocketLauncherHoldout : AnimatedChargeWeaponHoldout
{
	public override void SafestSetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 3;
	}

	public override void SafestSetDefaults()
	{
		Projectile.scale = 0.75f;
	}

	public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset)
	{
		muzzleOffset *= 50;
		muzzleOffset += new Vector2(0, 1);
	}
}