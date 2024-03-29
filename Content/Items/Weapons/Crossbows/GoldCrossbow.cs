using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class GoldCrossbow : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
            Item.width = 37;
            Item.height = 15;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 350;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 29;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 14, 0);

            Item.damage = 38;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
	}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer) {
                  chargerProj.GoldBonusCount = chargeLevel * 2;
            }

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);
            
	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}