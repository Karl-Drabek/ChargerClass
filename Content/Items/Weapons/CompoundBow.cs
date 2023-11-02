using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Common.ModSystems;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons
{
	public class CompoundBow : ChargeWeapon
	{
            public static readonly int VelocityIncrease = 10;
            public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(VelocityIncrease);
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
            
		public override void SafeSetDefaults()
		{
            Item.width = 28;
            Item.height = 72;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 450;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 6, 90);

            Item.damage = 16;
            Item.crit = 5;
            Item.knockBack = 0f;
            Item.useTime = 26;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
		}
            
            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  velocity *= 1f + VelocityIncrease / 100f * chargeLevel;
            }

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  proj.penetrate += chargeLevel;
            }

            public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddRecipeGroup(ChargerClassGeneralSystem.CopperBarRecipeGroup, 6);
                  recipe.AddRecipeGroup(ChargerClassGeneralSystem.SilverBarRecipeGroup, 4);
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
		}
	}
}