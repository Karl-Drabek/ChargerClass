using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons
{
	public class HandCannon : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed;

            chargeAmount = 650;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 5, 50);
            Item.useTime = 32;

            Item.damage = 112;
            Item.crit = 5;
            Item.knockBack = 10f;

            Item.shoot = ModContent.ProjectileType<Projectiles.MiniCannonballProjectile>();
            Item.shootSpeed = 8f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.MiniCannonball>();
		}

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  if(Main.rand.NextBool(20 * chargeLevel, 100)){
                        type = ModContent.ProjectileType<Projectiles.HandCannonBombProjectile>();
                        damage = (int)(3f * damage);
                        knockback *= 3f;
                  }
            }
	}
}