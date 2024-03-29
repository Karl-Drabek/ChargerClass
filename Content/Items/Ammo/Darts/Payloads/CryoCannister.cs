using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads;

public class CryoCannister : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 3;
            Item.value = Item.sellPrice(0, 0, 0, 3);
            Item.rare = ItemRarityID.White;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(BuffID.Frostburn, (int)(240 * buffTimeMultiplier));
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 5);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            recipe.AddTile(TileID.IceMachine);
            recipe.Register();
        }
    }