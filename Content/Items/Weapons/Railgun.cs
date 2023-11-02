using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons
{
	public class Railgun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Pink;

                  chargeAmount = 100;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.buyPrice(0, 16, 0, 0);
                  Item.useTime = 36;

                  Item.damage = 450;
                  Item.crit = 0;
                  Item.knockBack = 0f;

                  Item.shoot = ModContent.ProjectileType<RailgunLaser>();
                  Item.shootSpeed = 0f;
		}
	}
}