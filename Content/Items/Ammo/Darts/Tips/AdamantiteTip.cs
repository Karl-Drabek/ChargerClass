    using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips
{
	public class AdamantiteTip : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.Orange;

            Pen = 2;
            Item.damage = 12;
            Item.knockBack = 2f;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.AdamantiteBar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}