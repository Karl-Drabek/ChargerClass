using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class MultiShotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel)
	{
		int count = chargeLevel + 1;
		float spreadMult = 4; //degrees between projectiles in spread
		float spread = count * spreadMult / 2; //start degrees for projectiles
		for (int i = 0; i < count; i++)
		{
			Projectile proj = Projectile.NewProjectileDirect(source, position, velocity.RotatedBy(MathHelper.ToRadians(spread - spreadMult * i)), type, damage, knockback);
			CombinedPostProjectileEffects(proj, player, player.GetModPlayer<ChargeModPlayer>(), chargeLevel);
		}
		return false;
	}
}
