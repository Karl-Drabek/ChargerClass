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
	public class Charge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charge");
			Tooltip.SetDefault("Pickup to gain 100 charge");
		}

		public override void SetDefaults()
		{
            Item.CloneDefaults(ItemID.Heart);
			Item.healLife = 0;
			Item.width = 14;
            Item.height = 22;
		}

		public override bool OnPickup(Player player){
			if(player.HeldItem.ModItem is ChargeWeapon weapon) weapon.charge += 100;
			CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), 100);
			return false;
		}
	}
}