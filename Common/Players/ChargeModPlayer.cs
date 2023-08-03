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

namespace ChargerClass.Common.Players
{
	public class ChargeModPlayer : ModPlayer
	{
		public int DefaultCharge = 1000; //the defualt charge pre modifiers
		public int DefaultSpeed = 10; //the increment by which charge increases pre modifiers.
		public bool IronLung, Inhaler, Exhaler, Respirator, BreathingAid, /*Whether the player has a given accesory at the time*/
					AAABattery, Capacitor, CarBattery, OverCharger, PowerBank,
					Charger, ChargeRespository, ExtensionCord, LightningRod, Generator,
					GripTape, LeatherGlove, ShootingGlove, RedDot, TrackingSpecs, SecretStimulants, UltimateChargingGear;
		public bool LightHeaded;
		private int overChargeCount;  
		private int overChargeTimer = 0;
		private int inhalerTimer = 0;

		 //the total charge the player can use. MaxCharge / (ChargeSpeed * 60) = charge time in seconds.
		public int MaxCharge{
			get {
				int tempCharge = DefaultCharge;

				if(PowerBank){ //player can only get bonuses from combined items once
					tempCharge += (int)(DefaultCharge * 0.15f);
				}else if(CarBattery){
					tempCharge += (int)(DefaultCharge * 0.10f);
				}else if(AAABattery){
					tempCharge += (int)(DefaultCharge * 0.05f);
				}

				if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon){//player can only get bonuses from combined items once
					if(BreathingAid){
						tempCharge += (int)(DefaultCharge * 0.25f);
					}else if(IronLung){
						tempCharge += (int)(DefaultCharge * 0.15f);
					}
				}

				tempCharge += (int)(DefaultCharge * 0.03f * overChargeCount);

				return tempCharge;
			}
			set { DefaultCharge = value; }
		}

		//the increment by which charge increases
		public int ChargeSpeed{
			get {
				int tempSpeed = DefaultSpeed;

				if(Generator){//player can only get bonuses from combined items once
					tempSpeed += (int)(DefaultSpeed * 0.15f);
				}else if(ExtensionCord){
					tempSpeed += (int)(DefaultSpeed * 0.10f);
				}else if(Charger){
					tempSpeed += (int)(DefaultSpeed * 0.05f);
				}

				if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon){//player can only get bonuses from combined items once
					if(BreathingAid){
						tempSpeed += (int)(DefaultSpeed * 0.25f);
					}else if(Respirator){
						tempSpeed += (int)(DefaultSpeed * 0.15f);
					}
				}

				return tempSpeed;
			}
			set { DefaultSpeed = value; }
		}

		public void GetChargeDamage(ref int damage, int chargeLevel){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon && (BreathingAid || Exhaler)){
				damage += (int)(0.03f * damage);
			}

			if(UltimateChargingGear){//player can only get bonuses from combined items once
				damage += (int)(0.03f * damage * chargeLevel);
			}else if(ShootingGlove){
				damage += (int)(0.02f * damage * chargeLevel);
			}else if(GripTape){
				damage += (int)(0.01f * damage * chargeLevel);
			}
		}

		public void GetChargeCritChance(ref float crit, int chargeLevel){
			if(UltimateChargingGear){//player can only get bonuses from combined items once
				crit += 0.03f * chargeLevel;
			}else if(TrackingSpecs){
				crit += 0.02f * chargeLevel;
			}else if(RedDot){
				crit += 0.01f * chargeLevel;
			}
		}

		public void GetProjectileSpeed(ref Vector2 velocity){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon && (Exhaler || BreathingAid)){
				velocity *= 1.25f;
			}
		}

		public void ModifyChargeLevel(ref int chargeLevel, int crit){
			if((SecretStimulants || UltimateChargingGear) && ChargerClassModSystem.Random.NextDouble() <= crit / 100d){
				chargeLevel++;
			}	
		}

		public void RepositorySuccess(int totalCharge){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon){
				weapon.charge += totalCharge / 10;
				if(weapon.charge > MaxCharge) weapon.charge = MaxCharge;
			}
		}

		public bool GetShock() => Capacitor || CarBattery || PowerBank;

		public bool GetChargeRepository() => ChargeRespository || ExtensionCord || Generator;

		public int GetLightningRod(){ //0 is no accesory, 1 is lightning rod, and 2 is generator.
			if(Generator) return 2;
			else if(LightningRod) return 1;
			else return 0;
		}

		public override void PostUpdateEquips (){
			if(!(OverCharger || PowerBank)){//resets the timer if the player doesnt have the accesories. this will set the count to 0 in a couple lines.
				overChargeTimer = 0;
			}
			if(overChargeTimer > 0){ //decrement if the timer is still going.
				overChargeTimer--;
			}else{
				overChargeCount = 0; //reset the count if for any reason the timer has run out.
			}
		}

		public void ShootInfo(bool fullyCharged){
			if(OverCharger || PowerBank){
				if(fullyCharged){ //if the corrent accessories are equiped, the weapon has shot and it was fully charged.
					if(overChargeCount < 3){
						overChargeCount++; //increase the amount if it is not greater than the max.
					}
					overChargeTimer = 600; //reset the timer regardless of the max.
				}else{
					overChargeCount = 0;// otherwise reset the timer and the count.
					overChargeTimer = 0;
				}
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet) {
			if (ChargerClassModSystem.InhalerKeybind.JustPressed && Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon && (Inhaler || BreathingAid) && !LightHeaded) {
				Player.AddBuff(ModContent.BuffType<LightHeaded>() , 1200); //debuff to stop the player from using the ability for a 20 seconds.
				weapon.charge += weapon.chargeAmount;
				if(weapon.charge > MaxCharge) weapon.charge = MaxCharge; //make sure charge doesnt go over max. This should probably also be implimented in the chargeweapon but I dont want to deal with timing and tics.
			}
		}

		public override void ResetEffects() {
			IronLung = Inhaler = Exhaler = Respirator = BreathingAid =
			AAABattery = Capacitor = CarBattery = OverCharger = PowerBank =
			Charger = ChargeRespository = ExtensionCord = LightningRod = Generator =
			GripTape = LeatherGlove = ShootingGlove = RedDot = TrackingSpecs = SecretStimulants = UltimateChargingGear = false; //reset accessory effects.
			LightHeaded = false; //reset buff effects.

		}
	}
}