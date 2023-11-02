using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons;

public class LaserDartlingGun : ChargeWeapon
{

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

	public override void SafeSetDefaults()
	{
            Item.width = 82;
            Item.height = 36;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 14, 0, 0);

            Item.useTime = 22;
            Item.UseSound = SoundID.Item1;

            chargeAmount = 180;
            Item.damage = 94;
            Item.crit = 12;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.RayGunnerLaser;
            Item.shootSpeed = 16f;

            ticsPerShot = 2;
            
            Item.noUseGraphic = true;
        }

        public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
            proj.hostile = false;
            proj.friendly = true;
            proj.penetrate = 6;
            proj.usesLocalNPCImmunity = true;
		proj.localNPCHitCooldown = 10;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
        }

        public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BloontoniumBlaster>());
            recipe.AddIngredient(ItemID.LihzahrdPowerCell, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
    }