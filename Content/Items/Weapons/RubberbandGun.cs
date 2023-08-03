using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons
{
	public class RubberbandGun : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rubberband Gun");
			Tooltip.SetDefault("Flurry of rubber bands + rare RED (en fuego) rubberband");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 150;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 20);

            Item.damage = 10;
            Item.crit = 4;
            Item.knockBack = 0f;

            blowWeapon = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.RubberbandProjectile>();
            Item.shootSpeed = 7f;
            Item.useAmmo = ModContent.ItemType<Items.Weapons.Rubberband>();
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}