using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class CrimtaneCrossbow : ChargeWeapon
{
        public static readonly int DamageIncrease = 7;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(DamageIncrease);
        public override void SetStaticDefaults() {
                Item.ResearchUnlockCount = 1;
        }
	public override void SafeSetDefaults()
	{
            Item.width = 37;
            Item.height = 17;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 450;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 25;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 36, 0);

            Item.damage = 43;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 11f;
            Item.useAmmo = AmmoID.Arrow;
	}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            damage += chargeLevel * DamageIncrease;
        }

        public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
            chargerProj.Bleeding = true;
        }

        public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}