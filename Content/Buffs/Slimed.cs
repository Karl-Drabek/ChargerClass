﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Buffs
{
	public class Slimed : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.velocity *= 0.8f;
		}
	}
}