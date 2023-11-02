using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Content.Items.Weapons
{
	public class MegaMortar : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Yellow;

                  chargeAmount = 500;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 14, 0, 0);
                  Item.useTime = 36;

                  Item.damage = 1120;
                  Item.crit = 0;
                  Item.knockBack = 6f;

                  Item.shoot = ModContent.ProjectileType<MegaMortarProjectile>();
                  Item.shootSpeed = 20f;
		}

            public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ModContent.ItemType<HandCannon>());
                  recipe.AddIngredient(ModContent.ItemType<MolotovMortar>());
                  recipe.AddIngredient(ModContent.ItemType<UnstableChaosShard>(), 20);
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
		}
	}
}