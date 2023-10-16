using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads
{
	public class ExplosiveCannister : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 5;
            Item.value = Item.sellPrice(0, 0, 0, 12);
            Item.rare = ItemRarityID.Orange;
        }

        public override void OnKill(Projectile projectile, int timeLeft){
            Explosions.ExplodeCircle(projectile.position, 100, 40, ChargerDamageClass.Instance, projectile, knockback: 2f);
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.ExplosivePowder);
            recipe.AddIngredient(ModContent.ItemType<DartCannister>(), 25);
            recipe.Register();
        }
    }
}