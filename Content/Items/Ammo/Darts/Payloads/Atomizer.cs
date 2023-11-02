using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Payloads;

public class Atomizer : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 14;
            Item.height = 6;
            DartSheetPlacement = 11;
            Item.value = Item.sellPrice(0, 0, 0, 18);
            Item.rare = ItemRarityID.LightPurple;
        }

        public override void OnKill(Projectile projectile, int timeLeft){
            Explosions.ExplodeCircle(projectile.position, 250, 400, ChargerDamageClass.Instance, projectile, knockback: 6f);
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<ExplosiveCannister>(), 25);
            recipe.AddIngredient(ItemID.ShroomiteBar);
            recipe.AddTile(TileID.Autohammer);
            recipe.Register();
        }
    }