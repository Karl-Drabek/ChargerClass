using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Crossbows;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Crossbows;

public class CopperCrossbowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

    public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.ignoreWater = true;
		chargerProj.RainSpeed = true;
	}
	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		velocity *= (1 + CopperCrossbow.VelocityChangeEffect / 100f) * chargeLevel;
	}
}
