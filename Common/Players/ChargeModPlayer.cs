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

namespace ChargerClass.Common.Players
{
	public class ChargeModPlayer : ModPlayer
	{
		public static readonly int DefaultCharge = 1000; //the defualt charge pre modifiers
		public bool IronLung, Inhaler, Exhaler, Respirator, BreathingAid, /*Whether the player has a given accesory at the time*/
					AAABattery, Capacitor, CarBattery, OverCharger, PowerBank,
					Charger, ChargeRepository, ExtensionCord, LightningRod, Generator,
					GripTape, LeatherGlove, ShootingGlove, RedDot, TrackingSpecs,
					 SecretStimulants, UltimateChargingGear, Haler, ChargerEmblem,
					 HydrogenBreath, IronDiaphragm;
		public bool LightHeaded, RadiationSickness, Charge, Impatience, Stamina;
		private int overChargeCount;  
		private int overChargeTimer = 0;

		 //the total charge the player can use. MaxCharge / (ChargeSpeed * 60) = charge time in seconds.

		public StatModifier GetChargeAmountModifier(){
			var chargeAmount = StatModifier.Default;

			if(Impatience) chargeAmount += 0.25f;

			return chargeAmount;
		}

		public int GetMaxCharge(){
			var maxCharge = StatModifier.Default;

			if(PowerBank) maxCharge += 0.15f;
			else if(CarBattery) maxCharge += 0.10f;
			else if(AAABattery) maxCharge += 0.05f;
			

			if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon){
				if(BreathingAid) maxCharge += 0.25f;
				else if(IronLung) maxCharge += 0.15f;
			}

			if(Stamina) maxCharge += 0.2f;

			maxCharge += 0.03f * overChargeCount;

			return (int)maxCharge.ApplyTo(DefaultCharge);
		}

		public override float UseTimeMultiplier(Item item){
			if(item.ModItem is ChargeWeapon weapon){
				float speed = 1f;

				if(Generator) speed += 0.15f;
				else if(ExtensionCord) speed += 0.10f;
				else if(Charger) speed += 0.05f;
				

				if(weapon.blowWeapon){
					if(BreathingAid) speed += 0.25f;
					else if(IronDiaphragm) speed += 0.15f;
				}

				if(Charge) speed += 0.15f;

				return speed;
			}
			return 1f;
		}

		public override void ModifyWeaponDamage(Item item, ref StatModifier damage){
			if(item.ModItem is not ChargeWeapon chargeWeapon) return;

			if(ChargerEmblem) damage += 0.2f;

			if(chargeWeapon.blowWeapon){
				if(Exhaler) damage += 0.02f * chargeWeapon.chargeLevel;
				else if(Haler) damage += 0.03f * chargeWeapon.chargeLevel;
				
				if(Respirator) damage += 0.15f;
				else if(BreathingAid) damage += 0.25f;
			}

			if(UltimateChargingGear)damage += 0.03f * chargeWeapon.chargeLevel;
			else if(ShootingGlove) damage += 0.02f * chargeWeapon.chargeLevel;
			else if(GripTape) damage += 0.01f * chargeWeapon.chargeLevel;
		}

		public override void ModifyWeaponCrit(Item item, ref float crit){
			if(item.ModItem is not ChargeWeapon chargeWeapon) return;

			if(UltimateChargingGear)crit += 0.03f * chargeWeapon.chargeLevel;
			else if(TrackingSpecs)crit += 0.02f * chargeWeapon.chargeLevel;
			else if(RedDot)crit += 0.01f * chargeWeapon.chargeLevel;
		
		}

		public void ModifyProjectileSpeed(ref Vector2 velocity){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon && (Exhaler || Haler)){
				velocity *= 1.25f;
			}
		}

		public void ModifyChargeLevel(ref int chargeLevel, int crit){
			if((SecretStimulants || UltimateChargingGear) && Main.rand.NextBool(Utils.Clamp(crit, 0, 100), 100)){
				chargeLevel++;
			}
		}

		public void RepositorySuccess(int totalCharge){
			if(Player.HeldItem.ModItem is ChargeWeapon weapon){
				weapon.bonusCharge += totalCharge / 10;
			}
		}

		public bool GetShock() => Capacitor || CarBattery || PowerBank;

		public bool GetHydrogen() => HydrogenBreath || Haler;

		public bool GetChargeRepository() => ChargeRepository || Generator;

		public int GetLightningRod(){ //0 is no accesory, 1 is lightning rod, and 2 is generator.
			if(Generator) return 3;
			else if(ExtensionCord) return 2;
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

		public void ShootInfo(ChargeWeapon weapon, int charge){
			bool fullyCharged = charge >= GetMaxCharge();
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
			if (ChargerClassGeneralSystem.InhalerKeybind.JustPressed && Player.HeldItem.ModItem is ChargeWeapon weapon && weapon.blowWeapon && (Inhaler || Haler) && !LightHeaded) {
				Player.AddBuff(ModContent.BuffType<LightHeaded>() , 1200); //debuff to stop the player from using the ability for a 20 seconds.
				weapon.bonusCharge += weapon.chargeAmount;
			}
		}

		public override void ResetEffects() {
			IronLung = Inhaler = Exhaler = Respirator = BreathingAid =
			AAABattery = Capacitor = CarBattery = OverCharger = PowerBank =
			Charger = ChargeRepository = ExtensionCord = LightningRod = Generator =
			GripTape = LeatherGlove = ShootingGlove = RedDot = TrackingSpecs = 
			SecretStimulants = UltimateChargingGear = Haler = ChargerEmblem = false; //reset accessory effects.
			LightHeaded = RadiationSickness = Charge = Impatience = Stamina = false; //reset buff effects.
		}

		public override void UpdateBadLifeRegen() {
			if (RadiationSickness) {
				if (Player.lifeRegen > 0) Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				//Player.lifeRegen -= 8;
			}
		}
	}
}