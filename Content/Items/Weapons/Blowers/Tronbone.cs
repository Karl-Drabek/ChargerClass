using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons.Blowers
{
	public class Tronbone : ChargeWeapon
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

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 10, 0);
            ticsPerShot = 1;
            Item.autoReuse = true;

            Item.damage = 8;
            Item.crit = 2;
            Item.knockBack = 1f;

            blowWeapon = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.TronboneSonicProjectile>();
            Item.shootSpeed = 10f;
		}

            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
                  if(ShotsRemaining != chargeLevel) return true;
                  StatModifier modifier = player.GetTotalDamage(ModContent.GetInstance<ChargerDamageClass>()); //chargedamage class damage modifier
                  player.GetModPlayer<ChargeModPlayer>().ModifyWeaponDamage(Item, ref modifier); //I'm not using CombinedHooks/Item to avoid scaling with charge percent
                  int count = (int)(Main.rand.NextFloat(chargeLevel * 2, chargeLevel * 3) + 0.5f);
                  for(int i = 0; i < count; i++){
                        Projectile proj = Projectile.NewProjectileDirect(source, position,
                              Vector2.Normalize(Main.MouseWorld - player.Center)
                              .RotatedByRandom(MathHelper.ToRadians(15)) * (chargeLevel * 2f + 4f + (float)Main.rand.NextDouble() * 2.5f),
                              ProjectileID.Bone, (int)modifier.ApplyTo(25), 1f);
                        InternalPostProjectileEffects(proj, player.GetModPlayer<ChargeModPlayer>());
                  }
                  return true;
            }

            public override bool CanConsumeAmmo(Item item, Player player) => false;
	}
}