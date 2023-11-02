using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChargerClass.Common.Players;
using ChargerClass.Content.Projectiles;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons;

public class RayOfBloon : ChargeWeapon
{

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

	public override void SafeSetDefaults()
	{
            Item.width = 84;
            Item.height = 38;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 24, 0, 0);

            Item.useTime = 36;
            Item.UseSound = SoundID.Item1;

            chargeAmount = 200;
            Item.damage = 356;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<RayOfBloonLaser>();
            Item.shootSpeed = 15f;

            ticsPerShot = 2;
            
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

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
        }

        public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LaserDartlingGun>());
            recipe.AddIngredient(ItemID.FragmentSolar, 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
    }