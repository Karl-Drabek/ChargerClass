using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

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
            Item.useTime = 16;

            Item.damage = 35;
            Item.crit = 1;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
		}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  if(Main.rand.NextBool(chargeLevel * 5, 100)) chargerProj.CatchCritters = true;
            }
	}
}