using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Weapons.Blowers;

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
				case ItemID.QueenBeeBossBag:
					foreach (var rule in itemLoot.Get()) {
						if (rule is OneFromOptionsNotScaledWithLuckDropRule OFONSWLDR) {
							var original = OFONSWLDR.dropIds.ToList();
							original.Add(ModContent.ItemType<NectarNailGun>());
							OFONSWLDR.dropIds = original.ToArray();
						}
					}
					break;
				case ItemID.SkeletronBossBag:
					foreach (var rule in itemLoot.Get()) {
						if (rule is OneFromOptionsNotScaledWithLuckDropRule OFONSWLDR) {
							var original = OFONSWLDR.dropIds.ToList();
							original.Add(ModContent.ItemType<Tronbone>());
							OFONSWLDR.dropIds = original.ToArray();
						}
					}
					break;
				case ItemID.ObsidianLockbox:
					foreach (var rule in itemLoot.Get()) {
						if (rule is OneFromOptionsNotScaledWithLuckDropRule OFONSWLDR) {
							var original = OFONSWLDR.dropIds.ToList();
							original.Add(ModContent.ItemType<MolotovMortar>());
							OFONSWLDR.dropIds = original.ToArray();
						}
					}
					break;
				break;
			}
		}

		public override void SetDefaults(Item item) {
			switch(item.type){
				case ItemID.BottledWater:
					item.ammo = item.type;
					item.shoot = ModContent.ProjectileType<SuperSoakerProjectile>();
					break;
				case ItemID.MolotovCocktail:
					item.ammo = item.type;
					break;
			}
		}
	}
}