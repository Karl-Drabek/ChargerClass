﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Buffs
{
	public class Tetnus : ModBuff
	{
		private int _timer;

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			_timer++;
			if(_timer >= 30){
				npc.SimpleStrikeNPC(1 , 0);
				_timer = 0;
			}
		}
	}
}