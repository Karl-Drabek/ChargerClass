using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class BombingBay : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 7;
            Item.value = Item.sellPrice(0, 0, 1, 70);
            Item.rare = ItemRarityID.LightRed;
            
            Item.shootSpeed = 2;
        }

        public override void AI(Projectile projectile, int payloadType){
            if(projectile.ai[2]++ > 5){
                Projectile.NewProjectileDirect(new EntitySource_Misc("No Desired Inheritance"), projectile.position, Vector2.Zero, ModContent.ProjectileType<BombBayProjectile>(), 1, 0, -1, payloadType);
                projectile.ai[2] = 0;
            }
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofLight);
            recipe.AddIngredient(ItemID.HallowedBar);
            recipe.Register();
        }
    }
}