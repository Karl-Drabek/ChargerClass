using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;

namespace ChargerClass.Content.Items
{
	public class BlueCharge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BlueCharge");
			Tooltip.SetDefault("Pickup to gain 200 charge");
		}

		public override void SetDefaults()
		{
            Item.CloneDefaults(ItemID.Heart);
			Item.healLife = 0;
			Item.width = 14;
            Item.height = 22;
		}

		public override bool OnPickup(Player player){
			if(player.HeldItem.ModItem is ChargeWeapon weapon) weapon.charge += 200;
			CombatText.NewText(player.getRect(), new Color(4, 158, 255, 255), 200);
			return false;
		}
	}
}