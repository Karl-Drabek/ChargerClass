using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns
{
	public class HallowedBlowgun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 82;
            Item.height = 20;
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.useTime = 26;

            Item.damage = 442;
            Item.crit = 4;
            Item.knockBack = 4f;

            blowWeapon = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.HallowedBar, 12);
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
		}
	}
}