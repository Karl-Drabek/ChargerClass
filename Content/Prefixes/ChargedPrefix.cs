using ChargerClass.Common.Players;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Prefixes;

public class ChargedPrefix : ModPrefix
{
	public int maxChargeIncrease = 4;
	public LocalizedText TooltipDescription => Language.GetText("Mods.ChargerClass.CommonItemTooltip.MaxChargeIncrease").WithFormatArgs(maxChargeIncrease);
	public override PrefixCategory Category => PrefixCategory.Accessory;
	public override float RollChance(Item item) => 1f;
	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.1f;
	}
	/*
	>= 1.2 => +2;
	>= 1.05 => +1;
	<= 0.95 => -1;
	>= 0.8 => -2;
	*/
	public override void ApplyAccessoryEffects(Player player) {
		player.GetModPlayer<ChargeModPlayer>().MaxCharge += maxChargeIncrease / 100f;
	}
	public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
		yield return new TooltipLine(Mod, "PrefixWeaponChargedDescription", TooltipDescription.Value) {
			IsModifier = true,
		};
	}
	public override void SetStaticDefaults() {
		// This seemingly useless code is required to properly register the key for TooltipDescription
		_ = TooltipDescription;
	}
}