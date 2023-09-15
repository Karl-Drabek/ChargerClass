using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class PotatoCannon : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 28;      

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 2, 30);

            Item.damage = 34;
            Item.crit = 0;
            Item.knockBack = 3f;

            Item.shoot = ModContent.ProjectileType<Projectiles.PotatoProjectile>();
            Item.shootSpeed = 8f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Potato>();
		}

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  if(Main.rand.NextBool(10 * chargeLevel, 100)){
                        type = ModContent.ProjectileType<Projectiles.HotPotatoProjectile>();
                        damage = (int)(3f * damage);
                        knockback *= 3f;
                  }
            }
	}
}