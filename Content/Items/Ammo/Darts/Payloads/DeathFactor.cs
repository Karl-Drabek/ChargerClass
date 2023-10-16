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
	public class DeathFactor : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 8;
            Item.value = Item.sellPrice(0, 0, 0, 40);
            Item.rare = ItemRarityID.White;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(ModContent.BuffType<Plague>(), (int)(600 * buffTimeMultiplier));
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.AddIngredient(ItemID.Deathweed, 25);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}