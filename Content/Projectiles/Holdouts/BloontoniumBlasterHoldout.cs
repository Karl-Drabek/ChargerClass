using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class BloontoniumBlasterHoldout : AnimatedChargeWeaponHoldout
{
	public override void SafestSetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 2;
	}

	public override void SafestSetDefaults()
	{
		Projectile.scale = 0.75f;
	}

	public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset)
	{
		muzzleOffset *= 40;
		muzzleOffset += new Vector2(0, 1);
	}
}
