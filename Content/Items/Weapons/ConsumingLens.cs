using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Dusts;

namespace ChargerClass.Content.Items.Weapons;

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
            Item.useTime = 42;

            Item.damage = 5;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<Projectiles.ConsumingLensLaser>();
            Item.shootSpeed = 16f;
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

            int damageDealt = 0;
            public override void WhileCharging(Player player) {
                  for (int k = 0; k < Main.maxNPCs; k++) {
                        NPC target = Main.npc[k];
                        if(target.friendly || !target.active || target.dontTakeDamage) continue;
                        float distanceToNPC = Vector2.DistanceSquared(target.Center, Main.MouseScreen + Main.screenPosition);
                        if (distanceToNPC < 90_000){
                              if(Main.rand.NextBool(90_000 - (int)distanceToNPC, 90_000 * 5)){
                                    player.ApplyDamageToNPC(target, 1, 0, 0, false, ChargerDamageClass.Instance);
                                    if(++damageDealt > 10){
                                          player.Heal(1);
                                          damageDealt = 0;
                                    }
                                    Dust.NewDust(target.Center, target.width, target.height, ModContent.DustType<ConsumingDust>());
                              }
                        }
                  }
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