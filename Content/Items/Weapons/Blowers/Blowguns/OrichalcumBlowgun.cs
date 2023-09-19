using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns
{
	public class OrichalcumBlowgun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
                  Item.width = 84;
                  Item.height = 20;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.LightRed;

                  chargeAmount = 400;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 2, 20, 0);
                  Item.useTime = 28;

                  Item.damage = 362;
                  Item.crit = 0;
                  Item.knockBack = 2f;

                  blowWeapon = true;
                  Item.shoot = ProjectileID.PurificationPowder;
                  Item.shootSpeed = 14f;
                  Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.OrichalcumBar, 12);
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
		}
	}
}