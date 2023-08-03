using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class CopperCrossbow : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copper Crossbow");
			Tooltip.SetDefault("Projectiles move 25% faster in water (rain) +10% per charge");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 70);

            Item.damage = 8;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}