using ChargerClass.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Common.GlobalNPCs
{
	public class ModInstanceNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		private bool plagued = false, oldPlagued = false;

		public bool Tetnus, Sticky, Stunned, LeadPoisoning, Bound, RadiationSickness, Slimed, Dabilitated, GodKiller;

		public bool Plagued{
			get => plagued || oldPlagued;
			set => plagued = oldPlagued = value;
		}

		public override void AI(NPC npc){
			if(Bound) npc.velocity *= 0.98f;
			if(Slimed){
				npc.velocity *= 0.96f;
				if(Main.rand.NextBool(1, 4)) Dust.NewDustPerfect(npc.position + new Vector2(Main.rand.NextFloat(0, npc.width), Main.rand.NextFloat(0, npc.height)), DustID.Wet, Vector2.Zero, 0, Color.LightGreen);
			}if(Dabilitated){
				npc.velocity *= 0.92f;
				Dust.NewDustPerfect(npc.position + new Vector2(Main.rand.NextFloat(0, npc.width), Main.rand.NextFloat(0, npc.height)), DustID.Blood);
				if(Main.rand.NextBool(1, 60)) npc.AddBuff(BuffID.Poisoned, 60);
				if(Main.rand.NextBool(1, 120)) npc.AddBuff(BuffID.Confused, 60);
			}if(Stunned){
				npc.velocity = Vector2.Zero;
				for(int i = 0; i < 5; i++){
					Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Electric);
					dust.noGravity = true;
				}
			}if(Plagued){
				if(Main.rand.NextBool(1,2)) {
					Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Wraith);
					dust.scale = Main.rand.NextFloat(1f, 1.3f);
					dust.noGravity = true;
				}
				if(Main.rand.NextBool(1, 15)) Gore.NewGorePerfect(new EntitySource_Death(npc), npc.position, new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f)), 99, Main.rand.NextFloat(0.5f, 0.75f));	
				for (int k = 0; k < Main.maxNPCs; k++) {
					NPC target = Main.npc[k];
					if(target.friendly || !target.active || target.dontTakeDamage || target.whoAmI == npc.whoAmI) continue;
					float distanceToNPC = Vector2.DistanceSquared(target.Center, npc.Center);
					if (distanceToNPC < 10_000){
						if(Main.rand.NextBool(1, 20 + ((int)distanceToNPC / 100))) target.AddBuff(ModContent.BuffType<Plague>(), 600);
					}
				}
			}if(Tetnus){
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Blood);
			}if(RadiationSickness && Main.rand.NextBool(1, 3)){	
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.CursedTorch);
				dust.scale = Main.rand.NextFloat(1f, 1.5f);
			}if(GodKiller){
				Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.WitherLightning);
			}
		}

		public override void OnKill(NPC npc){
			if(Plagued){
				for (int k = 0; k < Main.maxNPCs; k++) {
					NPC target = Main.npc[k];
					if(target.friendly || !target.active || target.dontTakeDamage) continue;
					if (Vector2.DistanceSquared(target.Center, npc.Center) < 10_000){
						target.AddBuff(ModContent.BuffType<Plague>(), 600);
					}
				}
				for (int i = 0; i < 50; i++) {
					float posx = Main.rand.NextFloat(-50f, 50f);
					float posy = Main.rand.NextFloat(-50f, 50f);
					if(posx * posx + posy * posy < 2500){
						Dust dust = Dust.NewDustPerfect(new Vector2(npc.position.X + posx, npc.position.Y + posy), 54);
						dust.scale = Main.rand.NextFloat(1f, 1.3f);
						dust.noGravity = true;
						if(Main.rand.NextBool(1,3)) Gore.NewGorePerfect(new EntitySource_Death(npc), new Vector2(npc.position.X + posx, npc.position.Y + posy), new Vector2(Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-1f, 1f)), 99, Main.rand.NextFloat(0.5f, 0.75f));				
					}
				}
			}
		}

		public override void ResetEffects(NPC npc){
			//if(oldPlagued == true && plagued == false) npc.BecomeImmuneTo(ModContent.BuffType<Plague>());
			oldPlagued = plagued;
			plagued = Tetnus = Slimed = Stunned = LeadPoisoning = Bound = RadiationSickness = Dabilitated = GodKiller = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage){
			if(Plagued){
				npc.lifeRegen -= 120;
				damage += 10;
			}if(Tetnus){
				npc.lifeRegen -= 12;
				damage += 2;
			}if(RadiationSickness){
				npc.lifeRegen -= 180;
				damage += 1;
			}if(Dabilitated){
				npc.lifeRegen -= 160;
				damage += 16;
			}if(GodKiller){
				npc.lifeRegen -= 600;
				damage += 60;
			}
		}
	}
}