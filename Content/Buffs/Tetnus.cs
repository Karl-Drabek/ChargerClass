﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Buffs
{
	public class LightHeaded : ModBuff
	{
		private int _timer;

		public override void SetStaticDefaults() {
			Main.debuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			_timer++;
			if(timer >= 30){
				npc.StrikeNPCNoInteraction(1, 0, 0);
				timer = 0;
			}
		}
	}
}