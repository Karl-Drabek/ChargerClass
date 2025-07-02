﻿using ChargerClass.Common.Players;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Buffs;

public class Hate : ModBuff
{
	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<ChargeModPlayer>().RocketStormCooldown = true;
	}
}
