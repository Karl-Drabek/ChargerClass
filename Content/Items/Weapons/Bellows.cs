using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class Bellows : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
                  Item.width = 54;
                  Item.height = 32;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.White;

                  chargeAmount = 200;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 0, 1, 25);

                  Item.damage = 4;
                  Item.crit = 0;
                  Item.knockBack = 2f;
                  Item.useTime = 26;

                  ticsPerShot = 4;

                  Item.shoot = ModContent.ProjectileType<Projectiles.BellowsAirProjectile>();
                  Item.shootSpeed = 6f;
	}

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
            }

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe(8);
                  recipe.AddRecipeGroup(RecipeGroupID.IronBar, 4);
                  recipe.AddIngredient(ItemID.Wood, 12);
                  recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Blowers.Balloon>(), 1);
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}