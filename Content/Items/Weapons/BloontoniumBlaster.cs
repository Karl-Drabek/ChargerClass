using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Ammo;

namespace ChargerClass.Content.Items.Weapons;

public class BloontoniumBlaster : ChargeWeapon
{

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

	public override void SafeSetDefaults()
	{
            Item.width = 54;
            Item.height = 22;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 22, 0, 0);

            Item.useTime = 22;
            Item.UseSound = SoundID.Item1;

            chargeAmount = 180;
            Item.damage = 76;
            Item.crit = 12;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<BloontoniumDartProjectile>();
            Item.shootSpeed = 16f;
            Item.useAmmo = ModContent.ItemType<BloontoniumDart>();

            ticsPerShot = 2;
            
            Item.noUseGraphic = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
        }

        public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DartlingGun>());
            recipe.AddIngredient(ModContent.ItemType<DepleatedBloontonium>(), 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
    }