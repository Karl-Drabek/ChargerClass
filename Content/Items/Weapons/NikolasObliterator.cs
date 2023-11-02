using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.Items.Placeable;

namespace ChargerClass.Content.Items.Weapons;

public class NikolasObliterator : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
                  Item.width = 60;
                  Item.height = 30;
                  Item.scale = 1f;
                  Item.rare = ItemRarityID.Red;

                  chargeAmount = 100;
                  Item.useStyle = ItemUseStyleID.Shoot;

                  Item.UseSound = SoundID.Item1;
                  Item.value = Item.sellPrice(0, 48, 0, 0);
                  Item.useTime = 38;

                  Item.damage = 746;
                  Item.crit = 4;
                  Item.knockBack = 1f;

                  Item.shoot = ModContent.ProjectileType<NikolasObliteratorLaser>();
                  Item.shootSpeed = 0f;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.LunarBar, 12);
                  recipe.AddIngredient(ModContent.ItemType<AncientTech>(), 24);
                  recipe.AddIngredient(ModContent.ItemType<TeslaCoil>());
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}