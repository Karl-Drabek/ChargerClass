using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class Bellows : ChargeWeapon
	{

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 200;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 25);

            Item.damage = 6;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<Projectiles.BellowsAirProjectile>();
            Item.shootSpeed = 6f;
            Item.useAmmo = AmmoID.None; //Default, uses that same item as Ammo.
		}

            public override bool CanConsumeAmmo(Item item, Player player) => false;

            public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Blowers.Balloon>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}