using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Prefixes;

public class Ecstatic : ModPrefix
{
	public int maxChargeIncrease = 10;
	public LocalizedText TooltipDescription => Language.GetText("Mods.ChargerClass.CommonItemTooltip.MaxChargeIncrease").WithFormatArgs(maxChargeIncrease);
	public override PrefixCategory Category => PrefixCategory.Ranged;
	public override float RollChance(Item item) => 8.5f;
	
	public override bool CanRoll(Item item) => item.DamageType.CountsAsClass(ChargerDamageClass.Instance);
	public override void ModifyValue(ref float valueMult) {
		valueMult *= 1.25f;
	}
	public override void Apply(Item item) {
		Main.LocalPlayer.GetModPlayer<ChargeModPlayer>().MaxCharge += maxChargeIncrease / 100f;
	}
	public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
		useTimeMult -= 0.22f;
		damageMult += 0.08f;
		critBonus += 8;
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