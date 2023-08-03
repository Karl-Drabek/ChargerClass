using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using ChargerClass.Common.Players;

namespace ChargerClass.Common.GlobalProjectiles
{
	public class ChargerProjectile : GlobalProjectile
	{
		public override bool InstancePerEntity => true; //Needed for GlobalProjectile for some reason.

		public int Repository, BeeAttempts, LightningPole, LeatherGloveChargeLevel, ExplosionSize;
		public bool LeatherGlove, Frostburn, Hellfire, Confused, Electrifieda, Bleeding, Tetnus;

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
			}else{
				ExplosionSize = Repository = BeeAttempts = LightningPole = LeatherGloveChargeLevel = 0;
				Tetnus = Bleeding = LeatherGlove = Frostburn = Hellfire = Confused = Electrified = false;
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit){
			if(Electrified && crit) target.AddBuff(BuffID.Electrified, 300);
			if(Tetnus) Target.AddBuff( , 120)
			if(Bleeding) target.AddBuff(BuffID.Bleeding, 180);
			if(Frostburn) target.AddBuff(BuffID.Frostburn, 90);
			if(Hellfire) target.AddBuff(BuffID.OnFire, 180);
			if(Confused) target.AddBuff(BuffID.Confused, 240);
			for(int i = 0; i < BeeAttempts; i++){
				if(ChargerClassModSystem.Random.NextDouble() <= 0.05f){
					Projectile.NewProjectile(new EntitySource_OnHit(Main.player[projectile.owner], target),
						projectile.position, 
						projectile.velocity, 
						Main.player[projectile.owner].beeType(), //I think these three attributes change based on some in game items.
						Main.player[projectile.owner].beeDamage(projectile.damage), 
						Main.player[projectile.owner].beeKB(0f), Main.myPlayer);
				}
			}

			if((Repository != 0) && crit) Main.player[projectile.owner].GetModPlayer<ChargeModPlayer>().RepositorySuccess(Repository);
		}

		public override void Kill(int timeLeft) {
			if(ExplosionSize > 0){
				//I think by setting these to less than 0 it will have no problem hitting as many entities as it would like when it is resized
				Projectile.maxPenetrate = -1;
				Projectile.penetrate = -1;
				Vector2 oldSize = Projectile.Size;

				//I'm not totally sure why this is necessary but it was in the example mod and I think makes the damage more centered
				Projectile.position = Projectile.Center; //Center the projectile's hitbox
				Projectile.Size += new Vector2(ExplosionSize); //resize the projectile
				Projectile.Center = Projectile.position; //offset the projectile again

            
				Projectile.tileCollide = false;
				Projectile.velocity *= 0.01f;//seems like velocity should just be 0 but this was also in the example mod so I will trust it

				Projectile.Damage(); //damage the entities
				Projectile.scale = 0.01f; //Once again I don't know why this is here but it was in example mod

				Projectile.position = Projectile.Center; //same as before but returns the projectile to its old size.
				Projectile.Size = oldSize;
				Projectile.Center = Projectile.position;
				//It dies shortly after so I don't know why this is neccessary except that maybe it shows for one more frame.
			}
        }

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection){
			if(crit && LeatherGlove) damage += (int)(damage * 0.02f * LeatherGloveChargeLevel);
		}
	}
}