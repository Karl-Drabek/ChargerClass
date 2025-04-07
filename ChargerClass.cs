using System.IO;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass;

public class ChargerClass : Mod
{
	internal enum MessageType : byte
	{
		StatIncreasePlayerSync, DartAssemblyStationSync, SpawnNPC,
	}
	public override void HandlePacket(BinaryReader reader, int whoAmI)
	{
		MessageType msgType = (MessageType)reader.ReadByte();

		switch (msgType) {
			case MessageType.StatIncreasePlayerSync:
				byte playernumber = reader.ReadByte();
				ChargeModPlayer modPlayer = Main.player[playernumber].GetModPlayer<ChargeModPlayer>();
				modPlayer.ReceivePlayerSync(reader);

				if (Main.netMode == NetmodeID.Server) {
					// Forward the changes to the other clients
					modPlayer.SyncPlayer(-1, whoAmI, false);
				}
				break;
			case MessageType.DartAssemblyStationSync:
				int id = reader.ReadInt32();
				DartAssemblyStationTileEntity station = TileEntity.ByID[id] as DartAssemblyStationTileEntity;
				station.NetReceive(reader);
				if (Main.netMode == NetmodeID.Server) {
					// Forward the changes to the other clients
					station.ServerUpdate();
				}
				break;
			case MessageType.SpawnNPC:
				Player player = Main.player[reader.ReadInt32()];
				float posX = (float)reader.ReadDouble();
				float posY =  (float)reader.ReadDouble();
				float velX =  (float)reader.ReadDouble();
				float velY =  (float)reader.ReadDouble();
				int type = reader.ReadInt32();

				NPC npc = NPC.NewNPCDirect(new EntitySource_Parent(player), new Vector2(posX, posY), type);
				npc.velocity = new Vector2(velX, velY);
				npc.netUpdate = true;
				break;
			default:
				Logger.WarnFormat("ChargerClass: Unknown Message type: {0}", msgType);
				break;
		}
	}
}