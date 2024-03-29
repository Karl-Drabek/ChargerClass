using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ChargerClass.Common.Players;
using ChargerClass.Content.Buffs;
using ChargerClass.Content.Items;
using ChargerClass.Content.Items.Armor.MechArmor;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.Items.Acessories;
using ChargerClass.Content.Items.Weapons.Crossbows;
using ChargerClass.Content.Items.Weapons.Slingshots;

namespace ChargerClass.Common.GlobalProjectiles;

public class ChargerProjectile : GlobalProjectile
{
	public override bool InstancePerEntity => true; //Needed for GlobalProjectile for some reason.

	public int Repository, BeeAttempts, LeatherGloveChargeLevel, ExplosionSize;
	public bool Frostburn, Hellfire, Confused, Electrified, Bleeding, Tetnus, Chilled, PenOnCrit, CatchCritters, Hydrogenized, BossBonus, SpawnRockets, RainSpeed, IceOnDeath;
	public bool _inWater = false;
	public int GoldBonusCount, TinCanChance;
	Player sourcePlayer;
        Item sourceItem;

	public override void OnSpawn (Projectile projectile, IEntitySource source){
		if(source is EntitySource_Parent parentSource){
			if(parentSource.Entity is Projectile spawnerProjectile){//if this was spawned by a projectile like the splitter keep its variable values
				ChargerProjectile modProj  = spawnerProjectile.GetGlobalProjectile<ChargerProjectile>(); 
				this.Repository                = modProj.Repository;
				this.BeeAttempts               = modProj.BeeAttempts;
				this.LeatherGloveChargeLevel   = modProj.LeatherGloveChargeLevel;
				this.Frostburn                 = modProj.Frostburn;
				this.Hellfire                  = modProj.Hellfire;
				this.Confused                  = modProj.Confused;
				this.Electrified               = modProj.Electrified;
				this.Bleeding                  = modProj.Bleeding;
				this.ExplosionSize             = modProj.ExplosionSize;
				this.Tetnus                    = modProj.Tetnus;
				this.RainSpeed                 = modProj.RainSpeed;
				this.GoldBonusCount            = modProj.GoldBonusCount;
				this.TinCanChance              = modProj.TinCanChance;
				this.Chilled                   = modProj.Chilled;
				this.PenOnCrit                 = modProj.PenOnCrit;
				this.CatchCritters             = modProj.CatchCritters;
				this.Hydrogenized              = modProj.Hydrogenized;
				this.BossBonus                 = modProj.BossBonus;
				this.SpawnRockets              = modProj.SpawnRockets;
				this.IceOnDeath                = modProj.IceOnDeath;
			}else if(parentSource is EntitySource_ItemUse_WithAmmo ammoSource){
				sourcePlayer = ammoSource.Player;
                	sourceItem = ammoSource.Item;
			}
		}else{
			TinCanChance = GoldBonusCount = ExplosionSize = Repository = BeeAttempts = LeatherGloveChargeLevel = 0;
			IceOnDeath = RainSpeed = SpawnRockets = BossBonus = Hydrogenized = CatchCritters = PenOnCrit = Bleeding = Chilled = Tetnus = Bleeding = Frostburn = Hellfire = Confused = Electrified = false;
		}
	}

	public override void AI(Projectile projectile){
		if(RainSpeed){
			if((Main.raining || projectile.wet) && !_inWater){
				_inWater = true;
				projectile.velocity *= CopperCrossbow.VelocityChangeRain / 100f;
			}else if(_inWater && !(Main.raining || projectile.wet)){
				_inWater = false;
				projectile.velocity /= CopperCrossbow.VelocityChangeRain / 100f;
			}
		}
		if(Hydrogenized)projectile.velocity.Y -= (projectile.velocity.Y - projectile.oldVelocity.Y) / 2;
	}

	public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hitInfo, int damage){
		if(PenOnCrit && hitInfo.Crit) projectile.penetrate++;
		if(Electrified && hitInfo.Crit){
			target.AddBuff(BuffID.Electrified, 60);
			target.AddBuff(ModContent.BuffType<Stunned>(), 20);
		}
		if(Tetnus) target.AddBuff(ModContent.BuffType<Tetnus>(), 120);
		if(Bleeding)target.AddBuff(BuffID.Bleeding, 180);
		if(Frostburn) target.AddBuff(BuffID.Frostburn, 90);
		if(Hellfire) target.AddBuff(BuffID.OnFire, 180);
		if(Confused) target.AddBuff(BuffID.Confused, 240);

		if(target.value > 0){
			while(GoldBonusCount-- > 0 ){
				int coin = Main.rand.NextDouble() switch{
					< 0.5 => ItemID.CopperCoin,
					< 0.8 => ItemID.SilverCoin,
					< 0.995 => ItemID.GoldCoin,
					_ => ItemID.PlatinumCoin,
				};
				Item.NewItem(new EntitySource_OnHit(projectile, target), target.position, target.width, target.height, coin, GoldBonusCount);
			}
		}

		for(int i = 0; i < BeeAttempts; i++){
			if(Main.rand.NextBool(RichMahoganySlingshot.BeeChance, 100)){
				Projectile.NewProjectile(new EntitySource_OnHit(Main.player[projectile.owner], target),
					projectile.position, 
					projectile.velocity, 
					Main.player[projectile.owner].beeType(), //I think these three attributes change based on some in game items.
					Main.player[projectile.owner].beeDamage(projectile.damage), 
					Main.player[projectile.owner].beeKB(0f), Main.myPlayer);
			}
		}

		if((Repository != 0) && hitInfo.Crit) Main.player[projectile.owner].GetModPlayer<ChargeModPlayer>().RepositorySuccess(Repository);

		if(!target.active){
			if(Main.rand.NextBool(TinCanChance, 100)){
				Item.NewItem(new EntitySource_OnHit(projectile, target), target.position, target.width, target.height, ModContent.ItemType<SealedTinCan>(), 1);
			}
			if(IceOnDeath){
				int iceCount = Main.rand.Next(1, 3);
				for(int i = 0; i < iceCount; i++){
					Projectile proj = Projectile.NewProjectileDirect(new EntitySource_Parent(target), target.position,
                            new Vector2(0, -1).RotatedByRandom(MathHelper.ToRadians(45)) * Main.rand.NextFloat(3,4), ProjectileID.IceSpike, 10, 1f);
				}
			}
		}
	}

	public override void OnKill(Projectile projectile, int timeLeft) {
		if(projectile.type == ProjectileID.MiniNukeRocketI || projectile.type == ProjectileID.MiniNukeRocketII)
			Item.NewItem(new EntitySource_Parent(projectile), projectile.position, projectile.width, projectile.height, ModContent.ItemType<RadioactiveDebris>());
		if(ExplosionSize > 0) Explosions.ExplodeCircle(projectile.position, ExplosionSize, 18, ChargerDamageClass.Instance, projectile, knockback: 1f);
		if(Hydrogenized) Explosions.ExplodeCircle(projectile.position, 30, projectile.damage / 10, ChargerDamageClass.Instance, projectile);
		if(SpawnRockets && projectile.aiStyle != ProjAIStyleID.FireWork){
			int rocketCount = Main.rand.Next(1, 3);
			for(int i = 0; i < rocketCount; i++){
				Projectile firework = Projectile.NewProjectileDirect(new EntitySource_Parent(projectile),
				projectile.Center, (Vector2.UnitX * 5).RotatedByRandom(MathHelper.ToRadians(360)), RandomRocket(), projectile.damage / 3, 1f);
			}
		}
		static int RandomRocket() => Main.rand.Next(0, 7) switch{
			0 => ProjectileID.RocketFireworkRed,
			1 => ProjectileID.RocketFireworkBlue,
			2 => ProjectileID.RocketFireworkGreen,
			3 => ProjectileID.RocketFireworkYellow,
			4 => ProjectileID.RocketFireworksBoxRed,
			5 => ProjectileID.RocketFireworksBoxBlue,
			6 => ProjectileID.RocketFireworksBoxGreen,
			_ => ProjectileID.RocketFireworksBoxYellow
		};
        }

	public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers hitModifiers){
		if((target.catchItem > 0) && CatchCritters){//cancatch holds item id if it has a critter drop. ai0 holds if the airgun is meant to capture critters for the shot
                bool? canCatch = CombinedHooks.CanCatchNPC(sourcePlayer, target, sourceItem);
                bool willCatch = true;
                if(canCatch.HasValue){
                    willCatch = canCatch.Value;
                }else if (target.type == NPCID.FairyCritterBlue || target.type == NPCID.FairyCritterPink || target.type == NPCID.FairyCritterGreen){
                    willCatch = target.ai[2] <= 1f; //condition for catching fairy
                }
                CombinedHooks.OnCatchNPC(sourcePlayer, target, sourceItem, !willCatch);
                if(willCatch){ //if fairy or canCatchNPC failed then just deal 0 damage.
                    if (target.type == 687){ //mystic frog
                        if (Main.netMode == NetmodeID.MultiplayerClient) return;
                        Vector2 chosenTile = Vector2.Zero;
                        Point point = target.Center.ToTileCoordinates();
                        if (target.AI_AttemptToFindTeleportSpot(ref chosenTile, point.X, point.Y, 15, 8))
                        {
                            Vector2 newPos = new Vector2(chosenTile.X * 16f - (float)(target.width / 2), chosenTile.Y * 16f - (float)target.height);
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, target.whoAmI);
                            target.Teleport(newPos, 13);
                        }
                        Vector2 vector = projectile.Center - new Vector2(20f);
                        Utils.PoofOfSmoke(vector);
                        projectile.active = false;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, target.whoAmI);
                        NetMessage.SendData(MessageID.PoofOfSmoke, -1, -1, null, (int)vector.X, vector.Y);
                        //hitModifiers.FinalDamage.Base = 0f; //do no damage whether teleporting or not
                    }
                    else if(target.SpawnedFromStatue){ //if from statue dont spawn item
                        Vector2 vector = target.Center - new Vector2(20f);
                        Utils.PoofOfSmoke(vector);
                        target.active = false;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, target.whoAmI);
                        NetMessage.SendData(MessageID.PoofOfSmoke, -1, -1, null, (int)vector.X, vector.Y);
                    }else{//otherwise drop item
                        Item.NewItem(new EntitySource_Parent(target), target.getRect(), target.catchItem);
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, sourceItem.whoAmI, 1f);
                        target.active = false;
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, target.whoAmI);
                    }
                }
            }
		if(LeatherGloveChargeLevel > 0) hitModifiers.CritDamage += LeatherGlove.BonusCritDamage / 100f * LeatherGloveChargeLevel;
		if(BossBonus && target.boss) hitModifiers.FinalDamage += MAD.ChargeBossDamageIncrease / 100f;
	}
}