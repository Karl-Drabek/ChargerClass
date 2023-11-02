using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Placeable;

public class UnstableChaosShard : ModItem
{
	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 100;
		ItemID.Sets.SortingPriorityMaterials[Item.type] = ItemID.Sets.SortingPriorityMaterials[ItemID.SpectreBar];
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(15, 4)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
	}

	public override void SetDefaults() {
		Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.UnstableChaosShard>());
		Item.width = 90;
		Item.height = 46;
		Item.value = Item.sellPrice(0, 0, 45, 0);
		Item.rare = ItemRarityID.Yellow;
	}
}