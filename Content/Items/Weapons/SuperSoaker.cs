using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class SuperSoaker : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Soaker");
			Tooltip.SetDefault("In ice the biome it freezes enemies & in the desert it evaporates.Charge increases the amount shot.");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 120;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 90, 0);

            Item.damage = 4;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<Projectiles.WaterSprayProjectile>();
            Item.shootSpeed = 4f;
            Item.ammo = Item.type;
		}
	}
}