﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using Terraria.DataStructures;

namespace ChargerClass.Content.Buffs
{
	public class RadiationSickness : ModBuff
	{
		private int _timer;

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			_timer++;
			if(_timer >= 5){
				npc.SimpleStrikeNPC(8, npc.direction);
				_timer = 0;
			}
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<ChargeModPlayer>().RadiationSickness = true;
			player.Hurt(PlayerDeathReason.ByOther(8), 1, player.direction);
		}
	}
}