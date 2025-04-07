using ChargerClass.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class PotatoCannonHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	bool hotPotato = false;

	public override void SafeModifyShootStats(Player player, Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback, int chargeLevel)
	{
		if (Main.rand.NextBool(Utils.Clamp(PotatoCannon.HotPotatoChance * chargeLevel, 0, 100), 100)) {
			hotPotato = true;
			damage = (int)(3f * damage);
			knockback *= 3f;
		}
	}
	public override void ModifyOtherStats(int chargeLevel, Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2)
	{
		if (hotPotato)
			ai2 = 1f;
		hotPotato = false;
	}
}