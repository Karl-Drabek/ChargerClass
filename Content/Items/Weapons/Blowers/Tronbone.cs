using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers
{
	public class Tronbone : ChargeWeapon
	{

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 10, 0);

            Item.damage = 8;
            Item.crit = 2;
            Item.knockBack = 1f;

            blowWeapon = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.TronboneSonicProjectile>();
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.None;
		}

            public override bool CanConsumeAmmo(Item item, Player player) => false;
	}
}