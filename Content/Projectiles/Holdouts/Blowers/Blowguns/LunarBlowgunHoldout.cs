using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.ModSystems;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles.Holdouts.Blowers.Blowguns;

public class LunarBlowgunHoldout : ChargeWeaponHoldout
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
		damage += (int)(chargeLevel * LunarBlowgun.DAMAGE_INCREASE / 100f * damage);
		knockback += chargeLevel * LunarBlowgun.KNOCKBACK_INCREASE;
	}

	public override void PostProjectileEffects(
		int chargeLevel,
		Projectile proj,
		ChargerProjectile chargerProj,
		ChargeModPlayer modPlayer
	)
	{
		chargerProj.LunarEffect = chargeLevel;
	}

	public override void ChargingAI(Player player)
	{
		float chargePercent = Charge / player.GetModPlayer<ChargeModPlayer>().GetMaxCharge();
		ModLightingSystem.Instance.timeSpeed = 1 - 26 * chargePercent;
		timeTaken += 26 * chargePercent;
		NetMessage.SendData(MessageID.WorldData);
	}

	float timeTaken = 0f;

	public override bool Shoot(
		Player player,
		Item item,
		EntitySource_ItemUse_WithAmmo source,
		Vector2 position,
		Vector2 velocity,
		int type,
		int damage,
		float knockback,
		int chargeLevel
	)
	{
		ModLightingSystem.Instance.resetTime(timeTaken);
		timeTaken = 0f;
		return true;
	}

	public override void ModifyWeaponCrit(Player player, ref float crit)
	{
		crit += GetChargeLevel(player) * LunarBlowgun.CRIT_INCREASE;
	}
}
