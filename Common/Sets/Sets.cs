using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Ammo.Darts.Tips;
using ChargerClass.Content.Items.Ammo.Darts.Payloads;
using ChargerClass.Content.Items.Ammo.Darts.Tails;

namespace ChargerClass.Common.Sets
{
    public class Sets
    {
        public static bool[] IsDartTip = ItemID.Sets.Factory.CreateBoolSet(false,
            ModContent.ItemType<HypodermicNeedle>());

        public static bool[] IsDartPayload = ItemID.Sets.Factory.CreateBoolSet(false,  
            ModContent.ItemType<DartCannister>());

        public static bool[] IsDartTail = ItemID.Sets.Factory.CreateBoolSet(false, 
            ModContent.ItemType<FeatheredTail>(),
            ModContent.ItemType<UnholyTail>());
    }
}