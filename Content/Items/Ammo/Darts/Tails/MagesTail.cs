using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using ChargerClass.Common.Extensions;
using Microsoft.Xna.Framework;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails;

public class MagesTail : DartComponent
{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 9;
            Item.value = Item.sellPrice(0, 0, 0, 8);
            Item.rare = ItemRarityID.Orange;
            
            Item.shootSpeed = 4f;
        }
        public override void AI(Projectile projectile, int payloadType){
            if(Main.rand.NextBool()) projectile.ai[2]++;
            if(projectile.ai[2] < 10) return;
            NPC closestNPC = Targeting.FindClosestNPC(projectile.Center, 1000);
            if(closestNPC is null) return;
            Vector2 distanceToNPC = closestNPC.Center - projectile.Center;
            Projectile bolt = Projectile.NewProjectileDirect(new EntitySource_Parent(projectile), projectile.Center, Vector2.Normalize(distanceToNPC) * 34, ProjectileID.DD2DarkMageBolt, projectile.damage, 1);
            bolt.friendly = true;
            bolt.hostile = false;
            projectile.ai[2] = 0;
        }
    }