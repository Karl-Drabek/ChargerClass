using Microsoft.Xna.Framework;
using ChargerClass;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons
{
	public class SupremeCalamari : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 26;
            Item.height = 82;
            Item.scale = 1f;
            Item.rare = -13;

            chargeAmount = 1000;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(2366, 15, 43, 30);
            Item.useTime = 10;

            Item.damage = 9743234;
            Item.crit = 400;
            Item.knockBack = 112f;

            Item.shoot = ModContent.ProjectileType<Projectiles.SupremeCalamariProjectile>();
            Item.shootSpeed = 10f;

            Item.noUseGraphic = true;
		}

            public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset) {
                  muzzleOffset.Y -= 10;
            }
	}
}