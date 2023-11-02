using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Rocks;

public class Rock : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 18;

            Item.damage = 5;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.RockProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ItemID.StoneBlock, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }