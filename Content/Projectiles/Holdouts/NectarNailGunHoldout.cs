using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class NectarNailGunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override Vector2 GetMuzzleOffset() => new Vector2(35, 0);
}