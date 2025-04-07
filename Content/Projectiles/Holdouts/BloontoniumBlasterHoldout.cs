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
}