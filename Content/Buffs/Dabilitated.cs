﻿using ChargerClass.Common.GlobalNPCs;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Buffs;

public class Dabilitated : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.GetGlobalNPC<ModInstanceNPC>().Dabilitated = true;
	}
}
