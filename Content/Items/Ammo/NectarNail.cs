using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo;

public class NectarNail : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            Item.width = 10;
            Item.height = 9;

            Item.damage = 5;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 99);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.NectarNailProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.Stinger, 1);
            recipe.AddIngredient(ItemID.BottledHoney, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }