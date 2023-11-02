using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SupremeCalamari : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
            Item.width = 26;
            Item.height = 82;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Red;

            chargeAmount = 500;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 22, 0, 0);
            Item.useTime = 54;

            Item.damage = 1470;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<Projectiles.SupremeCalamariProjectile>();
            Item.shootSpeed = 20f;

            Item.noUseGraphic = true;
	}

            public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ModContent.ItemType<PremeCalamari>());
                  recipe.AddIngredient(ItemID.LunarBar, 16);
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}