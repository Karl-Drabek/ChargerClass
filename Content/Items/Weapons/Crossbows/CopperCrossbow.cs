using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class CopperCrossbow : ChargeWeapon
{
            public static readonly int VelocityChangeEffect = 10;
            public static readonly int VelocityChangeRain = 25;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(VelocityChangeRain, VelocityChangeEffect);
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
            Item.width = 37;
            Item.height = 13;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 70);

            Item.damage = 22;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.useTime = 28;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
	}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  proj.ignoreWater = true;
                  chargerProj.RainSpeed = true;
            }
	public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  velocity *= VelocityChangeEffect / 100f * chargeLevel;
            }

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CopperBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}