using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons
{
	public class Bola : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 99;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 300;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 2);

            Item.damage = 10;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.maxStack = 999;
            Item.consumable = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.BolaProjectile>();
            Item.shootSpeed = 10f;
            Item.ammo = Item.type;
		}
            
            public override void SafePostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  var bolaProj = proj.ModProjectile as Projectiles.BolaProjectile;
                  bolaProj.SlowTime = 30 * chargeLevel;
            }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.StoneBlock, 2);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}