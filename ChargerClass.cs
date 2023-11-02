using System.IO;
using ChargerClass.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass;

public class ChargerClass : Mod
{
	internal enum MessageType : byte
	{
		StatIncreasePlayerSync
	}
	public override void HandlePacket(BinaryReader reader, int whoAmI) {
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
			default:
				Logger.WarnFormat("ChargerClass: Unknown Message type: {0}", msgType);
				break;
		}
	}
}