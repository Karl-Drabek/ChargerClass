using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class CrimtaneCrossbow : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimtane Crossbow");
			Tooltip.SetDefault("Deal 3 extra damage per charge. Shots cause bleeding");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 450;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 36, 0);

            Item.damage = 24;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 11f;
            Item.useAmmo = AmmoID.Arrow;
		}

        public override void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo) 
        {
            damage += chargeLevels * 3
        }

        public override void PostProjectileEffects(ChargerProjectile chargerProj, int chargeLevel){
            chargerProjectile.Hellfire = true;
            if (ChargerClassModSystem.Random.NextDouble() <= 0.25f * chargeLevels) chargerProj.ExplosionSize = 30 * chargeLevel;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}