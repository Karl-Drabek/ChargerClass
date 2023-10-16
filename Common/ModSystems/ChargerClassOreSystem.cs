using System.Collections.Generic;
using ChargerClass.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

public class ChargerClassOreSystem : ModSystem
{
    public static LocalizedText ChargerOrePassMessage { get; private set; }

    public override void SetStaticDefaults() {
        ChargerOrePassMessage = Language.GetOrRegister(Mod.GetLocalizationKey($"WorldGen.{nameof(ChargerOrePassMessage)}"));
    }

    // World generation is explained more in https://github.com/tModLoader/tModLoader/wiki/World-Generation
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
        // Because world generation is like layering several images on top of each other, we need to do some steps between the original world generation steps.

        // Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
        // First, we find out which step "Shinies" is.
        int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

        if (ShiniesIndex != -1) {
            // Next, we insert our pass directly after the original "Shinies" pass.
            // ElectrudiumOrePass is a class seen bellow
            tasks.Insert(ShiniesIndex + 1, new ChargerClassOrePass("Charger Class Ores", 237.4298f));
        }
    }

    public class ChargerClassOrePass : GenPass
	{
		public ChargerClassOrePass(string name, float loadWeight) : base(name, loadWeight) {} //2E-06

		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			progress.Message = ChargerClassOreSystem.ChargerOrePassMessage.Value;

			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 2E-02); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);

				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 3), WorldGen.genRand.Next(25, 50), ModContent.TileType<ElectrudiumOre>());
			}
            
            for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 2E-02); k++) {
				int x = WorldGen.genRand.Next(GenVars.jungleMinX, GenVars.jungleMaxX);
				int y = WorldGen.genRand.Next((int)GenVars.rockLayer, Main.maxTilesY);

				Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && tile.TileType == TileID.Mud) {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 3), WorldGen.genRand.Next(25, 50), ModContent.TileType<AncientDebris>());
                }
			}

			for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 2E-02); k++) {
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY);

            	WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 3), WorldGen.genRand.Next(25, 50), ModContent.TileType<UnstableChaosShard>());
			}
		}
	}
}