using ChargerClass.Content.Items.Weapons.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class PalmWoodSlingshotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		if (Main.rand.NextBool(Utils.Clamp(PalmWoodSlingshot.CoconutChance * chargeLevel, 0, 100), 100))
		{
			type = ModContent.ProjectileType<CoconutProjectile>();
			velocity *= 0.75f;
			damage = (int)(2f * damage);
			knockback *= 2;
		}
	}
}
