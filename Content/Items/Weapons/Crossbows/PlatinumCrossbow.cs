using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class PlatinumCrossbow : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Platinum Crossbow");
			Tooltip.SetDefault("15% chance not to consume ammo.");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 350;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 21, 0);

            Item.damage = 19;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}

        public override void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo) {
            if (ChargerClassModSystem.Random.NextDouble() <= 0.15f * chargeLevels) consumeAmmo = false;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}