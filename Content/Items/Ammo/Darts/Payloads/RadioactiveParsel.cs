using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Buffs;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class RadioactiveParsel : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 10;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.LightPurple;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(ModContent.BuffType<RadiationSickness>(), (int)(480 * buffTimeMultiplier));
        }

        public override void AI(Projectile projectile, int payloadType){
            for (int k = 0; k < Main.maxNPCs; k++) {
                NPC target = Main.npc[k];
                if(target.friendly || !target.active || target.dontTakeDamage) continue;
                float distanceToNPC = Vector2.DistanceSquared(target.Center, projectile.Center);
                if (distanceToNPC < 10_000){
                    target.AddBuff(ModContent.BuffType<RadiationSickness>(), 50 - (int)(distanceToNPC / 200));
                }
            }
            for (int i = 0; i < 5; i++) {
                float posx = Main.rand.NextFloat(-100f, 100f);
                float posy = Main.rand.NextFloat(-100f, 100f);  
                if(posx * posx + posy * posy < 10_000){
                    Dust dust = Dust.NewDustPerfect(new Vector2(projectile.position.X + posx, projectile.position.Y + posy), DustID.CursedTorch);
                    dust.scale = Main.rand.NextFloat(1f, 1.5f);
                    dust.noGravity = true;
                }
            }
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 25);
            recipe.AddIngredient(ModContent.ItemType<RadioactiveDebris>());
            recipe.Register();
        }
    }
}