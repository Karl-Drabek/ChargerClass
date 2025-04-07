using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class SuperSoakerHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel){
		type = ProjectileID.WaterGun;
	}
	public override void ModifyOtherStats(int chargeLevel, Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2)
	{
		if (player.ZoneDesert)
			ai0 = 1f;
		else if (player.ZoneSnow)
			ai0 = 2f;
		return;
	}

	public override void PostProjectileEffects(int chargeLevel, Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer)
	{
		if (modPlayer.Player.ZoneDesert || modPlayer.Player.ZoneSnow)
			proj.timeLeft /= 4;
		proj.friendly = true;
	}
}