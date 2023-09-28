using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class FeatheredTail : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;

            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.White;
            
            Item.shootSpeed = 1f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.Feather);
            recipe.Register();
        }
    }
}