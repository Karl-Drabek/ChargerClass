using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SpiderBow : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.LightRed;

                  chargeAmount = 100;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 6, 0, 0);
                  Item.useTime = 29;

                  Item.damage = 900;
                  Item.crit = 8;
                  Item.knockBack = 2f;
                        
                  Item.shoot = ProjectileID.WoodenArrowFriendly;
                  Item.shootSpeed = 16f;
                  Item.useAmmo = AmmoID.Arrow;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.SpiderFang, 28);
                  recipe.AddIngredient(ModContent.ItemType<CompoundBow>());
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}