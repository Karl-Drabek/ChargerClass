using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Weapons;

namespace ChargerClass.Content.Items;

public class YellowCharge : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 0;
	}
	public override void SetDefaults()
	{
            Item.CloneDefaults(ItemID.Heart);
		Item.healLife = 0;
		Item.width = 14;
            Item.height = 22;
	}

	public override bool OnPickup(Player player){
		if(player.HeldItem.ModItem is ChargeWeapon weapon) weapon.bonusCharge += 100;
		CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), 100);
		return false;
	}
}