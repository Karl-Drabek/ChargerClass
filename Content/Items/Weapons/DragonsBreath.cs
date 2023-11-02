using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons;

public class DragonsBreath : ChargeWeapon
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
                  Item.value = Item.sellPrice(0, 0, 0, 2);
                  Item.useTime = 32;

                  Item.damage = 80;
                  Item.crit = 0;
                  Item.knockBack = 0f;
                  Item.maxStack = 999;
                  Item.consumable = true;
                  ticsPerShot = 4;

                  Item.shoot = ModContent.ProjectileType<DragonsBreathProjectile>();
                  Item.shootSpeed = 12f;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.MolotovCocktail);
                  recipe.AddIngredient(ModContent.ItemType<ConcentratedGelSolution>());
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
	}
}