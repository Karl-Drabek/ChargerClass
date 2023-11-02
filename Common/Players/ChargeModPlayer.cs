using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;
using ChargerClass.Content.Buffs;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Items.Consumables;
using Terraria.ModLoader.IO;
using System.IO;
using ChargerClass.Content.Items.Armor.ChaosArmor;
using ChargerClass.Content.Items.Armor.MechArmor;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.Items.Armor;
using Terraria.DataStructures;
using ChargerClass.Content.Projectiles;
using static Terraria.NPC;
using ChargerClass.Content.Items.Acessories;

namespace ChargerClass.Common.Players
{
	public class ChargeModPlayer : ModPlayer
	{
		public const int MaxAdrenaline = 10_000;
		public static readonly int DefaultCharge = 1000; //the defualt charge pre modifiers
		public bool HasIronLung, Inhaler, HasExhaler, HasRespirator, HasBreathingAid, /*Whether the player has a given accesory at the time*/
					HasAAABattery, Capacitor, HasCarBattery, HasOvercharger, HasPowerBank,
					HasCharger, HasChargeRepository, HasExtensionCord, LightningRod, HasGenerator,
					HasGripTape, LeatherGlove, HasShootingGlove, HasRedDot, HasTrackingSpecs,
					 SecretStimulants, HasUltimateChargingGear, Haler, HasChargerEmblem,
					 HydrogenBreath, IronDiaphragm, OverCritter;
		public bool LightHeaded, RadiationSickness, Charge, Impatience, Stamina, RocketStormCooldown, Adrenaline;
		private int overChargeCount, AdrenalineCharge;  
		private int overChargeTimer = 0;

		public bool FestiveSet, HasChaosPlate, ChaosSet, MechLegs, MechLungSet, MADChest, MADSet,
		CobaltArmorSet, MythrilArmorSet, AdamantiteArmorSet, HasChlorophyteCasque, HallowedArmorSet;

		public int VoltaicNuggetCount = 0, MightyVoltaicScrapCount = 0, FrightfulVoltaicScrapCount = 0, OpticVoltaicScrapCount = 0, StellerVoltaicFragmentCount = 0, CosmicVoltaicFragmentCount = 0;
		public bool FragmentedQuaser = false;

		public int TailForCustomDart, PayloadForCustomDart, TipForCustomDart;

		public StatModifier GetChargeAmountModifier(){
			var chargeAmount = StatModifier.Default;

			chargeAmount -= OpticVoltaicScrap.ChargeLevelDecrease / 100f * OpticVoltaicScrapCount;
			if(Impatience) chargeAmount -= ImpatiencePotion.ChargeLevelDecrease / 100f;

			return chargeAmount;
		}

		public StatModifier MaxCharge = StatModifier.Default;
		public int GetMaxCharge(){
			var maxCharge = MaxCharge;

			maxCharge.Base += (VoltaicNuggetCount + MightyVoltaicScrapCount + StellerVoltaicFragmentCount) * VoltaicNugget.MaxChargeIncrease;

			if(HasPowerBank) maxCharge += PowerBank.MaxChargeIncrease / 100f;
			else if(HasCarBattery) maxCharge += CarBattery.maxChargeIncrease / 100f;
			else if(HasAAABattery) maxCharge += AAABattery.maxChargeIncrease / 100f;
			

			if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon){
				if(HasBreathingAid) maxCharge += BreathingAid.StatIncrease / 100f;
				else if(HasIronLung) maxCharge += IronLung.MaxChargeIncrease / 100f;
			}

			if(Stamina) maxCharge += StaminaPotion.MaxChargeIncrease / 100f;

			maxCharge += Overcharger.OverChargeAmount / 100f * overChargeCount;
			return (int)maxCharge.ApplyTo(DefaultCharge);
		}

