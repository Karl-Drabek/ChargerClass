using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons
{
	public class CentrifugalGun : ChargeWeapon
	{

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

		public override void SafeSetDefaults()
		{
            Item.width = 82;
            Item.height = 36;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 0, 1, 40);

            Item.useTime = 40;
            Item.UseSound = SoundID.Item1;

            chargeAmount = 225;
            Item.damage = 73;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 15f;
            Item.useAmmo = AmmoID.Bullet;

            ticsPerShot = 5;

            Item.noMelee = true;
            Item.autoReuse = true;
            Item.noUseGraphic = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
        }
    }
}