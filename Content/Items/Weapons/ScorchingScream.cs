using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class ScorchingScream : ChargeWeapon
	{
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 25);

            Item.damage = 16;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<Projectiles.ScorchingScreamProjectile>();
            Item.shootSpeed = 8f;
            Item.useAmmo = AmmoID.None;
		}

            public override bool CanConsumeAmmo(Item item, Player player) => false;

            public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 4);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Bellows>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}