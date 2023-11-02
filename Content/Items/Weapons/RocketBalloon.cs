using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Weapons.Blowers;

namespace ChargerClass.Content.Items.Weapons;

public class RocketBalloon : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Pink;

                  chargeAmount = 500;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 14, 0, 0);
                  Item.useTime = 26;

                  Item.damage = 200;
                  Item.crit = 10;
                  Item.knockBack = 0f;
                  Item.maxStack = 999;
                  Item.consumable = true;

                  Item.shoot = ModContent.ProjectileType<RocketBalloonProjectile>();
                  Item.shootSpeed = 20f;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.SoulofFright, 16);
                  recipe.AddIngredient(ModContent.ItemType<Balloon>());
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
	}
}