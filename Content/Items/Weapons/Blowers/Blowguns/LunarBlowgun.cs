using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns
{
	public class LunarBlowgun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
                  Item.width = 86;
                  Item.height = 20;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Red;

                  chargeAmount = 400;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 18, 0, 0);
                  Item.useTime = 22;

                  Item.damage = 756;
                  Item.crit = 4;
                  Item.knockBack = 6f;

                  blowWeapon = true;
                  Item.shoot = ProjectileID.PurificationPowder;
                  Item.shootSpeed = 20f;
                  Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.LunarBar, 14);
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
		}
	}
}