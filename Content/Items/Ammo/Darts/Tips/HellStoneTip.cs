    using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Ammo.Darts.Tips
{
	public class HellstoneTip : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 6;
            
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.Green;
            DartSheetPlacement = 3;
            Pen = 1;
            Item.damage = 10;
            Item.knockBack = 1.5f;
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){
            target.AddBuff(BuffID.OnFire, 300);
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.HellstoneBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}