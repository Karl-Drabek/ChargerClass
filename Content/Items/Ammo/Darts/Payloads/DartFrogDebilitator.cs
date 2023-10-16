using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Buffs;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class DartFrogDebilitator : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 9;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(ModContent.BuffType<Dabilitated>(), (int)(480 * buffTimeMultiplier));
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<DartFrogExtract>());
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.Register();
        }
    }
}