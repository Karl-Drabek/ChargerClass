using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Buffs;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads;

public class LiquidLeadCannister : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 1;
            Item.value = Item.sellPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.White;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(ModContent.BuffType<LeadPoisoning>(), (int)(240 * buffTimeMultiplier));
            target.AddBuff(BuffID.OnFire, (int)(120 * buffTimeMultiplier));
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }