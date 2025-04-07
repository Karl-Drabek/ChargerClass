using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class TeslaCoilHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel)
	{
		NPC closestNPC = null;
		float sqrMaxDetectDistance = 100_00_00;
		float currentDistanceSquared = float.MaxValue;
		for (int k = 0; k < Main.maxNPCs; k++) {
			NPC target = Main.npc[k];
			if (Collision.CanHit(position, 1, 1, target.position, 1, 1) && target.CanBeChasedBy()) {
				float squareDistanceToNPC = Vector2.DistanceSquared(target.Center, position);
				if (squareDistanceToNPC < sqrMaxDetectDistance) {
					squareDistanceToNPC = Vector2.DistanceSquared(target.Center, Main.MouseScreen + Main.screenPosition);
					if (squareDistanceToNPC < currentDistanceSquared) {
						closestNPC = target;
						currentDistanceSquared = squareDistanceToNPC;
					}
				}
			}
		}
		if (closestNPC is not null) {
			Projectile projectile = Projectile.NewProjectileDirect(source, position, Vector2.Zero, ModContent.ProjectileType<LightningProjectile>(), damage, knockback, player.whoAmI, closestNPC.whoAmI, 0f, chargeLevel);
			projectile.scale = 2f;
		}
		return false;
	}
}