using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class SuperSlime : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Slimer");
			Tooltip.SetDefault("Slime slows enemies for more length");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            chargeAmount = 100;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 31, 0);

            Item.damage = 17;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<Projectiles.PelletProjectile>();
            Item.shootSpeed = 4f;
            Item.ammo = Item.type;
		}

        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.SuperSoaker>(), 1);
            recipe.AddIngredient(ItemID.SlimeGun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}