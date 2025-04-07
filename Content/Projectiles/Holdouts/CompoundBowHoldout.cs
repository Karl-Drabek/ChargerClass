using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class CompoundBowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		velocity *= 1f + CompoundBow.VelocityIncrease / 100f * chargeLevel;
	}

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.penetrate += chargeLevel;
	}
}