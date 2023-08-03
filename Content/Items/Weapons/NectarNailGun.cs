using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class NectarNailGun : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nectar Nail Gun");
			Tooltip.SetDefault("Fire an extra nectar nail per charge");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 2, 0);

            Item.damage = 18;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<Projectiles.PelletProjectile>();
            Item.shootSpeed = 12f;
            Item.ammo = Item.type;
		}
	}
}