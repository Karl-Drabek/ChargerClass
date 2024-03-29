using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons;

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

            public override bool SafeCanShoot(Player player) => GetChargeLevel(player) > 0;

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