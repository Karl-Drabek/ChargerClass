using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items
{
	public class SealedTinCan : ModItem
	{
        public override void SetStaticDefaults() {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults() {
            Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 24);
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Purple;
        }
        public override bool CanRightClick() => true;

		public override void ModifyItemLoot(ItemLoot itemLoot){
            IItemDropRule[] coins = new IItemDropRule[]{
				new CommonDrop(ItemID.CopperCoin, 100, 1, 99, 75), //%75
                new CommonDrop(ItemID.SilverCoin, 5, 1, 9),        //%20
                new CommonDrop(ItemID.GoldCoin, 10, 1, 1, 9),      //%4.5
                new CommonDrop(ItemID.PlatinumCoin, 1)              //%0.5
            };
            IItemDropRule[] ores = new IItemDropRule[]{
				ItemDropRule.Common(ItemID.CopperOre, 1, 17, 33),
				ItemDropRule.Common(ItemID.TinOre, 1, 17, 33),
				ItemDropRule.Common(ItemID.IronOre, 1, 15, 29),
				ItemDropRule.Common(ItemID.LeadOre, 1, 15, 29),
				ItemDropRule.Common(ItemID.SilverOre, 1, 11, 21),
				ItemDropRule.Common(ItemID.TungstenOre, 1, 11, 21),
				ItemDropRule.Common(ItemID.GoldOre, 1, 7, 13),
				ItemDropRule.Common(ItemID.PlatinumOre, 1, 7, 13),
            };
            IItemDropRule[] food = new IItemDropRule[]{
				ItemDropRule.Common(ItemID.Apple, 1, 1, 3),
				ItemDropRule.Common(ItemID.Apricot, 1, 1, 3),
				ItemDropRule.Common(ItemID.Banana, 1, 1, 3),
                ItemDropRule.Common(ItemID.BlackCurrant, 1, 1, 3),
                ItemDropRule.Common(ItemID.BloodOrange, 1, 1, 3),
                ItemDropRule.Common(ItemID.Cherry, 1, 1, 3),
                ItemDropRule.Common(ItemID.Coconut, 1, 1, 3),
                ItemDropRule.Common(ItemID.Dragonfruit, 1, 1, 3),
                ItemDropRule.Common(ItemID.Elderberry, 1, 1, 3),    
                ItemDropRule.Common(ItemID.Grapefruit, 1, 1, 3),
                ItemDropRule.Common(ItemID.Lemon, 1, 1, 3),
                ItemDropRule.Common(ItemID.Mango, 1, 1, 3),
                ItemDropRule.Common(ItemID.Peach, 1, 1, 3),
                ItemDropRule.Common(ItemID.Pineapple, 1, 1, 3),
                ItemDropRule.Common(ItemID.Plum, 1, 1, 3),
                ItemDropRule.Common(ItemID.Rambutan, 1, 1, 3),
                ItemDropRule.Common(ItemID.Starfruit, 1, 1, 3),
                ItemDropRule.Common(ItemID.SpicyPepper, 1, 1, 3),
                ItemDropRule.Common(ItemID.Pomegranate, 1, 1, 3),
                ItemDropRule.Common(ItemID.CookedFish, 1, 1, 2),
                ItemDropRule.Common(ItemID.GrilledSquirrel, 1, 1, 2),
                ItemDropRule.Common(ItemID.RoastedBird, 1, 1, 2),
                ItemDropRule.Common(ItemID.SauteedFrogLegs, 1, 1, 2),
            };
            itemLoot.Add(ItemDropRule.SequentialRulesNotScalingWithLuck(1, new IItemDropRule[]{
                new OneFromRulesRule(2, ores),
                new OneFromRulesRule(2, food),
            }));
            itemLoot.Add(ItemDropRule.SequentialRulesNotScalingWithLuck(1, coins));
            itemLoot.Add(ItemDropRule.Common(ItemID.TinCan));
		}
    }
}