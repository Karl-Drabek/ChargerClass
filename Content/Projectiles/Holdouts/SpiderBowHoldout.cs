using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class SpiderBowHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel){
		for(int i = 0; i <= chargeLevel; ++i){
			Vector2 vel = velocity.RotatedByRandom(MathHelper.ToRadians(2)).RotatedBy(MathHelper.ToRadians(2 * i - chargeLevel));
			Projectile proj = Projectile.NewProjectileDirect(source, position, vel, type, damage, knockback);
			CombinedPostProjectileEffects(proj, player, player.GetModPlayer<ChargeModPlayer>(), chargeLevel);
		}
		return false;
	}

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
		chargerProj.Venomous = true;
	}
}