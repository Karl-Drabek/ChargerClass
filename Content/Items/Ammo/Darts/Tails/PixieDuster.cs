using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class PixieDuster : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;

            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.Orange;
            
            Item.shootSpeed = 4;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.PixieDust);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
    }
}