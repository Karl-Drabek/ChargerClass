using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class TungstenCrossbow : ChargeWeapon
	{
        public override void SetStaticDefaults() {
                Item.ResearchUnlockCount = 1;
        }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 450;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 27;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 10, 50);

            Item.damage = 33;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            damage += 5 * chargeLevel;
        }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TungstenBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}