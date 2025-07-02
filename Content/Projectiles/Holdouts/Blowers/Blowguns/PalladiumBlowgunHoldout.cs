using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class PalladiumBlowgunHoldout : ChargeWeaponHoldout
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
		damage += (int)(chargeLevel * PalladiumBlowgun.DAMAGE_INCREASE / 100f * damage);
	}

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		chargerProj.PalladiumEffect = chargeLevel;
	}
}