		public override float UseTimeMultiplier(Item item){
			if(item.ModItem is ChargeWeapon weapon){
				StatModifier speed = StatModifier.Default;

				speed += (FrightfulVoltaicScrapCount + CosmicVoltaicFragmentCount) * 0.05f;

				if(HasGenerator) speed += Generator.ChargeSpeedIncrease / 100f;
				else if(HasExtensionCord) speed += ExtensionCord.ChargeSpeedIncrease / 100f;
				else if(HasCharger) speed += Charger.ChargeSpeedIncrease / 100f;
				

				if(weapon.blowWeapon){
					if(HasBreathingAid) speed += BreathingAid.StatIncrease / 100f;
					else if(IronDiaphragm) speed += Diaphragm.ChargeSpeedIncrease / 100f;
				}

				if(Charge) speed += ChargePotion.ChargeSpeedIncrease / 100f;

				if(Adrenaline) speed *= 2f;

				return 1f / speed.ApplyTo(1f);
			}
			return 1f;
		}

		public override void ModifyWeaponDamage(Item item, ref StatModifier damage){
			if(item.ModItem is not ChargeWeapon chargeWeapon) return;

			if(HasChargerEmblem) damage += ChargerEmblem.DamageIncrease / 100f;

			if(chargeWeapon.blowWeapon){
				if(HasExhaler) damage += Exhaler.ChargeDamageIncrease / 100f * chargeWeapon.chargeLevel;
				else if(Haler) damage += 0.03f * chargeWeapon.chargeLevel;
				
				if(HasRespirator) damage += Respirator.DamageIncrease / 100f;
				else if(HasBreathingAid) damage += BreathingAid.StatIncrease / 100f;
			}

			if(HasUltimateChargingGear)damage += UltimateChargingGear.StatIncrease / 100f * chargeWeapon.chargeLevel;
			else if(HasShootingGlove) damage += ShootingGlove.ChargeDamageIncrease / 100f* chargeWeapon.chargeLevel;
			else if(HasGripTape) damage += GripTape.ChargeDamageIncrease / 100f * chargeWeapon.chargeLevel;

			if(HasChlorophyteCasque) damage += ChlorophyteCasque.StatIncreasePerLevel * ((chargeWeapon.chargeLevel > ChlorophyteCasque.MaxLevels) ? ChlorophyteCasque.MaxLevels : chargeWeapon.chargeLevel);

			if(MechLungSet && chargeWeapon.blowWeapon) damage += MechLung.SetCritChanceIncrease / 100f;

			
			if(Adrenaline) damage *= 2f;
		}

		public override void ModifyWeaponCrit(Item item, ref float crit){
			if(item.ModItem is not ChargeWeapon chargeWeapon) return;

			if(HasUltimateChargingGear)crit += UltimateChargingGear.StatIncrease / 100f * chargeWeapon.chargeLevel;
			else if(HasTrackingSpecs)crit += TrackingSpecs.CritChanceIncrease / 100f * chargeWeapon.chargeLevel;
			else if(HasRedDot)crit += RedDot.CritChanceIncrease / 100f * chargeWeapon.chargeLevel;

			if(HasChaosPlate) crit += ChaosPlate.ChargeCritChanceIncreasePerLevel * ((chargeWeapon.chargeLevel > ChaosPlate.MaxCritIncrease) ? ChaosPlate.MaxCritIncrease : chargeWeapon.chargeLevel);
			if(CobaltArmorSet) crit += CobaltCasque.SetCritIncreasePerLevel * ((chargeWeapon.chargeLevel > CobaltCasque.MaxCritIncrease) ? CobaltCasque.MaxCritIncrease : chargeWeapon.chargeLevel);
			if(MythrilArmorSet) crit += MythrilCasque.SetCritIncreasePerLevel * ((chargeWeapon.chargeLevel > MythrilCasque.MaxCritIncrease) ? MythrilCasque.MaxCritIncrease : chargeWeapon.chargeLevel);
			if(AdamantiteArmorSet) crit += AdamantiteCasque.SetCritIncreasePerLevel * ((chargeWeapon.chargeLevel > AdamantiteCasque.MaxCritIncrease) ? AdamantiteCasque.MaxCritIncrease : chargeWeapon.chargeLevel);
			if(HasChlorophyteCasque) crit += ChlorophyteCasque.StatIncreasePerLevel * ((chargeWeapon.chargeLevel > ChlorophyteCasque.MaxLevels) ? ChlorophyteCasque.MaxLevels : chargeWeapon.chargeLevel);
			if(HallowedArmorSet) crit += HallowedCasque.SetCritIncreasePerLevel * ((chargeWeapon.chargeLevel > HallowedCasque.MaxCritIncrease) ? HallowedCasque.MaxCritIncrease : chargeWeapon.chargeLevel);
			
			if(MechLungSet && chargeWeapon.blowWeapon) crit += MechLung.SetCritChanceIncrease / 100f;
			if(Adrenaline) crit *= 2f;
		}

