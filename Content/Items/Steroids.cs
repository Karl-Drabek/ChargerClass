using ChargerClass.Common.Players;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class Steroids : ModItem
{
	public override void SetDefaults()
	{
		Item.useStyle = ItemUseStyleID.DrinkLiquid	;
		Item.consumable = true;
		Item.useAnimation = 45;
		Item.useTime = 45;
		Item.UseSound = SoundID.Item92;
		Item.width = 28;
		Item.height = 28;
		Item.maxStack = Item.CommonMaxStack;
		Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 5));
	}

	public override bool? UseItem(Player player) => true;

	public override void OnConsumeItem(Player player){
		player.GetModPlayer<ChargeModPlayer>().UseSteroids();
	} 	
}
