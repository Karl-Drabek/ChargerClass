using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo;

public class BloontoniumDart : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            Item.width = 19;
            Item.height = 7;

            Item.damage = 32;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 0, 4, 0);
            Item.rare = ItemRarityID.Pink;
            Item.shoot = ModContent.ProjectileType<BloontoniumDartProjectile>();

            Item.ammo = Item.type;
        }

        public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ModContent.ItemType<MonkeyDart>(), 4);
            recipe.AddIngredient(ModContent.ItemType<DepleatedBloontonium>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
    }