using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class IchorCannister : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 6;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.Orange;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(BuffID.Ichor, (int)(300 * buffTimeMultiplier));
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.Ichor);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.Register();
        }
    }
}