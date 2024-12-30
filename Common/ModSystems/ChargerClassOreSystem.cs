using System.Collections.Generic;
using ChargerClass.Content.Tiles;
using Terraria;
using Terraria.GameContent.Biomes;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

public class ChargerClassOreSystem : ModSystem
{
    public static LocalizedText ChargerOrePassMessage { get; private set; }
    public static LocalizedText ChargerJungleOrePassMessage { get; private set; }

    public override void SetStaticDefaults() {
        ChargerOrePassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(ChargerOrePassMessage)}"));
        ChargerJungleOrePassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(ChargerJungleOrePassMessage)}"));
    }

    // World generation is explained more in https://github.com/tModLoader/tModLoader/wiki/World-Generation
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
        int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
        if (ShiniesIndex != -1) tasks.Insert(ShiniesIndex + 1, new ChargerClassOrePass("Charger Class Ores", 237.4298f));
        int JungleIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Muds Walls In Jungle"));
        if (JungleIndex != -1) tasks.Insert(JungleIndex + 1, new ChargerClassJungleOrePass("Charger Class Jungle Ores", 237.4298f));
    }

    public class ChargerClassOrePass : GenPass
	{
		public ChargerClassOrePass(string name, float loadWeight) : base(name, loadWeight) {}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = ChargerOrePassMessage.Value;

			for (int k = 0; k < (int)(Main.maxTilesX * (Main.maxTilesY - GenVars.rockLayer) * 8E-4); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(8, 15), WorldGen.genRand.Next(2, 6), ModContent.TileType<ElectrudiumOre>());
			}

            double UnstabelChaosShardLayer = Main.maxTilesY - (Main.maxTilesY - GenVars.rockLayer) * 0.5d;

			for (int k = 0; k < (int)(Main.maxTilesX * UnstabelChaosShardLayer * 14E-5); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)UnstabelChaosShardLayer, Main.maxTilesY);
            	WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 9), WorldGen.genRand.Next(2, 4), ModContent.TileType<UnstableChaosShard>());
			}
		}
	}

    public class ChargerClassJungleOrePass : GenPass
	{
		public ChargerClassJungleOrePass(string name, float loadWeight) : base(name, loadWeight) {}

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = ChargerJungleOrePassMessage.Value;

            double AncientDebrisLayer = Main.maxTilesY - (Main.maxTilesY - GenVars.rockLayer) * 0.85d;
            
            for (int k = 0; k < (int)((GenVars.jungleMaxX - GenVars.jungleMinX) * (Main.maxTilesY - AncientDebrisLayer) * 3E-4); k++) {
				int x = WorldGen.genRand.Next(GenVars.jungleMinX, GenVars.jungleMaxX);
				int y = WorldGen.genRand.Next((int)AncientDebrisLayer, Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && tile.TileType == TileID.Mud) {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 6), WorldGen.genRand.Next(8, 12), ModContent.TileType<AncientDebris>());
                }
			}
		}
	}
}