﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using Terraria.DataStructures;
using ChargerClass.Common.GlobalNPCs;

namespace ChargerClass.Content.Buffs
{
	public class RadiationSickness : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ChargeModPlayer>().RadiationSickness = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<ModInstanceNPC>().RadiationSickness = true;
		}
	}
}