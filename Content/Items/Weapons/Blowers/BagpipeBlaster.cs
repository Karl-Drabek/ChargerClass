using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers
{
	public class BagpipeBlaster : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 90;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 20, 55);
            Item.useTime = 42;
            ticsPerShot = 3;

            Item.damage = 54;
            Item.crit = 0;
            Item.knockBack = 1f;

            blowWeapon = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Dart;
		}

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2));
            }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Leather, 5);
            recipe.AddIngredient(ItemID.BreathingReed, 1);
            recipe.AddIngredient(ItemID.Blowgun, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Blowers.Balloon>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}