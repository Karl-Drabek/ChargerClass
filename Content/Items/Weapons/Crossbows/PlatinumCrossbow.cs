using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Crossbows;

public class PlatinumCrossbow : ChargeWeapon
{
            public static readonly int AmmoChance = 15;
      public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(AmmoChance);
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
            Item.useTime = 22;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 21, 0);

            Item.damage = 36;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Arrow;
	}

            public override bool CanConsumeAmmo(Item item, Player player) => !Main.rand.NextBool(Utils.Clamp(AmmoChance * chargeLevel, 0, 100), 100);

            public override Vector2? HoldoutOffset() => new Vector2(-2f, 0f);

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PlatinumBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}