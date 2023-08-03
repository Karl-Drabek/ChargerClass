﻿using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;
using ChargerClass.Common.Players;

namespace ChargerClass.Common.ItemDropRules.DropConditions
{
	public class ChargeDropCondition : IItemDropRuleCondition //I dont know what anything in this class does, just make sure CanDrop returns true when you want a drop
	{
		private static LocalizedText Description;

		public ChargeDropCondition() {
			Description ??= Language.GetText("Mods.ChargerClass.DropConditions.Charge");
		}

		public bool CanDrop(DropAttemptInfo info) => Main.LocalPlayer.GetModPlayer<ChargeModPlayer>().GetLightningRod() == 1;

		public bool CanShowItemDropInUI() => true;

		public string GetConditionDescription() => Description.Value;
	}
}