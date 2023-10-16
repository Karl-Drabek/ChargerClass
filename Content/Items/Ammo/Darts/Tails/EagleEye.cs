using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;
using Microsoft.Xna.Framework;
using System;
using ChargerClass.Common.Extensions;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class EagleEye : DartComponent
	{
        const float detectRaidus = 350;
        const float rotationSpeed = 0.3f;
        const float speed = 15;

        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 6;
            AIStyle = 0;
            Item.value = Item.sellPrice(0, 0, 0, 9);
            Item.rare = ItemRarityID.Orange;
            
            Item.shootSpeed = 12;
        }

        public override void OnSpawn(Projectile projectile, IEntitySource source){
            projectile.velocity.Normalize();
            projectile.velocity *= speed;
        }

        public override void AI(Projectile projectile, int payloadType){

			NPC closestNPC = Targeting.FindClosestNPC(projectile.position, detectRaidus);
			if (closestNPC != null) {
                float directionToNPC = (closestNPC.Center - projectile.Center).ToRotation();
                float difference = directionToNPC - projectile.velocity.ToRotation();
                if(difference > Math.PI) difference = -(float)Math.PI * 2 + difference;
                if(difference < -Math.PI) difference = (float)Math.PI * 2 - difference;
                float rotation = difference switch{
                    > rotationSpeed => rotationSpeed,
                    < -rotationSpeed => -rotationSpeed,
                    _ => difference
                };
                projectile.velocity = projectile.velocity.RotatedBy(rotation);
                Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.TintableDustLighted, default, default, default, Color.Red);
            }
			projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 2;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(25);
            recipe.AddIngredient(ItemID.SoulofFlight);
            recipe.AddIngredient(ItemID.SoulofSight);
            recipe.AddIngredient(ModContent.ItemType<FeatheredTail>(), 25);
            recipe.Register();
        }
    }
}