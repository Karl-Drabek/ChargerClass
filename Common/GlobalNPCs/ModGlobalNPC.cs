using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using System.Linq;
using Terraria.ModLoader;
using ChargerClass.Content.Items;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Common.ItemDropRules.DropConditions;
using ChargerClass.Content.Items.Ammo;
using ChargerClass.Content.Items.Ammo.Darts.Tails;
using ChargerClass.Content.Items.Weapons.Blowers;

//TODO find if both drop rules could be combined.
namespace ChargerClass.Common.GlobalNPCs;

public class ModGlobalNPC : GlobalNPC
{
	public override void SetStaticDefaults(){
		NPCID.Sets.MPAllowedEnemies[NPCID.ExplosiveBunny] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GoldBunny] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.Bunny] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.BunnySlimed] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.BunnyXmas] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.PartyBunny] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnyAmethyst] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnyAmber] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnyDiamond] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnyEmerald] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnyRuby] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnySapphire] = true;
		NPCID.Sets.MPAllowedEnemies[NPCID.GemBunnyTopaz] = true;
	}
	public override void ModifyGlobalLoot(GlobalLoot globalLoot){
		globalLoot.Add(ItemDropRule.ByCondition(new ChargeDropCondition(), ModContent.ItemType<YellowCharge>(), 5));
		globalLoot.Add(ItemDropRule.ByCondition(new OrangeChargeDropCondition(), ModContent.ItemType<OrangeCharge>(), 4));
		globalLoot.Add(ItemDropRule.ByCondition(new BlueChargeDropCondition(), ModContent.ItemType<BlueCharge>(), 3));
	}

	public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot){
		switch(npc.type){
			case NPCID.Deerclops:
				foreach (var rule in npcLoot.Get()) {
					if (rule is LeadingConditionRule lcr){
						foreach(var chainedRule in lcr.ChainedRules){
							if(chainedRule.RuleToChain is OneFromRulesRule OFRR){
								foreach(var subRule in OFRR.options){
									if(subRule is OneFromOptionsNotScaledWithLuckDropRule rules && rules.dropIds.Contains(ItemID.PewMaticHorn)){
										var original = rules.dropIds.ToList();
										original.Add(ModContent.ItemType<AntlerSlinger>());
										rules.dropIds = original.ToArray();
										return;
									}
								}
							}
						}
					}
				}
				break;
			case NPCID.QueenBee:
				foreach (var rule in npcLoot.Get()) {
					if (rule is DropBasedOnExpertMode DBOEM && DBOEM.ruleForNormalMode is OneFromOptionsNotScaledWithLuckDropRule OFONSWLDR) {
						var original = OFONSWLDR.dropIds.ToList();
						original.Add(ModContent.ItemType<NectarNailGun>());
						OFONSWLDR.dropIds = original.ToArray();
						return;
					}
				}
				break;
			case NPCID.DukeFishron:
				foreach (var rule in npcLoot.Get()) {
					if (rule is LeadingConditionRule lcr){
						foreach(var chainedRule in lcr.ChainedRules){
							if (chainedRule.RuleToChain is LeadingConditionRule lcr2){
								foreach(var chainedRule2 in lcr2.ChainedRules){
									if(chainedRule2.RuleToChain is OneFromOptionsDropRule OFOR && OFOR.dropIds.Contains(ItemID.Flairon)){
										var original = OFOR.dropIds.ToList();
										original.Add(ModContent.ItemType<HydrantHoser>());
										OFOR.dropIds = original.ToArray();
										return;
									}
								}
							}
						}
					}
				}
				break;
			case NPCID.HallowBoss:
				foreach (var rule in npcLoot.Get()) {
					if (rule is LeadingConditionRule lcr){
						foreach(var chainedRule in lcr.ChainedRules){
							if(chainedRule.RuleToChain is OneFromOptionsDropRule OFOR && OFOR.dropIds.Contains(ItemID.PiercingStarlight)){
								var original = OFOR.dropIds.ToList();
								original.Add(ModContent.ItemType<Refractinator>());
								OFOR.dropIds = original.ToArray();
								return;
							}
						}
					}
				}
				break;
			case NPCID.SkeletronHead:
				foreach (var rule in npcLoot.Get()) {
					if (rule is ItemDropWithConditionRule IDWC && IDWC.itemId == ItemID.SkeletronMask){
						foreach(var chainedRule in IDWC.ChainedRules){
							if(chainedRule.RuleToChain is CommonDrop cDrop && cDrop.itemId == ItemID.SkeletronHand ){ 
								foreach(var chainedRule2 in cDrop.ChainedRules){
									if(chainedRule2.RuleToChain is CommonDrop cDrop2 && cDrop2.itemId == ItemID.BookofSkulls){
										IDWC.OnFailedRoll(ItemDropRule.Common(ModContent.ItemType<Tronbone>(), 7));
										return;
									}
								}
							}
						}
					}
				}
				break;
			case NPCID.PirateCaptain:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HandCannon>(), 3));
				return;
			case NPCID.GoblinArcher:
				return;
			case NPCID.BloodSquid:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PremeCalamari>(), 6));
				return;
			case NPCID.BlueJellyfish or NPCID.PinkJellyfish or NPCID.GreenJellyfish:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<JellyfishTentacle>(), 5));
				return;
			case NPCID.MartianTurret:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TeslaCoil>(), 20));
				return;
			case NPCID.PresentMimic or NPCID.Flocko or 
				NPCID.GingerbreadMan or NPCID.ZombieElf or 
				NPCID.ElfArcher or NPCID.Nutcracker or 
				NPCID.Yeti or NPCID.ElfCopter or 
				NPCID.Krampus or NPCID.Everscream or
				NPCID.SantaNK1 or NPCID.IceQueen:
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChristmasCheer>(), 10));
				return;
			default:
				return;
		}
	}

	public override void ModifyShop(NPCShop shop) {
		switch(shop.NpcType){
			case NPCID.Dryad:
				shop.Add<Potato>();
				break;
			case NPCID.DD2Bartender:
				shop.Add(new Item(ModContent.ItemType<BetsysBackwash>()) {
					shopCustomPrice = 10,
					shopSpecialCurrency = CustomCurrencyID.DefenderMedals
				}, Condition.DownedOldOnesArmyT3);
				shop.Add(new Item(ModContent.ItemType<MagesTail>()) {
					shopCustomPrice = 1,
					shopSpecialCurrency = CustomCurrencyID.DefenderMedals
				});
				break;
			case NPCID.ArmsDealer:
				shop.Add(ModContent.ItemType<BetsysBackwash>(), Condition.DownedMechBossAny);
				shop.Add(ModContent.ItemType<DepleatedBloontonium>(), Condition.DownedMechBossAll);
				shop.Add(ModContent.ItemType<DartlingGun>(), Condition.DownedSkeletron);
				shop.Add(ModContent.ItemType<MonkeyDart>(), Condition.DownedSkeletron);
				break;

		}
	}

	public override void SetupTravelShop(int[] shop, ref int nextSlot){
		shop[nextSlot] = ModContent.ItemType<Airgun>();
	}
}