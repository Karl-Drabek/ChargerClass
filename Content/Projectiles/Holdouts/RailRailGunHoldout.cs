namespace ChargerClass.Content.Projectiles.Holdouts;

public class RailRailGunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults()
	{
		drawSelf = false;
	}

	public override float GetItemRotation() => 0;
}
