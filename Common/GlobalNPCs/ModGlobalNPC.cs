using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Items;
using ChargerClass.Common.ItemDropRules.DropConditions;
//TODO find if both drop rules could be combined.
namespace ChargerClass.Common.GlobalNPCs
{
	public class ModGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot) {
			if (!NPCID.Sets.CountsAsCritter[npc.type]){ //I'm not sure what counts as critter includes but it was in example mod.
				npcLoot.Add(ItemDropRule.ByCondition(new ChargeDropCondition(), ModContent.ItemType<Charge>(), 3));
				npcLoot.Add(ItemDropRule.ByCondition(new BlueChargeDropCondition(), ModContent.ItemType<BlueCharge>(), 3));
			}
		}
	}
}