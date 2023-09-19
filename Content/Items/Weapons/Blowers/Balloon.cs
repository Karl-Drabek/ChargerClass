using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Blowers
{
	public class Balloon : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 300;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 3);
            Item.useTime = 24;

            Item.damage = 33;
            Item.crit = 2;
            Item.knockBack = 2f;
            Item.maxStack = 999;
            Item.consumable = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.BalloonProjectile>();
            Item.shootSpeed = 4f;
		}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  proj.timeLeft += chargeLevel * 30;
                  if((proj.timeLeft > 15) && (Main.rand.NextBool(Utils.Clamp((int)proj.timeLeft, 0, 2500), 2500))){
                        proj.hostile = true;
                        proj.Kill();
                  }
            }


		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
		}
	}
}