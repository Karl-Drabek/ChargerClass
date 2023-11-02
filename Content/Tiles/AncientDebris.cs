using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Tiles;

public class AncientDebris : ModTile
{
	public override void SetStaticDefaults() {
		TileID.Sets.Ore[Type] = true;
		Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
		Main.tileOreFinderPriority[Type] = 680; // Metal Detector value, see https://terraria.wiki.gg/wiki/Metal_Detector
		Main.tileShine2[Type] = true; // Modifies the draw color slightly.
		Main.tileShine[Type] = 800; // How often tiny dust appear off this tile. Larger is less frequently
		Main.tileMergeDirt[Type] = true;
		Main.tileSolid[Type] = true;
		Main.tileBlockLight[Type] = true;

		LocalizedText name = CreateMapEntryName();
		AddMapEntry(new Color(152, 171, 198), name);

		DustType = 84;
		HitSound = SoundID.Tink;
		MineResist = 8f;
		MinPick = 180;
	}
}