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
	public class PremeCalamari : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 26;
            Item.height = 82;
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed;

            chargeAmount = 150;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 4, 30);
            Item.useTime = 72;

            Item.damage = 48;
            Item.crit = 0;
            Item.knockBack = 3f;

            Item.shoot = ModContent.ProjectileType<Projectiles.PremeCalamariLaser>();
            Item.shootSpeed = 6f;

            Item.noUseGraphic = true;
		}

            public override bool SafeCanShoot(Player player) => GetChargeLevel() > 0;

            public override void ItemAnimation(Player player){
                  player.ChangeDir(Main.MouseWorld.X > player.Center.X ? 1 : -1);
                  float mouseRotation = (float)Math.Atan2((Main.MouseWorld.Y - player.Center.Y) * player.direction, (Main.MouseWorld.X - player.Center.X) * player.direction);
                  player.itemRotation = mouseRotation;
            }

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                 modPlayer.Player.itemAnimation = proj.timeLeft = Item.useAnimation = 20 * chargeLevel;
            }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Lens, 4);
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}