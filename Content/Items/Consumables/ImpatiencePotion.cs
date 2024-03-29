using ChargerClass.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Consumables;

public class ImpatiencePotion : ModItem
{
	public static readonly int ChargeLevelDecrease = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ChargeLevelDecrease);
	public override void SetStaticDefaults() {
		Item.ResearchUnlockCount = 20;

		// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
		ItemID.Sets.DrinkParticleColors[Type] = new Color[]{
			new Color(240, 240, 240),
			new Color(200, 200, 200),
			new Color(140, 140, 140)
		};
	}

	public override void SetDefaults() {
		Item.width = 20;
		Item.height = 26;
		Item.useStyle = ItemUseStyleID.DrinkLiquid;
		Item.useAnimation = 15;
		Item.useTime = 15;
		Item.useTurn = true;
		Item.UseSound = SoundID.Item3;
		Item.maxStack = 30;
		Item.consumable = true;
		Item.rare = ItemRarityID.Blue;
		Item.value = Item.sellPrice(0, 0, 2, 0);
		Item.buffType = ModContent.BuffType<Buffs.Impatience>();
		Item.buffTime = 5400;
	}

	public override void AddRecipes() {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Waterleaf);
		recipe.AddIngredient(ItemID.Shiverthorn);
            recipe.AddIngredient(ItemID.BottledWater);
		recipe.AddIngredient(ModContent.ItemType<AncientDebris>());
		recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
}