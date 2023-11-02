using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Placeable;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Armor.MechArmor;

// The AutoloadEquip attribute automatically attaches an equip texture to this item.
// Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
[AutoloadEquip(EquipType.Legs)]
public class MechLeggings : ModItem
{

	public static int wingsSlot = -1;

	public override void Load(){
            wingsSlot = EquipLoader.AddEquipTexture(Mod, $"{Texture}", EquipType.Wings, name: $"{Name}"); //add _wings for animation
        }

	public override void SetStaticDefaults() { 
		if(wingsSlot != -1) ArmorIDs.Wing.Sets.Stats[wingsSlot] = new WingStats(120, 8f, 3f);
	}
	public static int ChargeDamageIncrease = 8;
	public static int MoveSpeedIncrease = 25;

	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeDamageIncrease, MoveSpeedIncrease);

	public override void SetDefaults() {
		Item.width = 18;
		Item.height = 18;
		Item.rare = ItemRarityID.Yellow;
		Item.value = Item.sellPrice(0, 26, 25, 0);
		Item.defense = 17;
	}
	public override void UpdateEquip(Player player) {
            player.GetDamage<ChargerDamageClass>() += ChargeDamageIncrease / 100f;
		player.moveSpeed += MoveSpeedIncrease / 100f;
		player.GetModPlayer<ChargeModPlayer>().MechLegs = true;
	}

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChargedComponents>(), 24);
		recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 12);
		recipe.AddIngredient(ItemID.RocketBoots);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
}