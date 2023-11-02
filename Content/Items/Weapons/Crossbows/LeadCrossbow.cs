using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Crossbows
{
	public class LeadCrossbow : ChargeWeapon
	{
        public static readonly int KnockbackIncrease = 15;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(KnockbackIncrease);
        public override void SetStaticDefaults() {
                Item.ResearchUnlockCount = 1;
        }
		public override void SafeSetDefaults()
		{
            Item.width = 37;
            Item.height = 13;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 500;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 4, 20);

            Item.damage = 40;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.useTime = 33;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
		}

        public override void SafeModifyWeaponKnockback(Player player, ref StatModifier knockback){
            knockback += chargeLevel * KnockbackIncrease / 100f;
        }

        public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}