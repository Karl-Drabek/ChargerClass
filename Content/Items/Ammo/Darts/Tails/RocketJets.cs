using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.ModSystems;
using System;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class RocketJets : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 4;
            AIStyle = -1;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.Blue;
            
            Item.shootSpeed = 0f;
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers){
            float modifier = 1 + projectile.ai[2] / 10;
            modifiers.FinalDamage *= modifier;
            modifiers.Knockback *= modifier;
            projectile.CritChance += (int)projectile.ai[2] / 300;
        }

        public override void AI(Projectile projectile, int payloadType){
            projectile.rotation = projectile.velocity.RotatedBy((float)Math.PI /2).ToRotation();
            Vector2 particleVect = projectile.velocity / -4;
            Dust.NewDustPerfect(projectile.Center, DustID.Torch, particleVect.RotatedByRandom(MathHelper.ToRadians(10)) * Main.rand.NextFloat(1f, 1.1f), 100, default, 1f);
            for(int i = 0; i < 4; i++){
                Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Smoke, particleVect.X, particleVect.Y, 100, default, Main.rand.NextFloat(1f, 2f));
		    dust.fadeIn = 1.5f;
		    dust.noGravity = true;
            }
            if(projectile.velocity.Length() < 25){
                projectile.velocity *= 1.02f;
                if(++projectile.ai[2] % 20 == 0) projectile.penetrate++;
            }
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.Rockets, 25);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
    }