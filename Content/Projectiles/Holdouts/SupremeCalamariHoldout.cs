using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class SupremeCalamariHoldout : AnimatedChargeWeaponHoldout
{
	public override void SafestSetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 4;
	}

	public override void SafestSetDefaults()
	{
		Projectile.scale = 0.75f;
	}

}