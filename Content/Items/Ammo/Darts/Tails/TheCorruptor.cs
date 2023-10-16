using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Common.Extensions;
using System;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class TheCorruptor : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 12;
            AIStyle = 0;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = ItemRarityID.Yellow;
            
            Item.shootSpeed = 6;
        }

        public override void AI(Projectile projectile, int payloadType){
            projectile.rotation = projectile.velocity.RotatedBy((float)Math.PI /2).ToRotation();
            projectile.ai[0] += 5;
            NPC closestNPC = Targeting.FindClosestNPC(projectile.Center, 50 * (float)Math.Sqrt(projectile.ai[0]));
            if(closestNPC is null) return;
            Main.NewText(projectile.ai[0]);
            Projectile.NewProjectileDirect(new EntitySource_Parent(projectile), projectile.position, default, ModContent.ProjectileType<LightningProjectile>(), (int)projectile.ai[0] * 10, 0, -1, closestNPC.whoAmI);
            projectile.ai[0] = 0;
        }
        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ModContent.ItemType<UnholyTail>(), 25);
            recipe.AddIngredient(ItemID.FragmentVortex);
            recipe.AddIngredient(ItemID.FragmentStardust);
            recipe.AddIngredient(ItemID.SoulofMight);
            recipe.AddIngredient(ItemID.SoulofFright);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.Register();
        }
    }
}