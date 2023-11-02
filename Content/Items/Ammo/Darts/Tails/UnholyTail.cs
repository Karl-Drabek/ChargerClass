using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using System;
using ChargerClass.Content.Buffs;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class UnholyTail : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 8;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.rare = ItemRarityID.Pink;
            
            Item.shootSpeed = 4f;
        }

        public override void AI(Projectile projectile, int payloadType){
            projectile.light = -1f;
            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Wraith);
            dust.noGravity = true;
			for (int k = 0; k < Main.maxNPCs; k++) {
                NPC target = Main.npc[k];
                if (!target.active || target.dontTakeDamage || target.friendly || target.immortal) continue;
                Vector2 vectorToNPC = projectile.Center - target.Center;
                if (vectorToNPC.X * vectorToNPC.X +  vectorToNPC.Y * vectorToNPC.Y < 90_000){
                    target.velocity = (vectorToNPC + Vector2.Normalize(vectorToNPC) * 450) / 90 * target.knockBackResist;
                    target.AddBuff(ModContent.BuffType<Cursed>(), 300);
                    dust = Dust.NewDustDirect(target.position, target.width, target.height, DustID.Wraith);
                    dust.noGravity = true;
                    dust.scale = Main.rand.Next(1, 2);
                }
			}
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(250);
            recipe.AddIngredient(ItemID.BlackFairyDust);
            recipe.AddIngredient(ModContent.ItemType<PixieDuster>(), 250);
            recipe.Register();
        }
    }
}