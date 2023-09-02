using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.DamageClasses
{
	public class ChargerDamageClass : DamageClass
	{

		public static ChargerDamageClass Instance => ModContent.GetInstance<ChargerDamageClass>();
		
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass) =>
            damageClass == DamageClass.Generic || damageClass == DamageClass.Ranged
            ? StatInheritanceData.Full : StatInheritanceData.None;

		public override bool GetEffectInheritance(DamageClass damageClass) => damageClass == DamageClass.Ranged;
	}
}