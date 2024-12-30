using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class TripleShotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel)
	{
		for (int i = 0; i < 3; i++)
		{
			Projectile proj = Projectile.NewProjectileDirect(source, position, velocity.RotatedBy(MathHelper.ToRadians(8 - 4 * i)), type, damage, knockback);
			CombinedPostProjectileEffects(proj, player, player.GetModPlayer<ChargeModPlayer>(), chargeLevel);
		}
		return false;
	}

	public override bool CanConsumeAmmo(Item item, Player player, int chargeLevel) =>
		!Main.rand.NextBool(Utils.Clamp(TripleShot.AmmoChance * chargeLevel, 0, 100), 100);
}
