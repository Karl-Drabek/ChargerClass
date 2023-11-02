using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Ammo;

namespace ChargerClass.Content.Items.Weapons;

public class HydraRocketLauncher : ChargeWeapon
{

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

	public override void SafeSetDefaults()
	{
            Item.width = 54;
            Item.height = 26;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 18, 0, 0);

            Item.useTime = 36;
            Item.UseSound = SoundID.Item1;

            chargeAmount = 180;
            Item.damage = 54;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<RocketPodProjectile>();
            Item.shootSpeed = 16f;
            Item.useAmmo = ModContent.ItemType<RocketPod>();

            ticsPerShot = 2;
            
            Item.noUseGraphic = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
        }

        public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BloontoniumBlaster>());
            recipe.AddIngredient(ItemID.ProximityMineLauncher);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
    }