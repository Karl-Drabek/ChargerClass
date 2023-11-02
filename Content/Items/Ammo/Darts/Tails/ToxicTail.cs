using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class ToxicTail : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 2;
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.White;
            
            Item.shootSpeed = 2f;
        }
        public override void AI(Projectile projectile, int payloadType){
            Projectile dust = Projectile.NewProjectileDirect(new EntitySource_Misc("No Desired Inheritance"), projectile.position, Vector2.UnitY.RotatedByRandom(MathHelper.ToRadians(30)) * 10, Main.rand.Next(569, 572), 10, 0);
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.JungleSpores);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
    }