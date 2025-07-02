using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class DepleatedBloontonium : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}

	public override void SetDefaults()
	{
		Item.width = 14;
		Item.height = 24;

		Item.maxStack = 999;
		Item.value = Item.buyPrice(0, 0, 30, 0);
		Item.rare = ItemRarityID.Yellow;
	}
}