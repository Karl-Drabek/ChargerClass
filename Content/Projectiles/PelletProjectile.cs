using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace ChargerClass.Content.Projectiles
{
	public class PelletProjectile : ModProjectile
	{   
        Player sourcePlayer;
        Item sourceItem;

		public override void SetDefaults()
		{
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void OnSpawn(IEntitySource spawnSource){
            if(spawnSource is EntitySource_ItemUse_WithAmmo source){
                sourcePlayer = source.Player;
                sourceItem = source.Item;
            }
        }

        public override void ModifyHitNPC (NPC target, ref NPC.HitModifiers modifiers){ //idk what senddata does but it was in vanilla
            if((target.catchItem > 0) && (Projectile.ai[0] == 1f)){//cancatch holds item id if it has a critter drop. ai0 holds if the airgun is meant to capture critters for the shot
                bool? canCatch = CombinedHooks.CanCatchNPC(sourcePlayer, target, sourceItem);
                bool willCatch = true;
                if(canCatch.HasValue){
                    willCatch = canCatch.Value;
                }else if (target.type == 585 || target.type == 583 || target.type == 584){
                    willCatch = target.ai[2] <= 1f; //condition for catching fairy
                }
                CombinedHooks.OnCatchNPC(sourcePlayer, target, sourceItem, !willCatch);
                if(willCatch){ //if fairy or canCatchNPC failed then just deal 0 damage.
                    if (target.type == 687){ //mystic frog
                        if (Main.netMode == 1) return;
                        Vector2 chosenTile = Vector2.Zero;
                        Point point = target.Center.ToTileCoordinates();
                        if (target.AI_AttemptToFindTeleportSpot(ref chosenTile, point.X, point.Y, 15, 8))
                        {
                            Vector2 newPos = new Vector2(chosenTile.X * 16f - (float)(target.width / 2), chosenTile.Y * 16f - (float)target.height);
                            NetMessage.SendData(23, -1, -1, null, target.whoAmI);
                            target.Teleport(newPos, 13);
                        }
                        Vector2 vector = Projectile.Center - new Vector2(20f);
                        Utils.PoofOfSmoke(vector);
                        Projectile.active = false;
                        NetMessage.SendData(23, -1, -1, null, target.whoAmI);
                        NetMessage.SendData(106, -1, -1, null, (int)vector.X, vector.Y);
                        modifiers.FinalDamage.Base = 0f; //do no damage whether teleporting or not
                    }
                    else if(target.SpawnedFromStatue){ //if from statue dont spawn item
                        Vector2 vector = target.Center - new Vector2(20f);
                        Utils.PoofOfSmoke(vector);
                        target.active = false;
                        NetMessage.SendData(23, -1, -1, null, target.whoAmI);
                        NetMessage.SendData(106, -1, -1, null, (int)vector.X, vector.Y);
                    }else{//otherwise drop item
                        Item.NewItem(new EntitySource_Parent(target), target.getRect(), target.catchItem);
                        NetMessage.SendData(21, -1, -1, null, sourceItem.whoAmI, 1f);
                        target.active = false;
                        NetMessage.SendData(23, -1, -1, null, target.whoAmI);
                    }
                }
            }
        }

        public override void Kill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
	}
}