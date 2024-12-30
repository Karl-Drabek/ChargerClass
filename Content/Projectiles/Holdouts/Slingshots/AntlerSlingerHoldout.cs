using Terraria;
using ChargerClass.Content.Items.Weapons.Slingshots;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Players;
using Terraria.ID;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class AntlerSlingerHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel)
	{
		StatModifier modifier = player.GetTotalDamage(ChargerDamageClass.Instance); //chargedamage class damage modifier
		player.GetModPlayer<ChargeModPlayer>().ModifyWeaponDamage(item, ref modifier); //I'm not using CombinedHooks/Item to avoid scaling with charge percent            
		for (int i = 0; i < chargeLevel; i++) {
			Projectile proj = Projectile.NewProjectileDirect(
			  source,
			  position,
			  Vector2.Normalize(velocity).RotatedByRandom(MathHelper.ToRadians(15))
				* (chargeLevel * 4 + 5f + (float)Main.rand.NextDouble() * 1.5f),
			  ProjectileID.IceSpike,
			  (int)modifier.ApplyTo(41), 1f);
			proj.hostile = false;
			proj.friendly = true;
			CombinedPostProjectileEffects(proj, player, player.GetModPlayer<ChargeModPlayer>(), chargeLevel);
		}
		return true;
	}

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		chargerProj.IceOnDeath = true;
	}
}