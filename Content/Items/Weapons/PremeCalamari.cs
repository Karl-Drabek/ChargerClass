using ChargerClass.Content.Projectiles.Holdouts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class PremeCalamari : ChargedWeapon
{
	public override void SafeSetDefaults()
	{
		Item.width = 26;
		Item.height = 82;
		Item.scale = 1f;
		Item.rare = ItemRarityID.LightRed;

		chargeAmount = 150;
		Item.useStyle = ItemUseStyleID.Shoot;

		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 4, 30);
		Item.useTime = 42;

		Item.damage = 4;
		Item.crit = 0;
		Item.knockBack = 3f;

		Item.shoot = ModContent.ProjectileType<PremeCalamariHoldout>();
		noAmmoProjectile = ModContent.ProjectileType<Projectiles.PremeCalamariLaser>();
		Item.noUseGraphic = true;
		Item.shootSpeed = 6f;
	}
}
