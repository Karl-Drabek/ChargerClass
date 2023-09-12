using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class TinCrossbow : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 37;
            Item.height = 13;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 5);

            Item.damage = 23;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.useTime = 24;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer) {
                  chargerProj.TinCanChance = 10 * chargeLevel;
            }

		public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);
            
		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TinBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}