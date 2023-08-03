using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class Cannon : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cannon");
			Tooltip.SetDefault("Chance to shoot bomb");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed;

            chargeAmount = 1050;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 5, 50);

            Item.damage = 36;
            Item.crit = 5;
            Item.knockBack = 10f;

            Item.shoot = ModContent.ProjectileType<Projectiles.PelletProjectile>();
            Item.shootSpeed = 8f;
            Item.ammo = Item.type;
		}
	}
}