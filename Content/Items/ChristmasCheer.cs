using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class ChristmasCheer : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 100;
        }

        public override void SetDefaults() {
            Item.width = 8;
            Item.height = 7;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = ItemRarityID.White;
        }
    }