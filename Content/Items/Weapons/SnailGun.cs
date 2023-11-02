using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons;

public class SnailGun : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Orange;

                  chargeAmount = 500;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 0, 12, 60);
                  Item.useTime = 24;

                  Item.damage = 420;
                  Item.crit = 0;
                  Item.knockBack = 0f;

                  Item.shoot = ModContent.ProjectileType<SnailProjectile>();
                  Item.shootSpeed = 14f;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ModContent.ItemType<SuperSlimer>());
                  recipe.AddIngredient(ModContent.ItemType<ExoticEscargot>());
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}