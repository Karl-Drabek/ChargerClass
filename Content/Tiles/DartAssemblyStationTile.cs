using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;
using ChargerClass.Content.Items.Placeable;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Tiles;

public class DartAssemblyStationTile : ModTile
{
	public override void SetStaticDefaults() {
		Main.tileFrameImportant[Type] = true;
		Main.tileNoAttach[Type] = true;
		TileID.Sets.HasOutlines[Type] = true;
		TileID.Sets.DisableSmartCursor[Type] = true;
		TileID.Sets.AvoidedByNPCs[Type] = true;
		TileID.Sets.InteractibleByNPCs[Type] = true;

            AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());

		// Placement
		TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
		TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<DartAssemblyStationTileEntity>().Hook_AfterPlacement, -1, 0, true);
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
		//TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
		TileObjectData.newTile.AnchorInvalidTiles = new int[] {
			TileID.MagicalIceBlock,
			TileID.Boulder,
			TileID.BouncyBoulder,
			TileID.LifeCrystalBoulder,
			TileID.RollingCactus
		};
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		TileObjectData.addTile(Type);
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

	public override void NumDust(int i, int j, bool fail, ref int num) {num = 1;} //dust particles when hit

	public override bool RightClick(int i, int j) {
		Player player = Main.LocalPlayer;
		Tile tile = Main.tile[i, j];
		var pos = new Point16(i - tile.TileFrameX % 36 / 18, j - tile.TileFrameY / 18);
		var AssemblyStation = (DartAssemblyStationTileEntity)TileEntity.ByPosition[pos];

		Main.mouseRightRelease = false;
		Main.npcChatCornerItem = 0;
		Main.npcChatText = "";
		TileEntity.BasicOpenCloseInteraction(player, i * 16, j * 16, AssemblyStation.ID);
		DartAssemblyStationUISystem.Instance.ShowUI();
		DartAssemblyStationUISystem.Instance.DartAssemblyState.UpdateItems(AssemblyStation.ComponentTypes, AssemblyStation.ComponentCounts);

		return true;
	}

	public override IEnumerable<Item> GetItemDrops (int i, int j) => DartAssemblyStationUISystem.Instance.DartAssemblyState.GetItemDrops();

	public override void KillTile (int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem){
		DartAssemblyStationUISystem.Instance.HideUI();
	}

	public override void MouseOver(int i, int j) {
		Player player = Main.LocalPlayer;
		player.cursorItemIconID = ModContent.ItemType<DartAssemblyStation>();
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
	}
}