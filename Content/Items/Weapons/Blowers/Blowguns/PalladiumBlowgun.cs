using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns;

public class PalladiumBlowgun : ChargeWeapon
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
                  Item.value = Item.sellPrice(0, 1, 60, 0);
                  Item.useTime = 26;

                  Item.damage = 334;
                  Item.crit = 0;
                  Item.knockBack = 1f;

                  blowWeapon = true;
                  Item.shoot = ProjectileID.PurificationPowder;
                  Item.shootSpeed = 14f;
                  Item.useAmmo = AmmoID.Dart;
	}

	public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.PalladiumBar, 12);
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}