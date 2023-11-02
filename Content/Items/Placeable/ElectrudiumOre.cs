using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Placeable;

public class ElectrudiumOre : ModItem
{
	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 100;
		ItemID.Sets.SortingPriorityMaterials[Item.type] = ItemID.Sets.SortingPriorityMaterials[ItemID.Meteorite];

		// This ore can spawn in slime bodies like other pre-boss ores. (copper, tin, iron, etch)
		// It will drop in amount from 3 to 13.
		ItemID.Sets.OreDropsFromSlime[Type] = (3, 13);
	}

	public override void SetDefaults() {
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ElectrudiumOre>());
		Item.width = 12;
		Item.height = 12;
		Item.value = Item.sellPrice(0, 0, 5, 0);
		Item.rare = ItemRarityID.Green;
	}
}