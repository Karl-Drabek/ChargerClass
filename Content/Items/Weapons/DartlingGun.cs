using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Ammo;

namespace ChargerClass.Content.Items.Weapons
{
	public class DartlingGun : ChargeWeapon
	{

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

		public override void SafeSetDefaults()
		{
            Item.width = 54;
            Item.height = 22;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 14, 0, 0);

            Item.useTime = 24;
            Item.UseSound = SoundID.Item1;

            chargeAmount = 200;
            Item.damage = 68;
            Item.crit = 4;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<MonkeyDartProjectile>();
            Item.shootSpeed = 14f;
            Item.useAmmo = ModContent.ItemType<MonkeyDart>();

            ticsPerShot = 2;
            
            Item.noUseGraphic = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
        }
    }
}