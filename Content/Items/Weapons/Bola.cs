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
            Item.width = 32;
            Item.height = 44;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 300;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 16;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 2);

            Item.damage = 17;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.maxStack = 999;
            Item.consumable = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.BolaProjectile>();
            Item.shootSpeed = 10f;
		}
            
            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  proj.ai[2] = 30 * chargeLevel;
            }

		public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.StoneBlock, 2);
                  recipe.AddRecipeGroup(RecipeGroupID.Wood, 4);
                  recipe.AddTile(TileID.WorkBenches);
                  recipe.Register();
		}
	}
}