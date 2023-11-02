﻿using Terraria;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalNPCs;

namespace ChargerClass.Content.Buffs;

public class LeadPoisoning : ModBuff
{
	public override void SetStaticDefaults() {
		Main.debuff[Type] = true;
	}

	public override void Update(NPC npc, ref int buffIndex) {
		npc.GetGlobalNPC<ModInstanceNPC>().LeadPoisoning = true;
	}
}