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
            ModContent.ItemType<AdamantiteTip>(),
            ModContent.ItemType<BoneTip>(),
            ModContent.ItemType<ChlorophyteTip>(),
            ModContent.ItemType<HallowedTip>(),
            ModContent.ItemType<HellstoneTip>(),
            ModContent.ItemType<HypodermicNeedle>(),
            ModContent.ItemType<LihzahrdTip>(),
            ModContent.ItemType<LunarTip>(),
            ModContent.ItemType<MeteorTip>(),
            ModContent.ItemType<ShroomiteTip>(),
            ModContent.ItemType<SpectreTip>(),
            ModContent.ItemType<TitaniumTip>(),
            ModContent.ItemType<UnicornTip>());

        public static bool[] IsDartPayload = ItemID.Sets.Factory.CreateBoolSet(false,  
            ModContent.ItemType<Atomizer>(),
            ModContent.ItemType<CryoCannister>(),
            ModContent.ItemType<CursedCannister>(),
            ModContent.ItemType<DartCannister>(),
            ModContent.ItemType<DartFrogDebilitator>(),
            ModContent.ItemType<DeathFactor>(),
            ModContent.ItemType<ExplosiveCannister>(),
            ModContent.ItemType<GodKillerCocktail>(),
            ModContent.ItemType<IchorCannister>(),
            ModContent.ItemType<JellyfishCannister>(),
            ModContent.ItemType<LavaCannister>(),
            ModContent.ItemType<LiquidLeadCannister>(),
            ModContent.ItemType<RadioactiveParsel>());

        public static bool[] IsDartTail = ItemID.Sets.Factory.CreateBoolSet(false, 
            ModContent.ItemType<BetsysBackwash>(),
            ModContent.ItemType<BombingBay>(),
            ModContent.ItemType<CropDuster>(),
            ModContent.ItemType<EagleEye>(),
            ModContent.ItemType<FeatheredTail>(),
            ModContent.ItemType<HolyLightTail>(),
            ModContent.ItemType<MagesTail>(),
            ModContent.ItemType<PixieDuster>(),
            ModContent.ItemType<PrismaticTail>(),
            ModContent.ItemType<RocketJets>(),
            ModContent.ItemType<TheCorruptor>(),
            ModContent.ItemType<ToxicTail>(),
            ModContent.ItemType<UnholyTail>());
    }
}