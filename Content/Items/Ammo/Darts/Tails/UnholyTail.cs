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
	public class UnholyTail : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;

            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = ItemRarityID.Pink;
            
            Item.shootSpeed = 4f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(250);
            recipe.AddIngredient(ItemID.BlackFairyDust);
            recipe.AddIngredient(ModContent.ItemType<PixieDuster>(), 250);
            recipe.Register();
        }
    }
}