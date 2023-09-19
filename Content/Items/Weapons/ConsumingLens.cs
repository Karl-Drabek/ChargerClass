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
	public class ConsumingLens : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 200;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 40);
            Item.useTime = 46;

            Item.damage = 5;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<Projectiles.ConsumingLensLaser>();
            Item.shootSpeed = 16f;
		}

            public override bool SafeCanShoot(Player player) => GetChargeLevel() > 0;

            public override void ItemAnimation(Player player){
                  float mouseRotation = (float)Math.Atan2((Main.MouseWorld.Y - player.Center.Y) * player.direction, (Main.MouseWorld.X - player.Center.X) * player.direction);
                  float difference = mouseRotation - player.itemRotation;
                  float change  = difference / 10 + ((difference > 0)? 0.001f : -0.001f);
                  player.itemRotation += ((difference > 0)? change : difference) > ((difference > 0)? difference : change) ? difference : change;
                  if(player.itemRotation > MathHelper.ToRadians(90) || player.itemRotation < MathHelper.ToRadians(-90)){
                        player.ChangeDir(-player.direction);
                        player.itemRotation *= -1;
                  }
            }

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                 modPlayer.Player.itemAnimation = proj.timeLeft = Item.useAnimation = 50 * chargeLevel;
            }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BlackLens, 4);
            recipe.AddIngredient(ItemID.Lens, 4);
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}