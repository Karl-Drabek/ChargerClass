using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers;

public class TronboneHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel)
	{
		if (Shots == chargeLevel){
			StatModifier modifier = player.GetTotalDamage(ChargerDamageClass.Instance); //chargedamage class damage modifier
			player.GetModPlayer<ChargeModPlayer>().ModifyWeaponDamage(item, ref modifier); //I'm not using CombinedHooks/Item to avoid scaling with charge percent
			int count = (int)(Main.rand.NextFloat(chargeLevel * 2, chargeLevel * 3) + 0.5f);
			for (int i = 0; i < count; i++) {
				Projectile proj = Projectile.NewProjectileDirect(source, position,
					Vector2.Normalize(Main.MouseWorld - player.Center)
					.RotatedByRandom(MathHelper.ToRadians(15)) * (chargeLevel * 4f + (float)Main.rand.NextDouble() * 6f),
					ProjectileID.Bone, (int)modifier.ApplyTo(13), 1f);
				CombinedPostProjectileEffects(proj, player, player.GetModPlayer<ChargeModPlayer>(), chargeLevel);
			}
		}
		return true;
	}
}
