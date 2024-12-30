﻿using ChargerClass.Common.GlobalNPCs;
using ChargerClass.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Buffs;

public class RadiationSickness : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<ChargeModPlayer>().RadiationSickness = true;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.GetGlobalNPC<ModInstanceNPC>().RadiationSickness = true;
	}
}
