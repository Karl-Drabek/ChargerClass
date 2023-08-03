using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class GoldCrossbow : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Crossbow");
			Tooltip.SetDefault("Midas touch 5% (extra gold)");
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
            Item.value = Item.sellPrice(0, 0, 14, 0);

            Item.damage = 17;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}