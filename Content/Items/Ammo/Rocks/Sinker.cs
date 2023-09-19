using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Rocks
{
	public class Sinker : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
        }
            
        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 18;

            Item.damage = 11;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(0, 0, 0, 12);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.SinkerProjectile>();
            Item.shootSpeed = 2f;

            Item.ammo = ModContent.ItemType<Rock>();
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.LeadBar, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}