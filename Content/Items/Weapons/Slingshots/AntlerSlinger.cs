using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles.Holdouts.Slingshots;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class AntlerSlinger : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 22;
		Item.height = 44;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Green;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.useTime = 23;

		chargeAmount = 275;
		Item.DamageType = ChargerDamageClass.Instance;
		Item.damage = 51;
		Item.crit = 3;
		Item.knockBack = 3f;

		Item.shoot = ModContent.ProjectileType<AntlerSlingerHoldout>();
		Item.shootSpeed = 10f;
		Item.useAmmo = ModContent.ItemType<Ammo.Rocks.Rock>();
	}

	public override Vector2? HoldoutOffset() => new Vector2(4f, 0f);
}
