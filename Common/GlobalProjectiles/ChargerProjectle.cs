using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ChargerClass.Common.Players;
using ChargerClass.Content.Buffs;
using ChargerClass.Content.Items;

namespace ChargerClass.Common.GlobalProjectiles
{
	public class ChargerProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity => true; //Needed for GlobalProjectile for some reason.

		public int Repository, BeeAttempts, LightningPole, LeatherGloveChargeLevel, ExplosionSize;
		public bool LeatherGlove, Frostburn, Hellfire, Confused, Electrified, Bleeding, Tetnus, Chilled;
		public bool _inWater = false;
		public float RainSpeed;
		public int GoldBonusCount, TinCanChance;

		public override void OnSpawn (Projectile projectile, IEntitySource source){
			if(source is EntitySource_Parent parentSource && parentSource.Entity is Projectile spawnerProjectile){ //if this was spawned by a projectile like the splitter keep its variable values
				ChargerProjectile modProj  = spawnerProjectile.GetGlobalProjectile<ChargerProjectile>(); 
				this.Repository                = modProj.Repository;
				this.BeeAttempts               = modProj.BeeAttempts;
				this.LightningPole             = modProj.LightningPole;
				this.LeatherGloveChargeLevel   = modProj.LeatherGloveChargeLevel;
				this.LeatherGlove              = modProj.LeatherGlove;
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
			}else{
				RainSpeed = TinCanChance = GoldBonusCount = ExplosionSize = Repository = BeeAttempts = LightningPole = LeatherGloveChargeLevel = 0;
				Bleeding = Chilled = Tetnus = Bleeding = LeatherGlove = Frostburn = Hellfire = Confused = Electrified = false;
			}
		}

		public override void AI(Projectile projectile){
			if(RainSpeed > 1){
				if((Main.raining || projectile.wet) && !_inWater){
					_inWater = true;
					projectile.velocity *= RainSpeed;
				}else if(_inWater && !(Main.raining || projectile.wet)){
					_inWater = false;
					projectile.velocity /= RainSpeed;
				}
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hitInfo, int damage){
			if(Electrified && hitInfo.Crit) target.AddBuff(BuffID.Electrified, 300);
			if(Tetnus) target.AddBuff(ModContent.BuffType<Tetnus>(), 120);
			if(Bleeding)target.AddBuff(BuffID.Bleeding, 180);
			if(Frostburn) target.AddBuff(BuffID.Frostburn, 90);
			if(Hellfire) target.AddBuff(BuffID.OnFire, 180);
			if(Confused) target.AddBuff(BuffID.Confused, 240);

			if(GoldBonusCount > 0 && hitInfo.Crit && target.value > 0){
				int coin = Main.rand.NextDouble() switch{
					< 0.5 => ItemID.CopperCoin,
					< 0.8 => ItemID.SilverCoin,
					< 0.995 => ItemID.GoldCoin,
					_ => ItemID.PlatinumCoin,
				};
				Item.NewItem(new EntitySource_OnHit(projectile, target), target.position, target.width, target.height, coin, GoldBonusCount);
			}

			for(int i = 0; i < BeeAttempts; i++){
				if(Main.rand.NextBool(5, 100)){
					Projectile.NewProjectile(new EntitySource_OnHit(Main.player[projectile.owner], target),
						projectile.position, 
						projectile.velocity, 
						Main.player[projectile.owner].beeType(), //I think these three attributes change based on some in game items.
						Main.player[projectile.owner].beeDamage(projectile.damage), 
						Main.player[projectile.owner].beeKB(0f), Main.myPlayer);
				}
			}

			if((Repository != 0) && hitInfo.Crit) Main.player[projectile.owner].GetModPlayer<ChargeModPlayer>().RepositorySuccess(Repository);

			if(!target.active && Main.rand.NextBool(TinCanChance, 100)){
				Item.NewItem(new EntitySource_OnHit(projectile, target), target.position, target.width, target.height, ModContent.ItemType<SealedTinCan>(), 1);
			}
		}

		public override void Kill(Projectile projectile, int timeLeft) {
			if(ExplosionSize > 0){
				//I think by setting these to less than 0 it will have no problem hitting as many entities as it would like when it is resized
				projectile.maxPenetrate = -1;
				projectile.penetrate = -1;
				Vector2 oldSize = projectile.Size;

				//I'm not totally sure why this is necessary but it was in the example mod and I think makes the damage more centered
				projectile.position = projectile.Center; //Center the projectile's hitbox
				projectile.Size += new Vector2(ExplosionSize); //resize the projectile
				projectile.Center = projectile.position; //offset the projectile again

            
				projectile.tileCollide = false;
				projectile.velocity *= 0.01f;//seems like velocity should just be 0 but this was also in the example mod so I will trust it

				projectile.Damage(); //damage the entities
				projectile.scale = 0.01f; //Once again I don't know why this is here but it was in example mod

				projectile.position = projectile.Center; //same as before but returns the projectile to its old size.
				projectile.Size = oldSize;
				projectile.Center = projectile.position;
				//It dies shortly after so I don't know why this is neccessary except that maybe it shows for one more frame.
				for (int i = 0; i < 350; i++) {
					Dust dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 130, 0, 0, 100, Color.Red, 0.8f);
					dust.noGravity = true;
					dust.velocity *= 2f;
					dust = Dust.NewDustDirect(projectile.position - projectile.velocity, projectile.width, projectile.height, 130, 0f, 0f, 100, Color.Red, 0.5f);
				}
			}
        }

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers hitModifiers){
			if(LeatherGlove) hitModifiers.CritDamage += 0.02f * LeatherGloveChargeLevel;
		}
	}
}