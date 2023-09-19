using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using System.Linq;
using System.Collections.Generic;
using Terraria.ModLoader;
using ChargerClass.Content.Items;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Items.Weapons.Blowers;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Common.ItemDropRules.DropConditions;
using ChargerClass.Content.Items.Ammo;

//TODO find if both drop rules could be combined.
namespace ChargerClass.Common.GlobalNPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public override void ModifyGlobalLoot(GlobalLoot globalLoot){
			globalLoot.Add(ItemDropRule.ByCondition(new ChargeDropCondition(), ModContent.ItemType<Charge>(), 3));
			globalLoot.Add(ItemDropRule.ByCondition(new BlueChargeDropCondition(), ModContent.ItemType<BlueCharge>(), 3));
		}

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot){
			switch(npc.type){
				case NPCID.Deerclops:
					foreach (var rule in npcLoot.Get()) {
						if (rule is LeadingConditionRule lcr && lcr.ChainedRules[0].RuleToChain is OneFromRulesRule OFRR && OFRR.options[0] is OneFromOptionsNotScaledWithLuckDropRule OFONSWLDR){
							var original = OFONSWLDR.dropIds.ToList();
							original.Add(ModContent.ItemType<AntlerSlinger>());
							OFONSWLDR.dropIds = original.ToArray();
						}
					}
					break;
				case NPCID.QueenBee:
					foreach (var rule in npcLoot.Get()) {
						if (rule is DropBasedOnExpertMode DBOEM && DBOEM.ruleForNormalMode is OneFromOptionsNotScaledWithLuckDropRule OFONSWLDR) {
							var original = OFONSWLDR.dropIds.ToList();
							original.Add(ModContent.ItemType<NectarNailGun>());
							OFONSWLDR.dropIds = original.ToArray();
						}
					}
					break;
				case NPCID.SkeletronHead:
					foreach (var rule in npcLoot.Get()) {
						if (rule is ItemDropWithConditionRule IDWC){
							IDWC.OnFailedRoll(ItemDropRule.Common(ModContent.ItemType<Tronbone>(), 7)); //check if Onfailed roll doesnt work at this point
						}
					}
					break;
				case NPCID.PirateCaptain:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HandCannon>(), 3));
					break;
				case NPCID.GoblinArcher:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LongBow>(), 75));
					break;
				case NPCID.BloodSquid:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PremeCalamari>(), 6));
					break;
				default:
					break;
			}
		}

		public override void ModifyShop(NPCShop shop) {
			if (shop.NpcType == NPCID.Dryad) shop.Add<Potato>();
		}

		public virtual void SetupTravelShop(int[] shop, ref int nextSlot){
			shop[nextSlot] = ModContent.ItemType<Airgun>();
		}
	}
}