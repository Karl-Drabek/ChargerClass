﻿using ChargerClass.Common.GlobalNPCs;
using ChargerClass.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Buffs;

public class Plague : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
		Main.pvpBuff[Type] = true;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.GetGlobalNPC<ModInstanceNPC>().Plagued = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<ChargeModPlayer>().Plagued = true;
	}
}
