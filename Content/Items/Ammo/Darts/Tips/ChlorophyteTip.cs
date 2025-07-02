using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class ChlorophyteTip : DartComponent
{
	public override void SafeSetDefaults()
	{
		Item.width = 10;
		Item.height = 6;

		Item.value = Item.sellPrice(0, 0, 0, 10);
		Item.rare = ItemRarityID.Lime;
		DartSheetPlacement = 8;
		Pen = 3;
		Item.damage = 29;
		Item.knockBack = 3f;
	}

	public override void OnHitNPC(
		Projectile projectile,
		NPC target,
		NPC.HitInfo hit,
		int damageDone,
		float buffTimeMultiplier
	)
	{
		target.AddBuff(BuffID.Poisoned, 300);
	}

	public override void AddRecipes()
	{
		Recipe recipe = CreateRecipe(25);
		recipe.AddIngredient(ItemID.AdamantiteBar);
		recipe.AddTile(TileID.MythrilAnvil);
		recipe.Register();
	}
}