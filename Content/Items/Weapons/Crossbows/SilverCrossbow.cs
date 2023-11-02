using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class SilverCrossbow : ChargeWeapon
{
        public static readonly int StatIncrease = 7;
    public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(StatIncrease);
        public override void SetStaticDefaults() {
                Item.ResearchUnlockCount = 1;
        }
	public override void SafeSetDefaults()
	{
            Item.width = 37;
            Item.height = 15;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 18;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 7, 0);

            Item.damage = 30;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
	}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            velocity *= 1 + chargeLevel * StatIncrease / 100f;
        }

	public override void SafeModifyWeaponCrit(Player player, ref float crit){
            crit += chargeLevel * StatIncrease;
        }

	public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);
        
	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}