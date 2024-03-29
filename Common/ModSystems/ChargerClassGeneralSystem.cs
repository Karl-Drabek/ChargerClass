using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Content.Items.Weapons.Blowers.Blowguns;
using ChargerClass.Content.Items.Ammo.Darts.Payloads;
using ChargerClass.Content.Items.Placeable;
using ChargerClass.Content.Items.Consumables;

//TODO finish other chest loot

namespace ChargerClass.Common.ModSystems;

class ChargerClassGeneralSystem : ModSystem
    {   
        public static int CopperBarRecipeGroup, SilverBarRecipeGroup, HardmodeOreBlowguns,
        IchorCannisters, Rockets, CopperOreRecipeGroup, GoldBarRecipeGroup,
        TitaniumBarRecipeGroup, ShadowScaleRecipeGroup, DemoniteBarRecipeGroup, 
        VoltaicScrapRecipeGroup;
        public static ChargerClassGeneralSystem Instance = ModContent.GetInstance<ChargerClassGeneralSystem>();

        public static ModKeybind InhalerKeybind { get; private set; }
        public static ModKeybind RocketStormKeybind { get; private set; }
        public static ModKeybind ChaosAdrenaline { get; private set; }
	public static string IchorCannisterGroup { get; internal set; }

	public override void AddRecipeGroups() {
		// Language.GetTextValue("LegacyMisc.37") is the word "Any" in English, and the corresponding word in other languages
		RecipeGroup copperBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
		CopperBarRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), copperBarRecipeGroup);

            RecipeGroup copperOreRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperOre)}", ItemID.CopperOre, ItemID.TinOre);
		CopperOreRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.CopperOre), copperOreRecipeGroup);

            RecipeGroup rockets = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.RocketI)}", ItemID.RocketI, ItemID.RocketII, ItemID.RocketIII, ItemID.RocketIV);
		Rockets = RecipeGroup.RegisterGroup(nameof(ItemID.RocketI), rockets);

		RecipeGroup silverBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}",ItemID.SilverBar, ItemID.TungstenBar);
		SilverBarRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), silverBarRecipeGroup);

            RecipeGroup goldBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}",ItemID.GoldBar, ItemID.PlatinumBar);
		GoldBarRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), goldBarRecipeGroup);

            RecipeGroup titaniumBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.TitaniumBar)}",ItemID.TitaniumBar, ItemID.AdamantiteBar);
		TitaniumBarRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.TitaniumBar), titaniumBarRecipeGroup);

            RecipeGroup shadowScaleRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.ShadowScale)}",ItemID.ShadowScale, ItemID.TissueSample);
		ShadowScaleRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.ShadowScale), shadowScaleRecipeGroup);

            RecipeGroup demoniteBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.DemoniteBar)}",ItemID.DemoniteBar, ItemID.CrimtaneBar);
		DemoniteBarRecipeGroup = RecipeGroup.RegisterGroup(nameof(ItemID.DemoniteBar), demoniteBarRecipeGroup);

            
            RecipeGroup voltaicScrapRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<MightyVoltaicScrap>())}",
                ModContent.ItemType<MightyVoltaicScrap>(), ModContent.ItemType<FrightfulVoltaicScrap>(), ModContent.ItemType<OpticVoltaicScrap>());
		VoltaicScrapRecipeGroup = RecipeGroup.RegisterGroup("ChargerClass:VoltaicScrapGroup", voltaicScrapRecipeGroup);

            RecipeGroup hardmodeOreBlowguns = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<TitaniumBlowgun>())}",
			ModContent.ItemType<TitaniumBlowgun>(), ModContent.ItemType<AdamantiteBlowgun>(),
                ModContent.ItemType<MythrilBlowgun>(), ModContent.ItemType<OrichalcumBlowgun>(),
                ModContent.ItemType<CobaltBlowgun>(), ModContent.ItemType<PalladiumBlowgun>());
            HardmodeOreBlowguns = RecipeGroup.RegisterGroup("ChargerClass:HardmodeBlowgunGroup", hardmodeOreBlowguns);

            RecipeGroup ichorCannisters = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ModContent.ItemType<IchorCannister>())}",
			ModContent.ItemType<CursedCannister>(), ModContent.ItemType<IchorCannister>());
            IchorCannisters = RecipeGroup.RegisterGroup("ChargerClass:IchorCannisters", ichorCannisters);

	}

        public override void PostWorldGen() {
            int GoldChestItemCount = 0;
            int ShadowChestItemCount = 0;
		for(int c = 0; c < Main.maxChests; c++) {
			Chest chest = Main.chest[c];
			if(chest == null) continue;

			Tile chestTile = Main.tile[chest.x, chest.y];
			//(ExampleMod): If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Frozen Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. An alternate approach is to check the wiki and looking for the "Internal Tile ID" section in the infobox: https://terraria.wiki.gg/wiki/Frozen_Chest
			if(chestTile.TileType != TileID.Containers) continue;
                switch(chestTile.TileFrameX){
                    case 1 * 36: //gold chest
                        if (WorldGen.genRand.NextBool(2, 3) || ++GoldChestItemCount >= 20) continue; //33% chance or already have max items
                        for (int i = 0; i < Chest.maxItems; i++) {
                            if (chest.item[i].type == ItemID.None) {
                                chest.item[i].SetDefaults(GoldChestItemCount % 2 == 0? ModContent.ItemType<TripleShot>() : ModContent.ItemType<TripleShot>());
                                break;
                            }
                        }
                        break;
                    case 4 * 36: //shadow chest
                        if (WorldGen.genRand.NextBool(0, 20) || ++ShadowChestItemCount >= 10) continue; //15% chance or already have max items
                        for (int i = 0; i < Chest.maxItems; i++) {
                            if (chest.item[i].type == ItemID.None) {
                                chest.item[i].SetDefaults(ModContent.ItemType<MolotovMortar>());
                                break;
                            }
                        }
                        break;
			}
		}
        }

        public override void PostSetupContent() {
		ItemID.Sets.ExtractinatorMode[ItemID.Frog] = ItemID.Frog;
            ItemID.Sets.ExtractinatorMode[ItemID.GoldFrog] = ItemID.GoldFrog;
            ItemID.Sets.ExtractinatorMode[ModContent.ItemType<AncientDebris>()] = ModContent.ItemType<AncientDebris>();
	}

        public override void Load(){
            InhalerKeybind = KeybindLoader.RegisterKeybind(Mod, "InhalerKeybind", "P");
            RocketStormKeybind = KeybindLoader.RegisterKeybind(Mod, "RocketStormKeybind", "L");
            ChaosAdrenaline = KeybindLoader.RegisterKeybind(Mod, "ChaosAdrenaline", "M");
        }

        public override void Unload(){
		InhalerKeybind = null;
            RocketStormKeybind = null;
            ChaosAdrenaline = null;
	}
}