		public void ModifyProjectileSpeed(ref Vector2 velocity){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon){
				if(HasExhaler || Haler) velocity *= 1 + Exhaler.ChargeVelocityIncrease / 100f;
				if(MechLungSet) velocity *= MechLung.SetShootSpeedIncrease / 100f;
			}
		}

		public void PostProjectileEffects(ChargeWeapon modItem, Projectile proj, ChargerProjectile chargerProj){
			if(MechLungSet && modItem.blowWeapon) proj.penetrate += MechLung.SetPierceIncrease;
			chargerProj.Hydrogenized = modItem.blowWeapon && HydrogenBreath;
            if(HasChargeRepository || HasGenerator) chargerProj.Repository = modItem.charge;
			if(LeatherGlove) chargerProj.LeatherGloveChargeLevel = modItem.chargeLevel;
			PostProjectileEffects(proj, chargerProj);
		}

		public void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj){
			chargerProj.Electrified = Capacitor || HasCarBattery || HasPowerBank;
			if(MADChest) chargerProj.BossBonus = true;
			if(FestiveSet) chargerProj.SpawnRockets = true;
		}

		public void ModifyChargeLevel(ref int chargeLevel, int crit){
			if((SecretStimulants || HasUltimateChargingGear) && Main.rand.NextBool(Utils.Clamp(crit, 0, 100), 100)) chargeLevel++;
			if(FragmentedQuaser) chargeLevel++;
			if(FestiveSet) chargeLevel++;
		}

		public void RepositorySuccess(int totalCharge){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon){
				weapon.bonusCharge += (int)(totalCharge * ChargeRepository.RetainedCharge / 100f);
			}
		}
		public int GetLightningRod(){ //0 is no accesory, 1 is lightning rod, and 2 is generator.
			if(HasGenerator) return 3;
			else if(HasExtensionCord) return 2;
			else if(LightningRod) return 1;
			else return 0;
		}

		public override void PostUpdateEquips (){
			if(!ChaosSet) AdrenalineCharge = 0;	
			if(!(HasOvercharger || HasPowerBank)){//resets the timer if the player doesnt have the accesories. this will set the count to 0 in a couple lines.
				overChargeTimer = 0;
			}
			if(overChargeTimer > 0){ //decrement if the timer is still going.
				overChargeTimer--;
			}else{
				overChargeCount = 0; //reset the count if for any reason the timer has run out.
			}
			if(MechLegs){
				Player.wingTimeMax = ArmorIDs.Wing.Sets.Stats[MechLeggings.wingsSlot].FlyTime;
				Player.wingsLogic = MechLeggings.wingsSlot;
				Player.noFallDmg = true;
				if(!(Player.controlJump && Player.TryingToHoverDown && Player.wingTime > 0f) && !(Player.wingsLogic > 0 && Player.controlJump && Player.wingTime > 0f && Player.jump == 0 && Player.velocity.Y != 0f)) return;
				for(int i = 0; i < 4; i++){ //smoke on wingtime
					for(int j = 0; j < 4; j++){
						Dust dust = Dust.NewDustDirect(new Vector2(Player.BottomLeft.X  - Player.width, Player.BottomLeft.Y), Player.width * 3, 1, DustID.Smoke, Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(4f, 6f), 100, default, Main.rand.NextFloat(1.5f, 2.5f));
						dust.fadeIn = 1.5f;
						dust.noGravity = true;
					}
					Dust.NewDustPerfect(Player.BottomLeft, DustID.Torch, new Vector2(-0.8f, 2).RotatedByRandom(MathHelper.ToRadians(10)) * Main.rand.NextFloat(1f, 1.1f), 100, default, 1.5f);
					Dust.NewDustPerfect(Player.BottomRight, DustID.Torch, new Vector2(0.8f, 2).RotatedByRandom(MathHelper.ToRadians(10)) * Main.rand.NextFloat(1f, 1.1f), 100, default, 1.5f);
				}
			}
		}

		public void ShootInfo(ChargeWeapon weapon, int charge){
			if(HasOvercharger || HasPowerBank){
				if(charge >= GetMaxCharge()){ //if the corrent accessories are equiped, the weapon has shot and it was fully charged.
					if(overChargeCount < Overcharger.OverChargeMax){
						overChargeCount++; //increase the amount if it is not greater than the max.
					}
					overChargeTimer = 600; //reset the timer regardless of the max.
				}else{
					overChargeCount = 0;// otherwise reset the timer and the count.
					overChargeTimer = 0;
				}
			}
			if(ChaosSet && !Adrenaline){
				AdrenalineCharge += (int)(Math.Pow(charge, 1.25d) * weapon.Item.useTime / 1000d);
				if(AdrenalineCharge > MaxAdrenaline) AdrenalineCharge = MaxAdrenaline;
			}
		}

		public override void FrameEffects(){
			//if(MechLegs) Player.wings = MechLeggings.wingsSlot;
		}

		public override void ProcessTriggers(TriggersSet triggersSet) {
			if (ChargerClassGeneralSystem.InhalerKeybind.JustPressed && Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon && (Inhaler || Haler) && !LightHeaded) {
				Player.AddBuff(ModContent.BuffType<LightHeaded>() , 1200); //debuff to stop the player from using the ability for a 20 seconds.
				weapon.bonusCharge += GetMaxCharge();
			}
			if (MADSet && ChargerClassGeneralSystem.RocketStormKeybind.JustPressed && !RocketStormCooldown) {
				Player.AddBuff(ModContent.BuffType<RocketStormCooldown>(), 1800);
				for(int i = 0; i < 36; i++){
					Projectile proj = Projectile.NewProjectileDirect(new EntitySource_Parent(Player),
					Player.Center, (Vector2.UnitX * RocketStormProjectile.Speed).RotatedBy(MathHelper.ToRadians(i * 10)), ModContent.ProjectileType<RocketStormProjectile>(), 40, 2f);
					PostProjectileEffects(proj, proj.GetGlobalProjectile<ChargerProjectile>());
				}
			}
			if (ChargerClassGeneralSystem.ChaosAdrenaline.JustPressed && AdrenalineCharge >= MaxAdrenaline) {
				AdrenalineCharge = 0;
				Player.AddBuff(ModContent.BuffType<Adrenaline>(), 600);
			}
		}

		public override void ResetEffects() {
			HasIronLung = Inhaler = HasExhaler = HasRespirator = HasBreathingAid =
			HasAAABattery = Capacitor = HasCarBattery = HasOvercharger = HasPowerBank =
			HasCharger = HasChargeRepository = HasExtensionCord = LightningRod = HasGenerator =
			HasGripTape = LeatherGlove = HasShootingGlove = HasRedDot = HasTrackingSpecs = 
			SecretStimulants = HasUltimateChargingGear = Haler = HasChargerEmblem = OverCritter = HydrogenBreath = false; //reset accessory effects.
			LightHeaded = RadiationSickness = Charge = Impatience = Stamina = RocketStormCooldown = Adrenaline = false; //reset buff effects.
			FestiveSet = ChaosSet = HasChaosPlate = MechLegs = MechLungSet = MADChest = MADSet = 
			CobaltArmorSet = MythrilArmorSet = AdamantiteArmorSet = false;
			MaxCharge = StatModifier.Default;
		}

		public override void UpdateBadLifeRegen() {
			if (RadiationSickness) {
				if (Player.lifeRegen > 0) Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 30;
			}
		}

		public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
			ModPacket packet = Mod.GetPacket();
			packet.Write((byte)ChargerClass.MessageType.StatIncreasePlayerSync);
			packet.Write((byte)Player.whoAmI);
			packet.Write((byte)VoltaicNuggetCount);
			packet.Write((byte)MightyVoltaicScrapCount);
			packet.Write((byte)FrightfulVoltaicScrapCount);
			packet.Write((byte)OpticVoltaicScrapCount);
			packet.Write((byte)CosmicVoltaicFragmentCount);
			packet.Write((byte)StellerVoltaicFragmentCount);
			packet.Write(FragmentedQuaser? (byte)1 : (byte)0);
			packet.Send(toWho, fromWho);
		}

		public void ReceivePlayerSync(BinaryReader reader) {
			VoltaicNuggetCount = reader.ReadByte();
			MightyVoltaicScrapCount = reader.ReadByte();
			FrightfulVoltaicScrapCount = reader.ReadByte();
			OpticVoltaicScrapCount = reader.ReadByte();
			CosmicVoltaicFragmentCount = reader.ReadByte();
			StellerVoltaicFragmentCount = reader.ReadByte();
			FragmentedQuaser = reader.ReadByte() == 1;
		}

		public override void CopyClientState(ModPlayer targetCopy) {
			ChargeModPlayer clone = (ChargeModPlayer)targetCopy;

			clone.VoltaicNuggetCount = VoltaicNuggetCount;
			clone.MightyVoltaicScrapCount = MightyVoltaicScrapCount;
			clone.FrightfulVoltaicScrapCount = FrightfulVoltaicScrapCount;
			clone.OpticVoltaicScrapCount = OpticVoltaicScrapCount;
			clone.StellerVoltaicFragmentCount = StellerVoltaicFragmentCount;
			clone.CosmicVoltaicFragmentCount = CosmicVoltaicFragmentCount;
			clone.FragmentedQuaser = FragmentedQuaser;
		}

		public override void SendClientChanges(ModPlayer clientPlayer) {
			ChargeModPlayer clone = (ChargeModPlayer)clientPlayer;

			if (VoltaicNuggetCount != clone.VoltaicNuggetCount ||
				MightyVoltaicScrapCount != clone.MightyVoltaicScrapCount ||
				FrightfulVoltaicScrapCount != clone.FrightfulVoltaicScrapCount ||
				OpticVoltaicScrapCount != clone.OpticVoltaicScrapCount ||
				StellerVoltaicFragmentCount != clone.StellerVoltaicFragmentCount ||
				CosmicVoltaicFragmentCount != clone.CosmicVoltaicFragmentCount ||
				FragmentedQuaser != clone.FragmentedQuaser)
				SyncPlayer(toWho: -1, fromWho: Main.myPlayer, newPlayer: false);
		}

		public override void SaveData(TagCompound tag) {
			tag["voltaicNuggets"] = VoltaicNuggetCount;
			tag["mightyVoltaicScrapCount"] = MightyVoltaicScrapCount;
			tag["frightfulVoltaicScrapCount"] = FrightfulVoltaicScrapCount;
			tag["spticVoltaicScrapCount"] = OpticVoltaicScrapCount;
			tag["StellerVoltaicFragmentCount"] = StellerVoltaicFragmentCount;
			tag["CosmicVoltaicFragmentCount"] = CosmicVoltaicFragmentCount;
			tag["fragmentedQuaser"] = FragmentedQuaser;
		}

		public override void LoadData(TagCompound tag) {
			VoltaicNuggetCount = tag.GetInt("voltaicNuggets");
			MightyVoltaicScrapCount = tag.GetInt("mightyVoltaicScrapCount");
			FrightfulVoltaicScrapCount = tag.GetInt("frightfulVoltaicScrapCount");
			OpticVoltaicScrapCount = tag.GetInt("spticVoltaicScrapCount");
			StellerVoltaicFragmentCount = tag.GetInt("StellerVoltaicFragmentCount");
			CosmicVoltaicFragmentCount = tag.GetInt("CosmicVoltaicFragmentCount");
			FragmentedQuaser = tag.GetBool("fragmentedQuaser");
		}
		int critCount = 0;
		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref HitModifiers hitModifiers){
			if(OverCritter){
				hitModifiers.HideCombatText();
				critCount = proj.CritChance / 100 + (Main.rand.NextBool(proj.CritChance % 100, 100) ? 1 : 0);
				hitModifiers.FinalDamage += (hitModifiers.CritDamage.Additive - 1) * critCount - (proj.CritChance > 100? 1 : 0);
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, HitInfo hitInfo, int damageDone){
			if(OverCritter){
				Color color = critCount switch{
					0 => CombatText.DamagedHostile,
					1 => CombatText.DamagedHostileCrit,
					2 => Color.DarkRed,
					3 => Color.Fuchsia,
					4 => Color.DarkViolet,
					5 => Color.Navy,
					_ => Color.Black
				};
				CombatText.NewText(target.getRect(), color, damageDone, true, true);
			}
		}
	}
}