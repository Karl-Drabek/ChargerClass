using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class JellyfishCannister : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;

            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<JellyfishTentacle>());
             recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.Register();
        }
    }
}