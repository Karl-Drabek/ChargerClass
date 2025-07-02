using Microsoft.Xna.Framework;
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

	public override Vector2 HoldoutOffset() => new Vector2(-50, 6);

	public override Vector2 GetMuzzleOffset() => new Vector2(50, 0);

}