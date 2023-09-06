using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.Projectiles.Rocks;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class AntlerSlinger : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 2, 0, 0);;

            chargeAmount = 550;
            Item.DamageType = ModContent.GetInstance<ChargerDamageClass>();
            Item.damage = 25;
            Item.crit = 3;
            Item.knockBack = 3f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

            public override void SafePostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  if (chargeLevel > 0 && Main.rand.NextBool(20 * chargeLevel))chargerProj.Frostburn = true;
            }

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
                  type = ModContent.ProjectileType<FrozenRockProjectile>();
                  damage += (int)(damage* 0.25f);
            }

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}
	}
}