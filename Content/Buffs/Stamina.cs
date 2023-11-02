﻿using Terraria;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Buffs;

public class Stamina : ModBuff
{
	public override void Update(Player player, ref int buffIndex) {
		player.GetModPlayer<ChargeModPlayer>().Stamina = true;
	}
}