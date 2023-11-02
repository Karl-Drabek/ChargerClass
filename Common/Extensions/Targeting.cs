using Terraria;
using Microsoft.Xna.Framework;

namespace ChargerClass.Common.Extensions;

public static class Targeting{
        public static NPC FindClosestNPC(Vector2 position, float maxDetectDistance) {
		NPC closestNPC = null;
		float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
		for (int k = 0; k < Main.maxNPCs; k++) {
			NPC target = Main.npc[k];
			if (target.CanBeChasedBy()) {
                    float squareDistanceToNPC = Vector2.DistanceSquared(target.Center, position);
				if (squareDistanceToNPC < sqrMaxDetectDistance){
                        sqrMaxDetectDistance = squareDistanceToNPC;
                        closestNPC = target;
				}
			}
		}
		return closestNPC;
	}

        public static NPC FindClosestLineOfSightNPC(Vector2 position, float maxDetectDistance, int width1 = 1, int height1 = 1, int wieght2 = 1, int height = 1) {
		NPC closestNPC = null;
		float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
		for (int k = 0; k < Main.maxNPCs; k++) {
			NPC target = Main.npc[k];
                if(!Collision.CanHit(position, width1, height1, target.position, wieght2, height)) continue;
			if (target.CanBeChasedBy()) {
                    float squareDistanceToNPC = Vector2.DistanceSquared(target.Center, position);
				if (squareDistanceToNPC < sqrMaxDetectDistance){
                        sqrMaxDetectDistance = squareDistanceToNPC;
                        closestNPC = target;
				}
			}
		}
		return closestNPC;
	}
        public static NPC FindClosestNPCBiasBoss(Vector2 position, float maxDetectDistance) {
		NPC closestNPC = null;
		float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;
            float currentDistance = sqrMaxDetectDistance;

		for (int k = 0; k < Main.maxNPCs; k++) {
			NPC target = Main.npc[k];
			if (target.CanBeChasedBy()) {
                    if(closestNPC is not null && closestNPC.boss) { //tracking boss and target is not boss
                        if(!target.boss)continue;
                    }else{ //not tracking boss and new target is boss
                        if(target.boss) newBoss(Vector2.DistanceSquared(target.Center, position));
                    }
				float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, position);
				if (sqrDistanceToTarget < sqrMaxDetectDistance){
					if(closestNPC is not null && closestNPC.boss){//tracking boss and target is assumed boss
                            newBoss(sqrDistanceToTarget);
                        }else{ //must be tracking not boss and target is also not boss
                            if(sqrDistanceToTarget < currentDistance){
                                currentDistance = sqrDistanceToTarget;
                                closestNPC = target;
                            }
                        }
				}
                    void newBoss(float targetDistance){
                        sqrMaxDetectDistance = targetDistance;
                        closestNPC = target;
                    }
			}
		}
		return closestNPC;
	}
    }