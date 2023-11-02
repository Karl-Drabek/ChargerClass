using Microsoft.Xna.Framework;
using ChargerClass;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons
{
	public class TeslaCoil : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
                  Item.width = 60;
                  Item.height = 28;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Yellow;

                  chargeAmount = 500;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 8, 0, 0);
                  Item.useTime = 25;

                  Item.damage = 340;
                  Item.crit = 6;
                  Item.knockBack = 1f;
                  ticsPerShot = 1;

                  Item.shoot = ProjectileID.PurificationPowder;
                  Item.shootSpeed = 0f;
		}

            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
                  NPC closestNPC = null;
                  float sqrMaxDetectDistance = 100_00_00;
                  float currentDistanceSquared = float.MaxValue;
			for (int k = 0; k < Main.maxNPCs; k++) {
				NPC target = Main.npc[k];
				if (Collision.CanHit(position, 1, 1, target.position, 1, 1) && target.CanBeChasedBy()) {
                              float squareDistanceToNPC = Vector2.DistanceSquared(target.Center, position);
					if (squareDistanceToNPC < sqrMaxDetectDistance){
                                    squareDistanceToNPC = Vector2.DistanceSquared(target.Center, Main.MouseScreen + Main.screenPosition);
                                    if(squareDistanceToNPC < currentDistanceSquared){
                                          closestNPC = target;
                                          currentDistanceSquared = squareDistanceToNPC;
                                    }
					}
				}
			}
                  if(closestNPC is not null){
                        Projectile projectile = Projectile.NewProjectileDirect(source, position, Vector2.Zero, ModContent.ProjectileType<LightningProjectile>(), damage, knockback, player.whoAmI, closestNPC.whoAmI, 0f);
                        projectile.scale = 2f;
                  }
                  return false;
            }
	}
}