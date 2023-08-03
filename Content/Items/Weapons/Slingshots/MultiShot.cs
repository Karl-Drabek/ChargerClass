using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class MultiShot : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MultiShot");
			Tooltip.SetDefault("Shoots an extra projectile for each charge level");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 200;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 4, 50, 0);

            Item.damage = 11;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.RockProjectile>();
            Item.shootSpeed = 9f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

        public override void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo) {
            count += chargeLevels;
        }

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Slingshots.TripleShot>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}