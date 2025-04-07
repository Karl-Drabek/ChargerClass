using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Net;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class BunnyGunHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults() { }
	public override bool Shoot(Player player, Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback, int chargeLevel)
	{
		if (Main.netMode == NetmodeID.SinglePlayer)
		{
			NPC npc = NPC.NewNPCDirect(new EntitySource_Parent(player), position, RandomBunny());
			npc.velocity = velocity;
		}
		else if (Main.netMode == NetmodeID.MultiplayerClient)
		{
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)ChargerClass.MessageType.SpawnNPC);
			packet.Write(player.whoAmI);
			packet.Write((double)position.X);
			packet.Write((double)position.Y);
			packet.Write((double)velocity.X);
			packet.Write((double)velocity.Y);
			packet.Write(RandomBunny());
			packet.Send();
		}
		return false;
		int RandomBunny() => Main.rand.NextBool() ? NonExplosiveBunny() : NPCID.ExplosiveBunny;
		int NonExplosiveBunny() => Main.rand.NextBool() ? SpecialBunny() : GoldBunnyCheck();
		int GoldBunnyCheck() => Main.rand.NextBool(1, 20) ? NPCID.GoldBunny : NPCID.Bunny;
		int SpecialBunny()
		{
			return Main.rand.Next(0, 4) switch
			{
				0 => NPCID.BunnySlimed,
				1 => NPCID.BunnyXmas,
				2 => NPCID.PartyBunny,
				_ => GemBunny(),
			};
		}

		int GemBunny()
		{
			return Main.rand.Next(0, 7) switch
			{
				0 => NPCID.GemBunnyAmethyst,
				1 => NPCID.GemBunnyAmber,
				2 => NPCID.GemBunnyDiamond,
				3 => NPCID.GemBunnyEmerald,
				4 => NPCID.GemBunnyRuby,
				5 => NPCID.GemBunnySapphire,
				_ => NPCID.GemBunnyTopaz,
			};
		}
	}
}
