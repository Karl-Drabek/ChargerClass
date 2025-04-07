using System.Collections.Generic;
using ChargerClass.Common.GameUtils;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ChargerClass.Content.Tiles;

public class DartAssemblyStationTile : ModTile
{
	public override void SetStaticDefaults()
	{
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
		TileObjectData.newTile.UsesCustomCanPlace = true;
		TileObjectData.newTile.StyleHorizontal = true;
		TileObjectData.newTile.Origin = new Point16(0, 1);
		TileObjectData.newTile.CoordinateHeights = [16, 18];
		//TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
		TileObjectData.newTile.AnchorInvalidTiles = [
			TileID.MagicalIceBlock,
			TileID.Boulder,
			TileID.BouncyBoulder,
			TileID.LifeCrystalBoulder,
			TileID.RollingCactus,
		];
		TileObjectData.newTile.LavaDeath = false;
		TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
		TileObjectData.addTile(Type);
	}

	public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

	public override void NumDust(int i, int j, bool fail, ref int num) => num = 1; //dust particles when hit

	public override bool RightClick(int i, int j)
	{
		Player player = Main.LocalPlayer;

		Main.mouseRightRelease = false;
		Tile tile = Main.tile[i, j];

		// The following four (4) if-blocks are recommended to be used if your multitile opens a UI when right clicked:
		if (player.sign > -1)
		{
			SoundEngine.PlaySound(SoundID.MenuClose);
			player.sign = -1;
			Main.editSign = false;
			Main.npcChatText = string.Empty;
		}
		if (Main.editChest)
		{
			SoundEngine.PlaySound(SoundID.MenuTick);
			Main.editChest = false;
			Main.npcChatText = string.Empty;
		}
		if (player.editedChestName)
		{
			NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
			player.editedChestName = false;
		}
		if (player.talkNPC > -1)
		{
			player.SetTalkNPC(-1);
			Main.npcChatCornerItem = 0;
			Main.npcChatText = string.Empty;
		}

		if (TileUtils.TryGetTileEntityAs(i, j, out DartAssemblyStationTileEntity AssemblyStation))
		{
			if(AssemblyStation.inUse) return false;
			TileEntity.BasicOpenCloseInteraction(player, i * 16, j * 16, AssemblyStation.ID);
			DartAssemblyStationUISystem.Instance.ShowUI();
			DartAssemblyStationUISystem.Instance.DartAssemblyState.dartStation = AssemblyStation;
			DartAssemblyStationUISystem.Instance.DartAssemblyState.UpdateItems(AssemblyStation.ComponentTypes, AssemblyStation.ComponentCounts);
			AssemblyStation.inUse = true;
			AssemblyStation.SendToServer();
		}
		return true;
	}

	public override IEnumerable<Item> GetItemDrops(int i, int j) => DartAssemblyStationUISystem.Instance.DartAssemblyState.GetItemDrops();

	public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
	{
		DartAssemblyStationUISystem.Instance.HideUI();
	}

	public override void KillMultiTile(int i, int j, int frameX, int frameY){
		ModContent.GetInstance<DartAssemblyStationTileEntity>().Kill(i, j);
	}

	public override void MouseOver(int i, int j)
	{
		Player player = Main.LocalPlayer;
		player.cursorItemIconID = ModContent.ItemType<DartAssemblyStation>();
		player.noThrow = 2;
		player.cursorItemIconEnabled = true;
	}
}
