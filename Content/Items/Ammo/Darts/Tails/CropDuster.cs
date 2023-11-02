using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class CropDuster : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 1;
            Item.value = Item.sellPrice(0, 0, 0, 8);
            Item.rare = ItemRarityID.Blue;
            
            Item.shootSpeed = 2f;
        }

        public override void AI(Projectile projectile, int payloadType){
            Projectile dust = Projectile.NewProjectileDirect(new EntitySource_Misc("No Desired Inheritance"), projectile.position, Vector2.UnitY.RotatedByRandom(MathHelper.ToRadians(30)) * 10, ModContent.ProjectileType<CropDusterProjectile>(), 1, 0, -1, payloadType);
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.OutletPump);
            recipe.AddIngredient(ModContent.ItemType<BasicCircuitry>(), 5);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
}