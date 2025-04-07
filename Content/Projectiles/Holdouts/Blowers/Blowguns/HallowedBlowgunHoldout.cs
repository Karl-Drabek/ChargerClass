using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class HallowedBlowgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel) {
		damage += chargeLevel * HallowedBlowgun.DAMAGE_INCREASE;
	}

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * HallowedBlowgun.CRIT_INCREASE;
	}
}
