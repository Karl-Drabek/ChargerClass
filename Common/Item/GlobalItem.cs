using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Content.Projectiles;

namespace ExampleMod.Common.GlobalItems
{
	public class BossBagLoot : GlobalItem
	{
		public override void ModifyItemLoot(Item item, ItemLoot itemLoot) {
			switch(item.type){
				case ItemID.DeerclopsBossBag:
					foreach (var rule in itemLoot.Get()) {
						if(rule is OneFromOptionsNotScaledWithLuckDropRule OptionsDropRule){
							var original = OptionsDropRule.dropIds.ToList();
							original.Add(ModContent.ItemType<AntlerSlinger>());
							OptionsDropRule.dropIds = original.ToArray();
						}
					}
				break;
			}
		}
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.BottledWater) {
				item.ammo = item.type;
				item.shoot = ModContent.ProjectileType<SuperSoakerProjectile>();
			}
		}
	}
}