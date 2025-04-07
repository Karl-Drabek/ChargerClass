using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Dusts;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class ConsumingLensHoldout : ChargeWeaponHoldout
{

	public override void SafeSetDefaults() { 
		AimResponsiveness = 0.1f;
	}
	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel) => GetChargeLevel(player) > 0;

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		proj.timeLeft = 20 * chargeLevel;
	}

	int damageDealt = 0;
	public override void ChargingAI(Player player)
	{
		for (int k = 0; k < Main.maxNPCs; k++) {
			NPC target = Main.npc[k];
			if (target.friendly || !target.active || target.dontTakeDamage)
				continue;
			float distanceToNPC = Vector2.DistanceSquared(target.Center, Main.MouseScreen + Main.screenPosition);
			if (distanceToNPC < 90_000) {
				if (Main.rand.NextBool(90_000 - (int)distanceToNPC, 90_000 * 5)) {
					player.ApplyDamageToNPC(target, 1, 0, 0, false, ChargerDamageClass.Instance);
					if (++damageDealt > 10) {
						player.Heal(1);
						damageDealt = 0;
					}
					Dust.NewDust(target.Center, target.width, target.height, ModContent.DustType<ConsumingDust>());
				}
			}
		}
	}
}