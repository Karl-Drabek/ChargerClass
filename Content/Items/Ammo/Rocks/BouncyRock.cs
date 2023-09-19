using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Rocks
{
	public class BouncyRock : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 6)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }

        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 42;

            Item.damage = 6;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.BouncyRockProjectile>();
            Item.shootSpeed = 3f;

            Item.ammo = ModContent.ItemType<Rock>();
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ModContent.ItemType<Items.Ammo.Rocks.Rock>(), 4);
            recipe.AddIngredient(ItemID.Gel, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}