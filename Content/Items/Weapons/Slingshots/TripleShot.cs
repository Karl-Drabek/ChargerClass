using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class TripleShot : ChargedWeapon
{
	public static readonly int AmmoChance = 10;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AmmoChance);

	public override void SafeSetDefaults()
	{
		Item.width = 24;
		Item.height = 40;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 50, 0);
		Item.useTime = 25;

		chargeAmount = 450;
		Item.damage = 20;
		Item.crit = 0;
		Item.knockBack = 1f;

		Item.shoot = ModContent.ProjectileType<TripleShotHoldout>();
		Item.shootSpeed = 8f;
		Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);
}
