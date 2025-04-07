using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class RefractinatorHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { 
		AimResponsiveness = 0.1f;
	}
	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel) => GetChargeLevel(player) > 0;

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.timeLeft = 20 * chargeLevel;
	}
}