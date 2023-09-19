using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns
{
	public class ChlorophyteBlowgun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 86;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Lime;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 4, 80, 0);
            Item.useTime = 30;

            Item.damage = 494;
            Item.crit = 2;
            Item.knockBack = 4f;

            blowWeapon = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 14f;
            Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
		}
	}
}