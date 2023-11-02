using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class IronCrossbow : ChargeWeapon
	{
            public static readonly int InflictChance = 15;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(InflictChance);
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
            Item.value = Item.sellPrice(0, 0, 2, 80);

            Item.damage = 32;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.useTime = 30;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}
            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  chargerProj.Hellfire = Main.rand.NextBool(Utils.Clamp(InflictChance * chargeLevel, 0, 100), 100);
            }

		public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);
		
		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}