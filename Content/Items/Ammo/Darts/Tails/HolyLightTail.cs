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
	public class HolyLightTail : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 11;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = ItemRarityID.Yellow;
            
            Item.shootSpeed = 6;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<PrismaticTail>(), 25);
            recipe.AddIngredient(ItemID.FragmentSolar);
            recipe.AddIngredient(ItemID.FragmentNebula);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.Register();
        }
    }
}