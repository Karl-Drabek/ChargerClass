using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons;

public class RailRailGun : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Red;

                  chargeAmount = 500;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 8, 0, 0);
                  Item.useTime = 44;

                  Item.damage = 1320;
                  Item.crit = 0;
                  Item.knockBack = 2f;

                  Item.shoot = ModContent.ProjectileType<RailRailGunProjectile>();
                  Item.shootSpeed = 14f;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ModContent.ItemType<Railgun>());
                  recipe.AddIngredient(ItemID.MechanicalWagonPiece);
                  recipe.AddIngredient(ItemID.FragmentVortex, 14);
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}