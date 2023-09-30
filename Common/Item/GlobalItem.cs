using System.Linq;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Content.Items.Weapons.Slingshots;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Weapons.Blowers;
using ChargerClass.Content.Items;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Common.GlobalItems
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
				default:
					break;
			}
		}

		public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack) {
			if(extractType == ItemID.GoldFrog || extractType != ItemID.Frog){
				if (extractinatorBlockType == TileID.ChlorophyteExtractinator){
					resultType = ModContent.ItemType<DartFrogExtract>();
					resultStack = (extractType == ItemID.GoldFrog) ? (int)Main.rand.NextFloat(2, 5) : 1;
				}else{
					resultType = ItemID.FrogLeg;
					resultStack = 1;
				}
			}else if(extractType == ModContent.ItemType<AncientDebris>()){
				if(Main.rand.NextBool(16)){
					resultType = ModContent.ItemType<AncientTech>();
					resultStack = (int)Main.rand.NextFloat(3, 7);
				}
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