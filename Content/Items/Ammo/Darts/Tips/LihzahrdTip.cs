using Terraria;
using Terraria.ID;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips;

public class LihzahrdTip : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 1);
            Item.rare = ItemRarityID.White;
            DartSheetPlacement = 11;
            Pen = 3;
            Item.damage = 20;
            Item.knockBack = 4f;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(BuffID.Poisoned, 600);
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ItemID.WoodenSpike);
            recipe.Register();
        }
    }