using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns
{
	public class HellfireBlowgun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 82;
            Item.height = 20;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 25, 0);

            Item.damage = 132;
            Item.crit = 6;
            Item.knockBack = 4f;
            Item.useTime = 26;

            blowWeapon = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 16f;
            Item.useAmmo = AmmoID.Dart;
		}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  chargerProj.Hellfire = true;
            }

            public override void SafeModifyWeaponCrit(Player player, ref float crit){
                  crit += chargeLevel * 10f;
            }

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  velocity *= 10f * (chargeLevel + 1);
            }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.Blowgun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}