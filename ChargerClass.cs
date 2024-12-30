using System.IO;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass;

public class ChargerClass : Mod
{
	internal enum MessageType : byte
	{
		StatIncreasePlayerSync,
		ChargeWeaponShootSync, 
		ChargeWeaponPlayerAnimationSync,
		ChargeWeaponShootDataSync,
		DartSync
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
			case MessageType.ChargeWeaponShootSync:
				if (Main.netMode == NetmodeID.Server) {
					(Main.player[whoAmI].HeldItem.ModItem as ChargeWeapon).ReceiveShot(reader);
				}
				break;
			case MessageType.ChargeWeaponPlayerAnimationSync:
				byte player = reader.ReadByte();
				(Main.player[player].HeldItem.ModItem as ChargeWeapon).ReceivePlayerAnimation(reader, player);
				if (Main.netMode == NetmodeID.Server)
					(Main.player[player].HeldItem.ModItem as ChargeWeapon).SendPlayerAnimation(-1, whoAmI, player);
				break;
			case MessageType.DartSync:
				int projectile = reader.ReadInt32();
				var dart = Main.projectile[projectile].ModProjectile as CustomDartProjectile;
				dart.ReceiveDartSync(reader, whoAmI);

				if (Main.netMode == NetmodeID.Server) dart.SendDartSync(-1, whoAmI);
				break;
			default:
				Logger.WarnFormat("ChargerClass: Unknown Message type: {0}", msgType);
				break;
		}
	}
}