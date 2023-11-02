using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class AdamantiteBlowgun : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

	public override void SafeSetDefaults()
	{
                  Item.width = 86;
                  Item.height = 20;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.LightRed;

                  chargeAmount = 400;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 2, 40, 0);
                  Item.useTime = 26;

                  Item.damage = 398;
                  Item.crit = 0;
                  Item.knockBack = 3f;

                  blowWeapon = true;
                  Item.shoot = ProjectileID.PurificationPowder;
                  Item.shootSpeed = 16f;
                  Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.AdamantiteBar, 12);
                  recipe.AddTile(TileID.MythrilAnvil);
                  recipe.Register();
	}
}