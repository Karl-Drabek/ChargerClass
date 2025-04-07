﻿using ChargerClass.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Buffs;

public class LungCancer : ModBuff
{
	public override void SetStaticDefaults()
	{
		Main.debuff[Type] = true;
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<ChargeModPlayer>().LungCancerBuff = true;
	}
}