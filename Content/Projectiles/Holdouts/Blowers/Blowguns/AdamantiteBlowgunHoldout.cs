using System.Security;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class AdamantiteBlowgunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(
		Player player,
		Item item,
		ref Vector2 position,
		ref Vector2 velocity,
		ref int type,
		ref int damage,
		ref float knockback,
		int chargeLevel
	)
	{
		damage += (int)(chargeLevel * AdamantiteBlowgun.DAMAGE_INCREASE / 100f * damage);
		if (player.GetModPlayer<ChargeModPlayer>().getHate()) {
			damage += (int)(chargeLevel * AdamantiteBlowgun.HATE_DAMAGE_INCREASE / 100f * damage);
			player.Hurt(
				PlayerDeathReason.ByPlayerItem(player.whoAmI, item),
				chargeLevel,
				player.direction,
				dodgeable: false,
				armorPenetration: 10000,
				knockback: 0
			);
		}
	}
}
