using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Placeable;

public class UnstableChaosShard : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 100;
		ItemID.Sets.SortingPriorityMaterials[Item.type] = ItemID.Sets.SortingPriorityMaterials[ItemID.SpectreBar];
	}

	public override void SetDefaults()
	{
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.UnstableChaosShard>());
		Item.width = 18;
		Item.height = 18;
		Item.value = Item.sellPrice(0, 0, 45, 0);
		Item.rare = ItemRarityID.Yellow;
	}
}