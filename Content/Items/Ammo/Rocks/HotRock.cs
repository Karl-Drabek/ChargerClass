using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Rocks
{
	public class HotRock : ModItem
	{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 8)); //(tics, frames)
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
            
        public override void SetDefaults() {
            Item.width = 26;
            Item.height = 36;

            Item.damage = 7;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.HotRockProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = ModContent.ItemType<Rock>();
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ModContent.ItemType<Items.Ammo.Rocks.Rock>(), 4);
            recipe.AddIngredient(ItemID.Torch, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        
    }
}