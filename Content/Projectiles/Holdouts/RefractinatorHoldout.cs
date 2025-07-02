using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class RefractinatorHoldout : ChargeWeaponHoldout
{
	public override void ModifyOtherStats(
		int chargeLevel,
		Player player,
		ref int owner,
		ref float ai0,
		ref float ai1,
		ref float ai2
	)
	{
		ai0 = 180;
		ai1 = 0;
	}

	public override Vector2 GetMuzzleOffset() => new Vector2(50, -4);
}
