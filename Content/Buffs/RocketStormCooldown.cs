﻿﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Buffs
{
	public class RocketStormCooldown : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ChargeModPlayer>().RocketStormCooldown = true;
		}
	}
}