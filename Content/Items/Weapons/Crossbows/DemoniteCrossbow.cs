using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class DemoniteCrossbow : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demonite Crossbow");
			Tooltip.SetDefault("Increase projectile penetration by one per charge level.");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 36, 0);

            Item.damage = 21;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
		}

        public override PostProjectileEffects(ChargerProjectile chargerProj, int chargeLevel){
            chargerProj.Projectile.penetration += chargeLevel;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}