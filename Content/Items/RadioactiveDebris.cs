using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Buffs;

namespace ChargerClass.Content.Items;

public class RadioactiveDebris : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults() {
            Item.width = 8;
            Item.height = 7;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 1, 50);
            Item.rare = ItemRarityID.LightPurple;
        }

        public override void UpdateInventory(Player player){
            player.AddBuff(ModContent.BuffType<RadiationSickness>(), 60);
        }
    }