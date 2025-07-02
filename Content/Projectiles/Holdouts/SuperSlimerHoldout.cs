using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class SuperSlimerHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(
		Player player,
		Item item,
		ref Vector2 position,
		ref Vector2 velocity,
		ref int type,
		ref int damage,
		ref float knockback,
		int chargeLevel
	)
	{
		type = ModContent.ProjectileType<SuperSlimerProjectile>();
	}

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		proj.friendly = true;
		chargerProj.Slimed = true;
	}
	public override Vector2 GetMuzzleOffset() => new Vector2(48, 0);
}
