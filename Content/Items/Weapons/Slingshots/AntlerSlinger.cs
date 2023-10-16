using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.Projectiles.Rocks;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class AntlerSlinger : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 22;
            Item.height = 44;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.useTime = 23;

            chargeAmount = 275;
            Item.DamageType = ChargerDamageClass.Instance;
            Item.damage = 73;
            Item.crit = 3;
            Item.knockBack = 3f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}     

            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){

                  int projectile = ModContent.ProjectileType<IceSpikeProjectile>();
                  StatModifier modifier = player.GetTotalDamage(ChargerDamageClass.Instance); //chargedamage class damage modifier
                  player.GetModPlayer<ChargeModPlayer>().ModifyWeaponDamage(Item, ref modifier); //I'm not using CombinedHooks/Item to avoid scaling with charge percent            
                  for(int i = 0; i < chargeLevel; i++){
                        Projectile proj = Projectile.NewProjectileDirect(source, position,
                              Vector2.Normalize(Main.MouseWorld - player.Center)
                              .RotatedByRandom(MathHelper.ToRadians(15)) * (chargeLevel * 2 + 5f + (float)Main.rand.NextDouble() * 1.5f),
                              projectile, (int)modifier.ApplyTo(41), 1f);
                        CombinedPostProjectileEffects(proj, player.GetModPlayer<ChargeModPlayer>());
                  }
                  return true;
            }

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}
	}
}