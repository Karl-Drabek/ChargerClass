using ChargerClass.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items;

public class RadioactiveDebris : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 25;
	}

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 18;

		Item.maxStack = 999;
		Item.value = Item.sellPrice(0, 0, 1, 50);
		Item.rare = ItemRarityID.LightPurple;
	}

	public override void UpdateInventory(Player player)
	{
		player.AddBuff(ModContent.BuffType<RadiationSickness>(), 60);
	}

	public override void Update(ref float gravity, ref float maxFallSpeed)
	{
		if (Main.rand.NextBool(6))
			Dust.NewDustDirect(
				Item.position,
				Item.width,
				Item.height,
				DustID.GreenFairy,
				Scale: 0.4f
			);
		Lighting.AddLight(Item.position, 0, 1, 0);
	}
}
