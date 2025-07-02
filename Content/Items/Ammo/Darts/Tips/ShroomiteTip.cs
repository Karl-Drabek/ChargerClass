using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class ShroomiteTip : DartComponent
{
	private int bounces = 4;

	public override void SafeSetDefaults()
	{
		Item.width = 10;
		Item.height = 6;

		Item.value = Item.sellPrice(0, 0, 0, 10);
		Item.rare = ItemRarityID.Lime;
		DartSheetPlacement = 9;
		Pen = 2;
		Bounce = true;
		Item.damage = 34;
		Item.knockBack = 3f;
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(25);
		recipe.AddIngredient(ItemID.ShroomiteBar);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}
