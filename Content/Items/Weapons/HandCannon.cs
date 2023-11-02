using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;
using ChargerClass.Content.Projectiles;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons
{
	public class HandCannon : ChargeWeapon
	{
            public static readonly int FragChance = 10;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(FragChance);
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

            Item.shoot = ModContent.ProjectileType<Projectiles.HandCannonBombProjectile>();
            Item.shootSpeed = 8f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.MiniCannonball>();
		}

		public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  if(Main.rand.NextBool(Utils.Clamp(FragChance * chargeLevel, 0, 100), 100)) proj.ai[2] = 1f;
            }
	}
}