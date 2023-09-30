using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Placeable
{
	public class AncientTech : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = ItemID.Sets.SortingPriorityMaterials[ItemID.ShroomiteBar];
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.AncientTech>());
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 1, 10, 0);
			Item.rare = ItemRarityID.Lime;
		}
	}
}