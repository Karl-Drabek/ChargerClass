using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Prefixes
{
	public class Exuberant : ModPrefix
	{
		public int maxChargeIncrease = -5;
		public LocalizedText TooltipDescription => Language.GetText("Mods.ChargerClass.CommonItemTooltip.MaxChargeIncrease").WithFormatArgs(maxChargeIncrease);
		public override PrefixCategory Category => PrefixCategory.Ranged;
		public override float RollChance(Item item) => 9f;
		
		public override bool CanRoll(Item item) => item.DamageType.CountsAsClass(ChargerDamageClass.Instance);
		public override void ModifyValue(ref float valueMult) {
			valueMult *= 1.15f;
		}
		public override void Apply(Item item) {
			Main.LocalPlayer.GetModPlayer<ChargeModPlayer>().MaxCharge -= maxChargeIncrease / 100f;
		}
		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus) {
			damageMult -= 0.1f;
			useTimeMult -= 0.2f;
			critBonus += 15;
			shootSpeedMult += 0.15f;
			knockbackMult += 0.2f;
		}
		public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
			yield return new TooltipLine(Mod, "PrefixWeaponChargedDescription", TooltipDescription.Value) {
				IsModifier = true,
				IsModifierBad = true,
			};
		}
		public override void SetStaticDefaults() {
			// This seemingly useless code is required to properly register the key for TooltipDescription
			_ = TooltipDescription;
		}
	}
}