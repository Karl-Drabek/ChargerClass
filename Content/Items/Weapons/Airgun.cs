using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class Airgun : ChargeWeapon
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

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 40);

            Item.damage = 14;
            Item.crit = 1;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<Projectiles.PelletProjectile>();
            Item.shootSpeed = 10f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Pellet>();
		}

            public override void ModifyOtherStats(Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2) {
                  if(Main.rand.NextBool(chargeLevel * 5, 100)) ai0 = 1f;
            }
	}
}