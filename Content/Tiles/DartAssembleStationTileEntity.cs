using System;
using System.IO;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Tiles;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

public class DartAssemblyStationTileEntity : ModTileEntity
{
	public int[] ComponentTypes = new int[3], ComponentCounts = new int[3];
	public bool inUse = false;

	public void UpdateData()
	{
		if(DartAssemblyStationUISystem.Instance.DartAssemblyState is not null){
			ComponentTypes = DartAssemblyStationUISystem.Instance.DartAssemblyState.ComponentTypes;
			ComponentCounts = DartAssemblyStationUISystem.Instance.DartAssemblyState.ComponentCounts;
			SendToServer();
		}
	}

	public void ServerUpdate(){
		if(Main.netMode == NetmodeID.Server)
			NetMessage.SendData(MessageID.TileEntitySharing, number: ID, number2: Position.X, number3: Position.Y);
	}

	public override void NetReceive(BinaryReader reader) {
		inUse = reader.ReadBoolean();
		ComponentTypes[0] = reader.ReadInt32();
		ComponentTypes[1] = reader.ReadInt32();
		ComponentTypes[2] = reader.ReadInt32();
		ComponentCounts[0] = reader.ReadInt32();
		ComponentCounts[1] = reader.ReadInt32();
		ComponentCounts[2] = reader.ReadInt32();
	}

	public override void NetSend(BinaryWriter writer) {
		writer.Write(inUse);
		writer.Write(ComponentTypes[0]);
		writer.Write(ComponentTypes[1]);
		writer.Write(ComponentTypes[2]);
		writer.Write(ComponentCounts[0]);
		writer.Write(ComponentCounts[1]);
		writer.Write(ComponentCounts[2]);
	}

	public void SendToServer(){
		if(Main.netMode == NetmodeID.MultiplayerClient){
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)ChargerClass.ChargerClass.MessageType.DartAssemblyStationSync);
			packet.Write(ID); // id
			packet.Write(inUse);
			packet.Write(ComponentTypes[0]);
			packet.Write(ComponentTypes[1]);
			packet.Write(ComponentTypes[2]);
			packet.Write(ComponentCounts[0]);
			packet.Write(ComponentCounts[1]);
			packet.Write(ComponentCounts[2]);
			packet.Send();
		}
	}

	public override void SaveData(TagCompound tag)
	{
		UpdateData();
		tag["Types"] = ComponentTypes;
		tag["Counts"] = ComponentCounts;
	}

	public override void LoadData(TagCompound tag)
	{
		ComponentTypes = tag.Get<int[]>("Types");
		ComponentCounts = tag.Get<int[]>("Counts");
		inUse = false;
		ServerUpdate();
	}

	public override void OnNetPlace() { ServerUpdate(); }

	public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alterate)
	{
		if (Main.netMode == NetmodeID.MultiplayerClient) {
			NetMessage.SendTileSquare(Main.myPlayer, i, j, 3);
			NetMessage.SendData(MessageID.TileEntityPlacement, number: i, number2: j, number3: Type);
			return -1;
		}
		return Place(i, j);
	}

	public override bool IsTileValidForEntity(int x, int y)
	{
		Tile tile = Main.tile[x, y];
		return tile.HasTile && tile.TileType == ModContent.TileType<DartAssemblyStationTile>() && tile.TileFrameX == 0 && tile.TileFrameY == 0;
	}
}
