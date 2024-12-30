using ChargerClass.Content.Items.Weapons.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts.Slingshots;

public class ReinforcedSlingshotHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		damage += chargeLevel * ReinforcedSlingshot.DamageIncrease;
	}
}
