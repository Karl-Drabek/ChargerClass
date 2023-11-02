using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables;

public class FragmentedQuasar : ModItem
{
	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 10;
	}

	public override void SetDefaults() {
		Item.CloneDefaults(ItemID.LifeFruit);
		Item.rare = ItemRarityID.Cyan;
		Item.value = Item.sellPrice(0, 1, 65, 0);
	}
	public override bool? UseItem(Player player) {
		if(player.GetModPlayer<ChargeModPlayer>().FragmentedQuaser) return null;
		player.GetModPlayer<ChargeModPlayer>().FragmentedQuaser = true;
		CombatText.NewText(player.getRect(), new Color(254, 205, 76, 255), 1);
		return true;
	}
}