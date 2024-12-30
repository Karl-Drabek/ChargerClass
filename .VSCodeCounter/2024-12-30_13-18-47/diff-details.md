# Diff Details

Date : 2024-12-30 13:18:47

Directory c:\\Program Files (x86)\\Steam\\steamapps\\common\\tModLoader\\My Games\\Terraria\\tModLoader\\ModSources\\ChargerClass

Total : 642 files,  2432 codes, 43 comments, 817 blanks, all 3292 lines

[Summary](results.md) / [Details](details.md) / [Diff Summary](diff.md) / Diff Details

## Files
| filename | language | code | comment | blank | total |
| :--- | :--- | ---: | ---: | ---: | ---: |
| [.config/dotnet-tools.json](/.config/dotnet-tools.json) | JSON | 13 | 0 | 0 | 13 |
| [ChargerClass.cs](/ChargerClass.cs) | C# | 30 | 1 | 4 | 35 |
| [ChargerClass.csproj](/ChargerClass.csproj) | XML | 9 | 0 | 1 | 10 |
| [Common/Configs/Config.cs](/Common/Configs/Config.cs) | C# | 13 | 3 | 5 | 21 |
| [Common/DrawLayers/AnimatedDrawLayer.cs](/Common/DrawLayers/AnimatedDrawLayer.cs) | C# | 57 | 1 | 16 | 74 |
| [Common/DrawLayers/BloontoniumBlasterDrawLayer.cs](/Common/DrawLayers/BloontoniumBlasterDrawLayer.cs) | C# | 40 | 0 | 7 | 47 |
| [Common/DrawLayers/CentrifugalGunDrawLayer.cs](/Common/DrawLayers/CentrifugalGunDrawLayer.cs) | C# | 40 | 0 | 7 | 47 |
| [Common/DrawLayers/DartlingGunDrawLayer.cs](/Common/DrawLayers/DartlingGunDrawLayer.cs) | C# | 40 | 0 | 7 | 47 |
| [Common/DrawLayers/HydraRocketLauncherDrawLayer.cs](/Common/DrawLayers/HydraRocketLauncherDrawLayer.cs) | C# | 40 | 0 | 7 | 47 |
| [Common/DrawLayers/LaserDartlingGunDrawLayer.cs](/Common/DrawLayers/LaserDartlingGunDrawLayer.cs) | C# | 40 | 0 | 7 | 47 |
| [Common/DrawLayers/PremeCalamariDrawLayer.cs](/Common/DrawLayers/PremeCalamariDrawLayer.cs) | C# | 28 | 0 | 4 | 32 |
| [Common/DrawLayers/RayOfBloonDrawLayer.cs](/Common/DrawLayers/RayOfBloonDrawLayer.cs) | C# | 40 | 0 | 7 | 47 |
| [Common/DrawLayers/SupremeCalamariDrawLayer.cs](/Common/DrawLayers/SupremeCalamariDrawLayer.cs) | C# | 33 | 0 | 5 | 38 |
| [Common/Extensions/Explosions.cs](/Common/Extensions/Explosions.cs) | C# | 73 | 0 | 5 | 78 |
| [Common/Extensions/Targeting.cs](/Common/Extensions/Targeting.cs) | C# | 77 | 0 | 4 | 81 |
| [Common/GlobalNPCs/ModGlobalNPC.cs](/Common/GlobalNPCs/ModGlobalNPC.cs) | C# | 171 | 1 | 6 | 178 |
| [Common/GlobalNPCs/ModInstanceNPC.cs](/Common/GlobalNPCs/ModInstanceNPC.cs) | C# | 177 | 1 | 11 | 189 |
| [Common/GlobalProjectiles/ChargerProjectle.cs](/Common/GlobalProjectiles/ChargerProjectle.cs) | C# | 205 | 1 | 12 | 218 |
| [Common/ItemDropRules/DropConditions/BlueChargeDropCondition.cs](/Common/ItemDropRules/DropConditions/BlueChargeDropCondition.cs) | C# | 17 | 0 | 7 | 24 |
| [Common/ItemDropRules/DropConditions/ChargeDropCondition.cs](/Common/ItemDropRules/DropConditions/ChargeDropCondition.cs) | C# | 17 | 0 | 7 | 24 |
| [Common/ItemDropRules/DropConditions/OrangeChargeDropCondition.cs](/Common/ItemDropRules/DropConditions/OrangeChargeDropCondition.cs) | C# | 17 | 0 | 7 | 24 |
| [Common/Item/GlobalItem.cs](/Common/Item/GlobalItem.cs) | C# | 106 | 0 | 3 | 109 |
| [Common/ModSystems/ChargerClassGeneralSystem.cs](/Common/ModSystems/ChargerClassGeneralSystem.cs) | C# | 106 | 3 | 22 | 131 |
| [Common/ModSystems/ChargerClassOreSystem.cs](/Common/ModSystems/ChargerClassOreSystem.cs) | C# | 49 | 6 | 13 | 68 |
| [Common/ModSystems/ChargerMeterUISystem.cs](/Common/ModSystems/ChargerMeterUISystem.cs) | C# | 46 | 9 | 7 | 62 |
| [Common/ModSystems/DartAssemblyStationUISystem.cs](/Common/ModSystems/DartAssemblyStationUISystem.cs) | C# | 54 | 0 | 8 | 62 |
| [Common/Players/ChargeModPlayer.cs](/Common/Players/ChargeModPlayer.cs) | C# | 389 | 1 | 55 | 445 |
| [Common/Sets/Sets.cs](/Common/Sets/Sets.cs) | C# | 57 | 0 | 5 | 62 |
| [Content/Buffs/Adrenaline.cs](/Content/Buffs/Adrenaline.cs) | C# | 15 | 0 | 3 | 18 |
| [Content/Buffs/Bound.cs](/Content/Buffs/Bound.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/Charge.cs](/Content/Buffs/Charge.cs) | C# | 11 | 0 | 3 | 14 |
| [Content/Buffs/Cursed.cs](/Content/Buffs/Cursed.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/Dabilitated.cs](/Content/Buffs/Dabilitated.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/GodKiller.cs](/Content/Buffs/GodKiller.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/Impatience.cs](/Content/Buffs/Impatience.cs) | C# | 11 | 0 | 3 | 14 |
| [Content/Buffs/LeadPoisoning.cs](/Content/Buffs/LeadPoisoning.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/LightHeaded.cs](/Content/Buffs/LightHeaded.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/Plague.cs](/Content/Buffs/Plague.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/RadiationSickness.cs](/Content/Buffs/RadiationSickness.cs) | C# | 20 | 0 | 5 | 25 |
| [Content/Buffs/RocketStormCooldown.cs](/Content/Buffs/RocketStormCooldown.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/Stamina.cs](/Content/Buffs/Stamina.cs) | C# | 11 | 0 | 3 | 14 |
| [Content/Buffs/Stunned.cs](/Content/Buffs/Stunned.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/SuperSlimed.cs](/Content/Buffs/SuperSlimed.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/Buffs/Tetnus.cs](/Content/Buffs/Tetnus.cs) | C# | 15 | 0 | 4 | 19 |
| [Content/DamageClasses/ChargerDamageClass.cs](/Content/DamageClasses/ChargerDamageClass.cs) | C# | 12 | 0 | 5 | 17 |
| [Content/Dusts/ConsumingDust.cs](/Content/Dusts/ConsumingDust.cs) | C# | 23 | 0 | 8 | 31 |
| [Content/Items/Acessories/AAABattery.cs](/Content/Items/Acessories/AAABattery.cs) | C# | 41 | 0 | 5 | 46 |
| [Content/Items/Acessories/BreathingAid.cs](/Content/Items/Acessories/BreathingAid.cs) | C# | 42 | 0 | 4 | 46 |
| [Content/Items/Acessories/Capacitor.cs](/Content/Items/Acessories/Capacitor.cs) | C# | 33 | 0 | 4 | 37 |
| [Content/Items/Acessories/CarBattery.cs](/Content/Items/Acessories/CarBattery.cs) | C# | 41 | 0 | 5 | 46 |
| [Content/Items/Acessories/ChargeRepository.cs](/Content/Items/Acessories/ChargeRepository.cs) | C# | 41 | 0 | 5 | 46 |
| [Content/Items/Acessories/Charger.cs](/Content/Items/Acessories/Charger.cs) | C# | 37 | 0 | 4 | 41 |
| [Content/Items/Acessories/ChargerEmblem.cs](/Content/Items/Acessories/ChargerEmblem.cs) | C# | 37 | 0 | 5 | 42 |
| [Content/Items/Acessories/Diaphragm.cs](/Content/Items/Acessories/Diaphragm.cs) | C# | 39 | 0 | 5 | 44 |
| [Content/Items/Acessories/Exhaler.cs](/Content/Items/Acessories/Exhaler.cs) | C# | 39 | 0 | 4 | 43 |
| [Content/Items/Acessories/ExtensionCord.cs](/Content/Items/Acessories/ExtensionCord.cs) | C# | 39 | 0 | 4 | 43 |
| [Content/Items/Acessories/Generator.cs](/Content/Items/Acessories/Generator.cs) | C# | 45 | 0 | 5 | 50 |
| [Content/Items/Acessories/GripTape.cs](/Content/Items/Acessories/GripTape.cs) | C# | 37 | 0 | 5 | 42 |
| [Content/Items/Acessories/Haler.cs](/Content/Items/Acessories/Haler.cs) | C# | 37 | 0 | 4 | 41 |
| [Content/Items/Acessories/HydrogenGas.cs](/Content/Items/Acessories/HydrogenGas.cs) | C# | 33 | 0 | 4 | 37 |
| [Content/Items/Acessories/Inhaler.cs](/Content/Items/Acessories/Inhaler.cs) | C# | 35 | 0 | 4 | 39 |
| [Content/Items/Acessories/IronLung.cs](/Content/Items/Acessories/IronLung.cs) | C# | 41 | 0 | 5 | 46 |
| [Content/Items/Acessories/LeatherGlove.cs](/Content/Items/Acessories/LeatherGlove.cs) | C# | 36 | 0 | 4 | 40 |
| [Content/Items/Acessories/LightningRod.cs](/Content/Items/Acessories/LightningRod.cs) | C# | 37 | 0 | 5 | 42 |
| [Content/Items/Acessories/OverCritter.cs](/Content/Items/Acessories/OverCritter.cs) | C# | 34 | 0 | 4 | 38 |
| [Content/Items/Acessories/Overcharger.cs](/Content/Items/Acessories/Overcharger.cs) | C# | 40 | 0 | 5 | 45 |
| [Content/Items/Acessories/PowerBank.cs](/Content/Items/Acessories/PowerBank.cs) | C# | 43 | 0 | 6 | 49 |
| [Content/Items/Acessories/RedDot.cs](/Content/Items/Acessories/RedDot.cs) | C# | 40 | 0 | 4 | 44 |
| [Content/Items/Acessories/Respirator.cs](/Content/Items/Acessories/Respirator.cs) | C# | 37 | 0 | 4 | 41 |
| [Content/Items/Acessories/SecretStimulants.cs](/Content/Items/Acessories/SecretStimulants.cs) | C# | 38 | 0 | 4 | 42 |
| [Content/Items/Acessories/ShootingGlove.cs](/Content/Items/Acessories/ShootingGlove.cs) | C# | 38 | 0 | 4 | 42 |
| [Content/Items/Acessories/TrackingSpecs.cs](/Content/Items/Acessories/TrackingSpecs.cs) | C# | 38 | 0 | 4 | 42 |
| [Content/Items/Acessories/UltimateChargingGear.cs](/Content/Items/Acessories/UltimateChargingGear.cs) | C# | 43 | 0 | 4 | 47 |
| [Content/Items/Ammo/BloontoniumDart.cs](/Content/Items/Ammo/BloontoniumDart.cs) | C# | 35 | 0 | 7 | 42 |
| [Content/Items/Ammo/BottledSlime.cs](/Content/Items/Ammo/BottledSlime.cs) | C# | 34 | 0 | 7 | 41 |
| [Content/Items/Ammo/Darts/CustomDart.cs](/Content/Items/Ammo/Darts/CustomDart.cs) | C# | 149 | 0 | 30 | 179 |
| [Content/Items/Ammo/Darts/DartComponent.cs](/Content/Items/Ammo/Darts/DartComponent.cs) | C# | 27 | 0 | 7 | 34 |
| [Content/Items/Ammo/Darts/Payloads/Atomizer.cs](/Content/Items/Ammo/Darts/Payloads/Atomizer.cs) | C# | 29 | 0 | 4 | 33 |
| [Content/Items/Ammo/Darts/Payloads/CryoCannister.cs](/Content/Items/Ammo/Darts/Payloads/CryoCannister.cs) | C# | 27 | 0 | 4 | 31 |
| [Content/Items/Ammo/Darts/Payloads/CursedCannister.cs](/Content/Items/Ammo/Darts/Payloads/CursedCannister.cs) | C# | 26 | 0 | 4 | 30 |
| [Content/Items/Ammo/Darts/Payloads/DartCannister.cs](/Content/Items/Ammo/Darts/Payloads/DartCannister.cs) | C# | 21 | 0 | 3 | 24 |
| [Content/Items/Ammo/Darts/Payloads/DartFrogDebilitator.cs](/Content/Items/Ammo/Darts/Payloads/DartFrogDebilitator.cs) | C# | 27 | 0 | 4 | 31 |
| [Content/Items/Ammo/Darts/Payloads/DeathFactor.cs](/Content/Items/Ammo/Darts/Payloads/DeathFactor.cs) | C# | 30 | 0 | 4 | 34 |
| [Content/Items/Ammo/Darts/Payloads/ExplosiveCannister.cs](/Content/Items/Ammo/Darts/Payloads/ExplosiveCannister.cs) | C# | 28 | 0 | 4 | 32 |
| [Content/Items/Ammo/Darts/Payloads/GodKillerCocktail.cs](/Content/Items/Ammo/Darts/Payloads/GodKillerCocktail.cs) | C# | 73 | 0 | 5 | 78 |
| [Content/Items/Ammo/Darts/Payloads/IchorCannister.cs](/Content/Items/Ammo/Darts/Payloads/IchorCannister.cs) | C# | 26 | 0 | 4 | 30 |
| [Content/Items/Ammo/Darts/Payloads/JellyfishCannister.cs](/Content/Items/Ammo/Darts/Payloads/JellyfishCannister.cs) | C# | 27 | 0 | 4 | 31 |
| [Content/Items/Ammo/Darts/Payloads/LavaCannister.cs](/Content/Items/Ammo/Darts/Payloads/LavaCannister.cs) | C# | 26 | 0 | 4 | 30 |
| [Content/Items/Ammo/Darts/Payloads/LiquidLeadCannister.cs](/Content/Items/Ammo/Darts/Payloads/LiquidLeadCannister.cs) | C# | 29 | 0 | 4 | 33 |
| [Content/Items/Ammo/Darts/Payloads/RadioactiveParsel.cs](/Content/Items/Ammo/Darts/Payloads/RadioactiveParsel.cs) | C# | 50 | 0 | 5 | 55 |
| [Content/Items/Ammo/Darts/Tails/BetsysBackwash.cs](/Content/Items/Ammo/Darts/Tails/BetsysBackwash.cs) | C# | 32 | 0 | 4 | 36 |
| [Content/Items/Ammo/Darts/Tails/BombingBay.cs](/Content/Items/Ammo/Darts/Tails/BombingBay.cs) | C# | 34 | 0 | 5 | 39 |
| [Content/Items/Ammo/Darts/Tails/CropDuster.cs](/Content/Items/Ammo/Darts/Tails/CropDuster.cs) | C# | 31 | 0 | 5 | 36 |
| [Content/Items/Ammo/Darts/Tails/EagleEye.cs](/Content/Items/Ammo/Darts/Tails/EagleEye.cs) | C# | 57 | 0 | 8 | 65 |
| [Content/Items/Ammo/Darts/Tails/FeatheredTail.cs](/Content/Items/Ammo/Darts/Tails/FeatheredTail.cs) | C# | 21 | 0 | 4 | 25 |
| [Content/Items/Ammo/Darts/Tails/HolyLightTail.cs](/Content/Items/Ammo/Darts/Tails/HolyLightTail.cs) | C# | 36 | 0 | 5 | 41 |
| [Content/Items/Ammo/Darts/Tails/MagesTail.cs](/Content/Items/Ammo/Darts/Tails/MagesTail.cs) | C# | 33 | 0 | 3 | 36 |
| [Content/Items/Ammo/Darts/Tails/PixieDuster.cs](/Content/Items/Ammo/Darts/Tails/PixieDuster.cs) | C# | 29 | 0 | 5 | 34 |
| [Content/Items/Ammo/Darts/Tails/PrismaticTail.cs](/Content/Items/Ammo/Darts/Tails/PrismaticTail.cs) | C# | 57 | 0 | 6 | 63 |
| [Content/Items/Ammo/Darts/Tails/RocketJets.cs](/Content/Items/Ammo/Darts/Tails/RocketJets.cs) | C# | 50 | 0 | 6 | 56 |
| [Content/Items/Ammo/Darts/Tails/TheCorruptor.cs](/Content/Items/Ammo/Darts/Tails/TheCorruptor.cs) | C# | 48 | 0 | 6 | 54 |
| [Content/Items/Ammo/Darts/Tails/ToxicTail.cs](/Content/Items/Ammo/Darts/Tails/ToxicTail.cs) | C# | 29 | 0 | 3 | 32 |
| [Content/Items/Ammo/Darts/Tails/UnholyTail.cs](/Content/Items/Ammo/Darts/Tails/UnholyTail.cs) | C# | 44 | 0 | 5 | 49 |
| [Content/Items/Ammo/Darts/Tips/AdamantiteTip.cs](/Content/Items/Ammo/Darts/Tips/AdamantiteTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/BoneTip.cs](/Content/Items/Ammo/Darts/Tips/BoneTip.cs) | C# | 23 | 0 | 4 | 27 |
| [Content/Items/Ammo/Darts/Tips/ChlorophyteTip.cs](/Content/Items/Ammo/Darts/Tips/ChlorophyteTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/HallowedTip.cs](/Content/Items/Ammo/Darts/Tips/HallowedTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/HellStoneTip.cs](/Content/Items/Ammo/Darts/Tips/HellStoneTip.cs) | C# | 28 | 0 | 5 | 33 |
| [Content/Items/Ammo/Darts/Tips/HypodermicNeedle.cs](/Content/Items/Ammo/Darts/Tips/HypodermicNeedle.cs) | C# | 25 | 0 | 4 | 29 |
| [Content/Items/Ammo/Darts/Tips/LihzahrdTip.cs](/Content/Items/Ammo/Darts/Tips/LihzahrdTip.cs) | C# | 27 | 0 | 5 | 32 |
| [Content/Items/Ammo/Darts/Tips/LunarTip.cs](/Content/Items/Ammo/Darts/Tips/LunarTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/MeteorTip.cs](/Content/Items/Ammo/Darts/Tips/MeteorTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/ShroomiteTip.cs](/Content/Items/Ammo/Darts/Tips/ShroomiteTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/SpectreTip.cs](/Content/Items/Ammo/Darts/Tips/SpectreTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/TitaniumTip.cs](/Content/Items/Ammo/Darts/Tips/TitaniumTip.cs) | C# | 24 | 0 | 4 | 28 |
| [Content/Items/Ammo/Darts/Tips/UnicornTip.cs](/Content/Items/Ammo/Darts/Tips/UnicornTip.cs) | C# | 23 | 0 | 4 | 27 |
| [Content/Items/Ammo/MiniCannonball.cs](/Content/Items/Ammo/MiniCannonball.cs) | C# | 34 | 0 | 7 | 41 |
| [Content/Items/Ammo/MonkeyDart.cs](/Content/Items/Ammo/MonkeyDart.cs) | C# | 27 | 0 | 6 | 33 |
| [Content/Items/Ammo/NectarNail.cs](/Content/Items/Ammo/NectarNail.cs) | C# | 35 | 0 | 7 | 42 |
| [Content/Items/Ammo/Potato.cs](/Content/Items/Ammo/Potato.cs) | C# | 38 | 0 | 7 | 45 |
| [Content/Items/Ammo/RocketPod.cs](/Content/Items/Ammo/RocketPod.cs) | C# | 36 | 0 | 7 | 43 |
| [Content/Items/Ammo/Rocks/BouncyRock.cs](/Content/Items/Ammo/Rocks/BouncyRock.cs) | C# | 38 | 0 | 7 | 45 |
| [Content/Items/Ammo/Rocks/HotRock.cs](/Content/Items/Ammo/Rocks/HotRock.cs) | C# | 38 | 0 | 8 | 46 |
| [Content/Items/Ammo/Rocks/Rock.cs](/Content/Items/Ammo/Rocks/Rock.cs) | C# | 34 | 0 | 7 | 41 |
| [Content/Items/Ammo/Rocks/Sinker.cs](/Content/Items/Ammo/Rocks/Sinker.cs) | C# | 34 | 0 | 7 | 41 |
| [Content/Items/Ammo/Rocks/Splitter.cs](/Content/Items/Ammo/Rocks/Splitter.cs) | C# | 34 | 0 | 7 | 41 |
| [Content/Items/Ammo/SoulofBunnies.cs](/Content/Items/Ammo/SoulofBunnies.cs) | C# | 26 | 0 | 7 | 33 |
| [Content/Items/Armor/AdamantiteCasque.cs](/Content/Items/Armor/AdamantiteCasque.cs) | C# | 50 | 2 | 8 | 60 |
| [Content/Items/Armor/AncientHallowedCasque.cs](/Content/Items/Armor/AncientHallowedCasque.cs) | C# | 50 | 2 | 8 | 60 |
| [Content/Items/Armor/ChaosArmor/ChaosHelmet.cs](/Content/Items/Armor/ChaosArmor/ChaosHelmet.cs) | C# | 49 | 2 | 8 | 59 |
| [Content/Items/Armor/ChaosArmor/ChaosLeggings.cs](/Content/Items/Armor/ChaosArmor/ChaosLeggings.cs) | C# | 40 | 2 | 5 | 47 |
| [Content/Items/Armor/ChaosArmor/ChaosPlate.cs](/Content/Items/Armor/ChaosArmor/ChaosPlate.cs) | C# | 42 | 2 | 6 | 50 |
| [Content/Items/Armor/ChlorophyteCasque.cs](/Content/Items/Armor/ChlorophyteCasque.cs) | C# | 41 | 2 | 6 | 49 |
| [Content/Items/Armor/CobaltCasque.cs](/Content/Items/Armor/CobaltCasque.cs) | C# | 50 | 2 | 8 | 60 |
| [Content/Items/Armor/ElectrudiumArmor/ElectrudiumChainmail.cs](/Content/Items/Armor/ElectrudiumArmor/ElectrudiumChainmail.cs) | C# | 32 | 2 | 6 | 40 |
| [Content/Items/Armor/ElectrudiumArmor/ElectrudiumGreaves.cs](/Content/Items/Armor/ElectrudiumArmor/ElectrudiumGreaves.cs) | C# | 32 | 2 | 5 | 39 |
| [Content/Items/Armor/ElectrudiumArmor/ElectrudiumHelmet.cs](/Content/Items/Armor/ElectrudiumArmor/ElectrudiumHelmet.cs) | C# | 49 | 2 | 7 | 58 |
| [Content/Items/Armor/FestiveArmor/FestiveBreastplate.cs](/Content/Items/Armor/FestiveArmor/FestiveBreastplate.cs) | C# | 37 | 2 | 6 | 45 |
| [Content/Items/Armor/FestiveArmor/FestiveHelmet.cs](/Content/Items/Armor/FestiveArmor/FestiveHelmet.cs) | C# | 52 | 2 | 7 | 61 |
| [Content/Items/Armor/FestiveArmor/FestiveLeggings.cs](/Content/Items/Armor/FestiveArmor/FestiveLeggings.cs) | C# | 36 | 2 | 7 | 45 |
| [Content/Items/Armor/HallowedCasque.cs](/Content/Items/Armor/HallowedCasque.cs) | C# | 50 | 2 | 8 | 60 |
| [Content/Items/Armor/MechArmor/MAD.cs](/Content/Items/Armor/MechArmor/MAD.cs) | C# | 46 | 2 | 9 | 57 |
| [Content/Items/Armor/MechArmor/MechHelmet.cs](/Content/Items/Armor/MechArmor/MechHelmet.cs) | C# | 40 | 2 | 5 | 47 |
| [Content/Items/Armor/MechArmor/MechLeggings.cs](/Content/Items/Armor/MechArmor/MechLeggings.cs) | C# | 49 | 2 | 8 | 59 |
| [Content/Items/Armor/MechArmor/MechLung.cs](/Content/Items/Armor/MechArmor/MechLung.cs) | C# | 56 | 2 | 12 | 70 |
| [Content/Items/Armor/MythrilCasque.cs](/Content/Items/Armor/MythrilCasque.cs) | C# | 50 | 2 | 8 | 60 |
| [Content/Items/Armor/OrichalcumCasque.cs](/Content/Items/Armor/OrichalcumCasque.cs) | C# | 43 | 2 | 6 | 51 |
| [Content/Items/Armor/PalladiumCasque.cs](/Content/Items/Armor/PalladiumCasque.cs) | C# | 43 | 2 | 6 | 51 |
| [Content/Items/Armor/TitaniumCasque.cs](/Content/Items/Armor/TitaniumCasque.cs) | C# | 43 | 2 | 6 | 51 |
| [Content/Items/BakedPotato.cs](/Content/Items/BakedPotato.cs) | C# | 33 | 0 | 5 | 38 |
| [Content/Items/BasicCircuitry.cs](/Content/Items/BasicCircuitry.cs) | C# | 29 | 0 | 5 | 34 |
| [Content/Items/BlueCharge.cs](/Content/Items/BlueCharge.cs) | C# | 27 | 0 | 3 | 30 |
| [Content/Items/ChargedComponents.cs](/Content/Items/ChargedComponents.cs) | C# | 29 | 0 | 5 | 34 |
| [Content/Items/ChristmasCheer.cs](/Content/Items/ChristmasCheer.cs) | C# | 19 | 0 | 4 | 23 |
| [Content/Items/ConcentratedGelSolution.cs](/Content/Items/ConcentratedGelSolution.cs) | C# | 26 | 0 | 5 | 31 |
| [Content/Items/Consumables/ChargePotion.cs](/Content/Items/Consumables/ChargePotion.cs) | C# | 46 | 1 | 5 | 52 |
| [Content/Items/Consumables/CosmicVoltaicFragment.cs](/Content/Items/Consumables/CosmicVoltaicFragment.cs) | C# | 41 | 0 | 5 | 46 |
| [Content/Items/Consumables/FragmentedQuasar.cs](/Content/Items/Consumables/FragmentedQuasar.cs) | C# | 27 | 0 | 3 | 30 |
| [Content/Items/Consumables/FrightfulVoltaicScrap.cs](/Content/Items/Consumables/FrightfulVoltaicScrap.cs) | C# | 42 | 0 | 5 | 47 |
| [Content/Items/Consumables/ImpatiencePotion.cs](/Content/Items/Consumables/ImpatiencePotion.cs) | C# | 47 | 1 | 5 | 53 |
| [Content/Items/Consumables/MightyVoltaicScrap.cs](/Content/Items/Consumables/MightyVoltaicScrap.cs) | C# | 42 | 0 | 5 | 47 |
| [Content/Items/Consumables/OpticVoltaicScrap.cs](/Content/Items/Consumables/OpticVoltaicScrap.cs) | C# | 42 | 0 | 5 | 47 |
| [Content/Items/Consumables/StaminaPotion.cs](/Content/Items/Consumables/StaminaPotion.cs) | C# | 46 | 1 | 5 | 52 |
| [Content/Items/Consumables/StellerVoltaicFragment.cs](/Content/Items/Consumables/StellerVoltaicFragment.cs) | C# | 41 | 0 | 5 | 46 |
| [Content/Items/Consumables/VoltaicNugget.cs](/Content/Items/Consumables/VoltaicNugget.cs) | C# | 42 | 0 | 5 | 47 |
| [Content/Items/DartFrogExtract.cs](/Content/Items/DartFrogExtract.cs) | C# | 19 | 0 | 4 | 23 |
| [Content/Items/DepleatedBloontonium.cs](/Content/Items/DepleatedBloontonium.cs) | C# | 19 | 0 | 4 | 23 |
| [Content/Items/ExoticEscargot.cs](/Content/Items/ExoticEscargot.cs) | C# | 27 | 0 | 5 | 32 |
| [Content/Items/JellyfishTentacle.cs](/Content/Items/JellyfishTentacle.cs) | C# | 19 | 0 | 4 | 23 |
| [Content/Items/OrangeCharge.cs](/Content/Items/OrangeCharge.cs) | C# | 27 | 0 | 3 | 30 |
| [Content/Items/Placeable/AncientDebris.cs](/Content/Items/Placeable/AncientDebris.cs) | C# | 20 | 0 | 3 | 23 |
| [Content/Items/Placeable/AncientTech.cs](/Content/Items/Placeable/AncientTech.cs) | C# | 20 | 0 | 3 | 23 |
| [Content/Items/Placeable/DartAssemblyStation.cs](/Content/Items/Placeable/DartAssemblyStation.cs) | C# | 28 | 0 | 4 | 32 |
| [Content/Items/Placeable/ElectrudiumBar.cs](/Content/Items/Placeable/ElectrudiumBar.cs) | C# | 29 | 0 | 5 | 34 |
| [Content/Items/Placeable/ElectrudiumOre.cs](/Content/Items/Placeable/ElectrudiumOre.cs) | C# | 21 | 2 | 4 | 27 |
| [Content/Items/Placeable/UnstableChaosShard.cs](/Content/Items/Placeable/UnstableChaosShard.cs) | C# | 23 | 0 | 3 | 26 |
| [Content/Items/RadioactiveDebris.cs](/Content/Items/RadioactiveDebris.cs) | C# | 24 | 0 | 5 | 29 |
| [Content/Items/Rubber.cs](/Content/Items/Rubber.cs) | C# | 26 | 0 | 5 | 31 |
| [Content/Items/SealedTinCan.cs](/Content/Items/SealedTinCan.cs) | C# | 72 | 0 | 4 | 76 |
| [Content/Items/VoodooBunny.cs](/Content/Items/VoodooBunny.cs) | C# | 43 | 0 | 6 | 49 |
| [Content/Items/Weapons/Airgun.cs](/Content/Items/Weapons/Airgun.cs) | C# | 41 | 0 | 9 | 50 |
| [Content/Items/Weapons/Bellows.cs](/Content/Items/Weapons/Bellows.cs) | C# | 43 | 0 | 9 | 52 |
| [Content/Items/Weapons/BloontoniumBlaster.cs](/Content/Items/Weapons/BloontoniumBlaster.cs) | C# | 45 | 0 | 11 | 56 |
| [Content/Items/Weapons/Blowers/BagpipeBlaster.cs](/Content/Items/Weapons/Blowers/BagpipeBlaster.cs) | C# | 48 | 0 | 8 | 56 |
| [Content/Items/Weapons/Blowers/Balloon.cs](/Content/Items/Weapons/Blowers/Balloon.cs) | C# | 47 | 0 | 10 | 57 |
| [Content/Items/Weapons/Blowers/Blowguns/AdamantiteBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/AdamantiteBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/BlowgunRevolver.cs](/Content/Items/Weapons/Blowers/Blowguns/BlowgunRevolver.cs) | C# | 36 | 0 | 8 | 44 |
| [Content/Items/Weapons/Blowers/Blowguns/ChlorophyteBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/ChlorophyteBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/CobaltBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/CobaltBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/HallowedBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/HallowedBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/HellfireBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/HellfireBlowgun.cs) | C# | 38 | 0 | 9 | 47 |
| [Content/Items/Weapons/Blowers/Blowguns/LunarBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/LunarBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/MythrilBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/MythrilBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/OrichalcumBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/OrichalcumBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/PalladiumBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/PalladiumBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Blowguns/PhantomBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/PhantomBlowgun.cs) | C# | 36 | 0 | 8 | 44 |
| [Content/Items/Weapons/Blowers/Blowguns/TitaniumBlowgun.cs](/Content/Items/Weapons/Blowers/Blowguns/TitaniumBlowgun.cs) | C# | 34 | 0 | 8 | 42 |
| [Content/Items/Weapons/Blowers/Tronbone.cs](/Content/Items/Weapons/Blowers/Tronbone.cs) | C# | 29 | 0 | 7 | 36 |
| [Content/Items/Weapons/Bola.cs](/Content/Items/Weapons/Bola.cs) | C# | 44 | 0 | 8 | 52 |
| [Content/Items/Weapons/BunnyGun.cs](/Content/Items/Weapons/BunnyGun.cs) | C# | 60 | 0 | 7 | 67 |
| [Content/Items/Weapons/CentrifugalGun.cs](/Content/Items/Weapons/CentrifugalGun.cs) | C# | 34 | 0 | 10 | 44 |
| [Content/Items/Weapons/ChargeWeapon.cs](/Content/Items/Weapons/ChargeWeapon.cs) | C# | 218 | 2 | 28 | 248 |
| [Content/Items/Weapons/ChargedWeapon.cs](/Content/Items/Weapons/ChargedWeapon.cs) | C# | 111 | 0 | 16 | 127 |
| [Content/Items/Weapons/CompoundBow.cs](/Content/Items/Weapons/CompoundBow.cs) | C# | 51 | 0 | 10 | 61 |
| [Content/Items/Weapons/ConsumingLens.cs](/Content/Items/Weapons/ConsumingLens.cs) | C# | 79 | 0 | 11 | 90 |
| [Content/Items/Weapons/Crossbows/CopperCrossbow.cs](/Content/Items/Weapons/Crossbows/CopperCrossbow.cs) | C# | 39 | 0 | 9 | 48 |
| [Content/Items/Weapons/Crossbows/CrimtaneCrossbow.cs](/Content/Items/Weapons/Crossbows/CrimtaneCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/Crossbows/DemoniteCrossbow.cs](/Content/Items/Weapons/Crossbows/DemoniteCrossbow.cs) | C# | 35 | 0 | 9 | 44 |
| [Content/Items/Weapons/Crossbows/GoldCrossbow.cs](/Content/Items/Weapons/Crossbows/GoldCrossbow.cs) | C# | 35 | 0 | 9 | 44 |
| [Content/Items/Weapons/Crossbows/HellfireCrossbow.cs](/Content/Items/Weapons/Crossbows/HellfireCrossbow.cs) | C# | 35 | 0 | 9 | 44 |
| [Content/Items/Weapons/Crossbows/IronCrossbow.cs](/Content/Items/Weapons/Crossbows/IronCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/Crossbows/LeadCrossbow.cs](/Content/Items/Weapons/Crossbows/LeadCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/Crossbows/PlatinumCrossbow.cs](/Content/Items/Weapons/Crossbows/PlatinumCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/Crossbows/SilverCrossbow.cs](/Content/Items/Weapons/Crossbows/SilverCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/Crossbows/TinCrossbow.cs](/Content/Items/Weapons/Crossbows/TinCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/Crossbows/TungstenCrossbow.cs](/Content/Items/Weapons/Crossbows/TungstenCrossbow.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/DartlingGun.cs](/Content/Items/Weapons/DartlingGun.cs) | C# | 37 | 0 | 10 | 47 |
| [Content/Items/Weapons/DragonsBreath.cs](/Content/Items/Weapons/DragonsBreath.cs) | C# | 40 | 0 | 7 | 47 |
| [Content/Items/Weapons/HandCannon.cs](/Content/Items/Weapons/HandCannon.cs) | C# | 39 | 0 | 7 | 46 |
| [Content/Items/Weapons/HydraRocketLauncher.cs](/Content/Items/Weapons/HydraRocketLauncher.cs) | C# | 45 | 0 | 11 | 56 |
| [Content/Items/Weapons/HydrantHoser.cs](/Content/Items/Weapons/HydrantHoser.cs) | C# | 37 | 0 | 7 | 44 |
| [Content/Items/Weapons/LaserDartlingGun.cs](/Content/Items/Weapons/LaserDartlingGun.cs) | C# | 52 | 0 | 12 | 64 |
| [Content/Items/Weapons/LongBow.cs](/Content/Items/Weapons/LongBow.cs) | C# | 41 | 0 | 10 | 51 |
| [Content/Items/Weapons/MegaMortar.cs](/Content/Items/Weapons/MegaMortar.cs) | C# | 39 | 0 | 7 | 46 |
| [Content/Items/Weapons/MolotovMortar.cs](/Content/Items/Weapons/MolotovMortar.cs) | C# | 29 | 0 | 8 | 37 |
| [Content/Items/Weapons/NectarNailGun.cs](/Content/Items/Weapons/NectarNailGun.cs) | C# | 30 | 0 | 6 | 36 |
| [Content/Items/Weapons/NikolasObliterator.cs](/Content/Items/Weapons/NikolasObliterator.cs) | C# | 39 | 0 | 7 | 46 |
| [Content/Items/Weapons/PotatoCannon.cs](/Content/Items/Weapons/PotatoCannon.cs) | C# | 48 | 0 | 7 | 55 |
| [Content/Items/Weapons/PremeCalamari.cs](/Content/Items/Weapons/PremeCalamari.cs) | C# | 57 | 0 | 11 | 68 |
| [Content/Items/Weapons/RailRailGun.cs](/Content/Items/Weapons/RailRailGun.cs) | C# | 38 | 0 | 7 | 45 |
| [Content/Items/Weapons/Railgun.cs](/Content/Items/Weapons/Railgun.cs) | C# | 29 | 0 | 6 | 35 |
| [Content/Items/Weapons/RayOfBloon.cs](/Content/Items/Weapons/RayOfBloon.cs) | C# | 62 | 0 | 13 | 75 |
| [Content/Items/Weapons/Refractinator.cs](/Content/Items/Weapons/Refractinator.cs) | C# | 37 | 0 | 7 | 44 |
| [Content/Items/Weapons/RocketBalloon.cs](/Content/Items/Weapons/RocketBalloon.cs) | C# | 40 | 0 | 7 | 47 |
| [Content/Items/Weapons/Rubberband.cs](/Content/Items/Weapons/Rubberband.cs) | C# | 51 | 0 | 8 | 59 |
| [Content/Items/Weapons/RubberbandGun.cs](/Content/Items/Weapons/RubberbandGun.cs) | C# | 42 | 0 | 10 | 52 |
| [Content/Items/Weapons/ScorchingScream.cs](/Content/Items/Weapons/ScorchingScream.cs) | C# | 50 | 0 | 8 | 58 |
| [Content/Items/Weapons/Slingshots/AntlerSlinger.cs](/Content/Items/Weapons/Slingshots/AntlerSlinger.cs) | C# | 29 | 0 | 7 | 36 |
| [Content/Items/Weapons/Slingshots/AshwoodSlingshot.cs](/Content/Items/Weapons/Slingshots/AshwoodSlingshot.cs) | C# | 39 | 0 | 10 | 49 |
| [Content/Items/Weapons/Slingshots/BorealWoodSlingshot.cs](/Content/Items/Weapons/Slingshots/BorealWoodSlingshot.cs) | C# | 39 | 0 | 10 | 49 |
| [Content/Items/Weapons/Slingshots/EbonwoodSlingshot.cs](/Content/Items/Weapons/Slingshots/EbonwoodSlingshot.cs) | C# | 39 | 0 | 9 | 48 |
| [Content/Items/Weapons/Slingshots/MultiShot.cs](/Content/Items/Weapons/Slingshots/MultiShot.cs) | C# | 35 | 0 | 9 | 44 |
| [Content/Items/Weapons/Slingshots/PalmWoodSlingshot.cs](/Content/Items/Weapons/Slingshots/PalmWoodSlingshot.cs) | C# | 39 | 0 | 10 | 49 |
| [Content/Items/Weapons/Slingshots/PearlwoodSlingshot.cs](/Content/Items/Weapons/Slingshots/PearlwoodSlingshot.cs) | C# | 39 | 0 | 10 | 49 |
| [Content/Items/Weapons/Slingshots/ReinforcedSlingshot.cs](/Content/Items/Weapons/Slingshots/ReinforcedSlingshot.cs) | C# | 39 | 0 | 10 | 49 |
| [Content/Items/Weapons/Slingshots/RichMahoganySlingshot.cs](/Content/Items/Weapons/Slingshots/RichMahoganySlingshot.cs) | C# | 39 | 0 | 10 | 49 |
| [Content/Items/Weapons/Slingshots/ShadewoodSlingshot.cs](/Content/Items/Weapons/Slingshots/ShadewoodSlingshot.cs) | C# | 36 | 0 | 9 | 45 |
| [Content/Items/Weapons/Slingshots/TripleShot.cs](/Content/Items/Weapons/Slingshots/TripleShot.cs) | C# | 30 | 0 | 8 | 38 |
| [Content/Items/Weapons/Slingshots/WoodSlingshot.cs](/Content/Items/Weapons/Slingshots/WoodSlingshot.cs) | C# | 38 | 0 | 10 | 48 |
| [Content/Items/Weapons/SnailGun.cs](/Content/Items/Weapons/SnailGun.cs) | C# | 37 | 0 | 7 | 44 |
| [Content/Items/Weapons/SpiderBow.cs](/Content/Items/Weapons/SpiderBow.cs) | C# | 37 | 0 | 7 | 44 |
| [Content/Items/Weapons/SuperSlimer.cs](/Content/Items/Weapons/SuperSlimer.cs) | C# | 38 | 0 | 7 | 45 |
| [Content/Items/Weapons/SuperSoaker.cs](/Content/Items/Weapons/SuperSoaker.cs) | C# | 54 | 0 | 10 | 64 |
| [Content/Items/Weapons/SupremeCalamari.cs](/Content/Items/Weapons/SupremeCalamari.cs) | C# | 37 | 0 | 8 | 45 |
| [Content/Items/Weapons/TeslaCoil.cs](/Content/Items/Weapons/TeslaCoil.cs) | C# | 56 | 0 | 7 | 63 |
| [Content/Items/YellowCharge.cs](/Content/Items/YellowCharge.cs) | C# | 27 | 0 | 3 | 30 |
| [Content/Prefixes/Absurd.cs](/Content/Prefixes/Absurd.cs) | C# | 41 | 1 | 10 | 52 |
| [Content/Prefixes/Anxius.cs](/Content/Prefixes/Anxius.cs) | C# | 39 | 1 | 9 | 49 |
| [Content/Prefixes/ChargedPrefix.cs](/Content/Prefixes/ChargedPrefix.cs) | C# | 31 | 7 | 8 | 46 |
| [Content/Prefixes/Depleated.cs](/Content/Prefixes/Depleated.cs) | C# | 38 | 1 | 3 | 42 |
| [Content/Prefixes/Ecstatic.cs](/Content/Prefixes/Ecstatic.cs) | C# | 39 | 1 | 3 | 43 |
| [Content/Prefixes/Exuberant.cs](/Content/Prefixes/Exuberant.cs) | C# | 42 | 1 | 3 | 46 |
| [Content/Prefixes/Negative.cs](/Content/Prefixes/Negative.cs) | C# | 39 | 1 | 3 | 43 |
| [Content/Prefixes/Neutral.cs](/Content/Prefixes/Neutral.cs) | C# | 39 | 1 | 3 | 43 |
| [Content/Prefixes/Static.cs](/Content/Prefixes/Static.cs) | C# | 39 | 1 | 3 | 43 |
| [Content/Prefixes/SuperChargedPrefix.cs](/Content/Prefixes/SuperChargedPrefix.cs) | C# | 39 | 7 | 8 | 54 |
| [Content/Projectiles/BalloonProjectile.cs](/Content/Projectiles/BalloonProjectile.cs) | C# | 37 | 0 | 7 | 44 |
| [Content/Projectiles/BellowsAirProjectile.cs](/Content/Projectiles/BellowsAirProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/BloontoniumDartProjectile.cs](/Content/Projectiles/BloontoniumDartProjectile.cs) | C# | 33 | 0 | 5 | 38 |
| [Content/Projectiles/BolaProjectile.cs](/Content/Projectiles/BolaProjectile.cs) | C# | 37 | 0 | 7 | 44 |
| [Content/Projectiles/BombBayProjectile.cs](/Content/Projectiles/BombBayProjectile.cs) | C# | 89 | 0 | 9 | 98 |
| [Content/Projectiles/CoconutProjectile.cs](/Content/Projectiles/CoconutProjectile.cs) | C# | 31 | 0 | 5 | 36 |
| [Content/Projectiles/ConsumingLensLaser.cs](/Content/Projectiles/ConsumingLensLaser.cs) | C# | 56 | 0 | 7 | 63 |
| [Content/Projectiles/CropDusterProjectile.cs](/Content/Projectiles/CropDusterProjectile.cs) | C# | 54 | 0 | 9 | 63 |
| [Content/Projectiles/CustomDartProjectile.cs](/Content/Projectiles/CustomDartProjectile.cs) | C# | 116 | 0 | 18 | 134 |
| [Content/Projectiles/DragonsBreathProjectile.cs](/Content/Projectiles/DragonsBreathProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/HandCannonBombProjectile.cs](/Content/Projectiles/HandCannonBombProjectile.cs) | C# | 53 | 0 | 7 | 60 |
| [Content/Projectiles/Holdouts/Blowers/BagpipeBlasterHoldout.cs](/Content/Projectiles/Holdouts/Blowers/BagpipeBlasterHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/BalloonHoldout.cs](/Content/Projectiles/Holdouts/Blowers/BalloonHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/AdamantiteBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/AdamantiteBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/BlowgunRevolverHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/BlowgunRevolverHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/ChlorophyteBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/ChlorophyteBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/CobaltBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/CobaltBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/HallowedBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/HallowedBlowgunHoldout.cs) | C# | 17 | 0 | 5 | 22 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/HellfireBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/HellfireBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/LunarBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/LunarBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/MythrilBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/MythrilBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/OrichalcumBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/OrichalcumBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/PalladiumBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/PalladiumBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/PhantomBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/PhantomBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/Blowguns/TitaniumBlowgunHoldout.cs](/Content/Projectiles/Holdouts/Blowers/Blowguns/TitaniumBlowgunHoldout.cs) | C# | 5 | 0 | 2 | 7 |
| [Content/Projectiles/Holdouts/Blowers/TonboneHoldout.cs](/Content/Projectiles/Holdouts/Blowers/TonboneHoldout.cs) | C# | 28 | 0 | 4 | 32 |
| [Content/Projectiles/Holdouts/ChargeWeaponHoldout.cs](/Content/Projectiles/Holdouts/ChargeWeaponHoldout.cs) | C# | 211 | 16 | 28 | 255 |
| [Content/Projectiles/Holdouts/Crossbows/CopperCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/CopperCrossbowHoldout.cs) | C# | 19 | 0 | 4 | 23 |
| [Content/Projectiles/Holdouts/Crossbows/CrimtaneCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/CrimtaneCrossbowHoldout.cs) | C# | 18 | 0 | 5 | 23 |
| [Content/Projectiles/Holdouts/Crossbows/DemoniteCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/DemoniteCrossbowHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/Holdouts/Crossbows/GoldCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/GoldCrossbowHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/Holdouts/Crossbows/HellfireCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/HellfireCrossbowHoldout.cs) | C# | 13 | 0 | 4 | 17 |
| [Content/Projectiles/Holdouts/Crossbows/IronCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/IronCrossbowHoldout.cs) | C# | 13 | 0 | 4 | 17 |
| [Content/Projectiles/Holdouts/Crossbows/LeadCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/LeadCrossbowHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/Holdouts/Crossbows/PlatinumCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/PlatinumCrossbowHoldout.cs) | C# | 9 | 0 | 4 | 13 |
| [Content/Projectiles/Holdouts/Crossbows/SilverCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/SilverCrossbowHoldout.cs) | C# | 16 | 0 | 5 | 21 |
| [Content/Projectiles/Holdouts/Crossbows/TinCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/TinCrossbowHoldout.cs) | C# | 13 | 0 | 4 | 17 |
| [Content/Projectiles/Holdouts/Crossbows/TungstenCrossbowHoldout.cs](/Content/Projectiles/Holdouts/Crossbows/TungstenCrossbowHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/Holdouts/Slingshots/AntlerSlingerHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/AntlerSlingerHoldout.cs) | C# | 36 | 0 | 3 | 39 |
| [Content/Projectiles/Holdouts/Slingshots/AshwoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/AshwoodSlingshotHoldout.cs) | C# | 14 | 0 | 3 | 17 |
| [Content/Projectiles/Holdouts/Slingshots/BorealWoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/BorealWoodSlingshotHoldout.cs) | C# | 14 | 0 | 2 | 16 |
| [Content/Projectiles/Holdouts/Slingshots/EbonwoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/EbonwoodSlingshotHoldout.cs) | C# | 18 | 0 | 5 | 23 |
| [Content/Projectiles/Holdouts/Slingshots/MultiShotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/MultiShotHoldout.cs) | C# | 21 | 0 | 4 | 25 |
| [Content/Projectiles/Holdouts/Slingshots/PalmWoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/PalmWoodSlingshotHoldout.cs) | C# | 19 | 0 | 4 | 23 |
| [Content/Projectiles/Holdouts/Slingshots/PearlwoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/PearlwoodSlingshotHoldout.cs) | C# | 14 | 0 | 4 | 18 |
| [Content/Projectiles/Holdouts/Slingshots/ReinforcedSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/ReinforcedSlingshotHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/Holdouts/Slingshots/RichMahoganySlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/RichMahoganySlingshotHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/Holdouts/Slingshots/ShadeWoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/ShadeWoodSlingshotHoldout.cs) | C# | 17 | 0 | 5 | 22 |
| [Content/Projectiles/Holdouts/Slingshots/TripleShotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/TripleShotHoldout.cs) | C# | 21 | 0 | 5 | 26 |
| [Content/Projectiles/Holdouts/Slingshots/WoodSlingshotHoldout.cs](/Content/Projectiles/Holdouts/Slingshots/WoodSlingshotHoldout.cs) | C# | 12 | 0 | 4 | 16 |
| [Content/Projectiles/HolyCrossProjectile.cs](/Content/Projectiles/HolyCrossProjectile.cs) | C# | 92 | 0 | 11 | 103 |
| [Content/Projectiles/HydrantHoserProjectile.cs](/Content/Projectiles/HydrantHoserProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/LaserProjectile.cs](/Content/Projectiles/LaserProjectile.cs) | C# | 108 | 0 | 20 | 128 |
| [Content/Projectiles/LightningProjectile.cs](/Content/Projectiles/LightningProjectile.cs) | C# | 129 | 6 | 16 | 151 |
| [Content/Projectiles/MegaMortarProjectile.cs](/Content/Projectiles/MegaMortarProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/MonkeyDartProjectile.cs](/Content/Projectiles/MonkeyDartProjectile.cs) | C# | 33 | 0 | 5 | 38 |
| [Content/Projectiles/NectarNailProjectile.cs](/Content/Projectiles/NectarNailProjectile.cs) | C# | 37 | 0 | 5 | 42 |
| [Content/Projectiles/NikolasObliteratorLaser.cs](/Content/Projectiles/NikolasObliteratorLaser.cs) | C# | 19 | 0 | 3 | 22 |
| [Content/Projectiles/PixieDust.cs](/Content/Projectiles/PixieDust.cs) | C# | 38 | 0 | 4 | 42 |
| [Content/Projectiles/PotatoProjectile.cs](/Content/Projectiles/PotatoProjectile.cs) | C# | 36 | 0 | 7 | 43 |
| [Content/Projectiles/PremeCalamariLaser.cs](/Content/Projectiles/PremeCalamariLaser.cs) | C# | 31 | 0 | 4 | 35 |
| [Content/Projectiles/RailRailGunProjectile.cs](/Content/Projectiles/RailRailGunProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/RailgunLaser.cs](/Content/Projectiles/RailgunLaser.cs) | C# | 19 | 0 | 3 | 22 |
| [Content/Projectiles/RayOfBloonLaser.cs](/Content/Projectiles/RayOfBloonLaser.cs) | C# | 56 | 0 | 7 | 63 |
| [Content/Projectiles/RefractinatorProjectile.cs](/Content/Projectiles/RefractinatorProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/RocketBalloonProjectile.cs](/Content/Projectiles/RocketBalloonProjectile.cs) | C# | 37 | 0 | 6 | 43 |
| [Content/Projectiles/RocketPodProjectile.cs](/Content/Projectiles/RocketPodProjectile.cs) | C# | 36 | 0 | 6 | 42 |
| [Content/Projectiles/RocketStormProjectile.cs](/Content/Projectiles/RocketStormProjectile.cs) | C# | 59 | 0 | 9 | 68 |
| [Content/Projectiles/Rocks/BouncyRockProjectile.cs](/Content/Projectiles/Rocks/BouncyRockProjectile.cs) | C# | 55 | 2 | 14 | 71 |
| [Content/Projectiles/Rocks/ExplodingRockProjectile.cs](/Content/Projectiles/Rocks/ExplodingRockProjectile.cs) | C# | 35 | 0 | 4 | 39 |
| [Content/Projectiles/Rocks/HotRockProjectile.cs](/Content/Projectiles/Rocks/HotRockProjectile.cs) | C# | 40 | 0 | 7 | 47 |
| [Content/Projectiles/Rocks/RockProjectile.cs](/Content/Projectiles/Rocks/RockProjectile.cs) | C# | 35 | 0 | 5 | 40 |
| [Content/Projectiles/Rocks/SinkerProjectile.cs](/Content/Projectiles/Rocks/SinkerProjectile.cs) | C# | 35 | 0 | 7 | 42 |
| [Content/Projectiles/Rocks/SpikyRockProjectile.cs](/Content/Projectiles/Rocks/SpikyRockProjectile.cs) | C# | 69 | 2 | 12 | 83 |
| [Content/Projectiles/Rocks/SplitterBrokenProjectile.cs](/Content/Projectiles/Rocks/SplitterBrokenProjectile.cs) | C# | 36 | 0 | 6 | 42 |
| [Content/Projectiles/Rocks/SplitterProjectile.cs](/Content/Projectiles/Rocks/SplitterProjectile.cs) | C# | 52 | 0 | 7 | 59 |
| [Content/Projectiles/RubberbandProjectile.cs](/Content/Projectiles/RubberbandProjectile.cs) | C# | 51 | 2 | 14 | 67 |
| [Content/Projectiles/SnailProjectile.cs](/Content/Projectiles/SnailProjectile.cs) | C# | 31 | 0 | 6 | 37 |
| [Content/Projectiles/SuperSlimerProjectile.cs](/Content/Projectiles/SuperSlimerProjectile.cs) | C# | 36 | 0 | 7 | 43 |
| [Content/Projectiles/SuperSoakerProjectile.cs](/Content/Projectiles/SuperSoakerProjectile.cs) | C# | 35 | 1 | 6 | 42 |
| [Content/Projectiles/SupremeCalamariProjectile.cs](/Content/Projectiles/SupremeCalamariProjectile.cs) | C# | 25 | 0 | 4 | 29 |
| [Content/Projectiles/TronboneSonicProjectile.cs](/Content/Projectiles/TronboneSonicProjectile.cs) | C# | 37 | 0 | 5 | 42 |
| [Content/Tiles/AncientDebris.cs](/Content/Tiles/AncientDebris.cs) | C# | 26 | 0 | 4 | 30 |
| [Content/Tiles/AncientTech.cs](/Content/Tiles/AncientTech.cs) | C# | 21 | 0 | 4 | 25 |
| [Content/Tiles/DartAssembleStationTileEntity.cs](/Content/Tiles/DartAssembleStationTileEntity.cs) | C# | 56 | 0 | 5 | 61 |
| [Content/Tiles/DartAssemblyStationTile.cs](/Content/Tiles/DartAssemblyStationTile.cs) | C# | 68 | 2 | 12 | 82 |
| [Content/Tiles/ElectrudiumBar.cs](/Content/Tiles/ElectrudiumBar.cs) | C# | 21 | 0 | 4 | 25 |
| [Content/Tiles/ElectrudiumOre.cs](/Content/Tiles/ElectrudiumOre.cs) | C# | 26 | 0 | 4 | 30 |
| [Content/Tiles/PotatoPlant.cs](/Content/Tiles/PotatoPlant.cs) | C# | 99 | 13 | 23 | 135 |
| [Content/Tiles/UnstableChaosShard.cs](/Content/Tiles/UnstableChaosShard.cs) | C# | 26 | 0 | 4 | 30 |
| [Content/UI/ChargeMeter/ChargeMeter.cs](/Content/UI/ChargeMeter/ChargeMeter.cs) | C# | 74 | 3 | 21 | 98 |
| [Content/UI/DartAssemblyStation/DartAssemblyState.cs](/Content/UI/DartAssemblyStation/DartAssemblyState.cs) | C# | 140 | 0 | 13 | 153 |
| [Content/UI/VanillaItemSlotWrapper.cs](/Content/UI/VanillaItemSlotWrapper.cs) | C# | 38 | 2 | 6 | 46 |
| [Properties/launchSettings.json](/Properties/launchSettings.json) | JSON | 16 | 0 | 0 | 16 |
| [README.md](/README.md) | Markdown | 2 | 0 | 1 | 3 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Adrenaline.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CAdrenaline.cs) | C# | -16 | 0 | -2 | -18 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Bound.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CBound.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Charge.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CCharge.cs) | C# | -13 | 0 | -1 | -14 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Cursed.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CCursed.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Dabilitated.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CDabilitated.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\GodKiller.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CGodKiller.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Impatience.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CImpatience.cs) | C# | -13 | 0 | -1 | -14 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\LeadPoisoning.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CLeadPoisoning.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\LightHeaded.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CLightHeaded.cs) | C# | -16 | 0 | -2 | -18 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Plague.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CPlague.cs) | C# | -15 | 0 | -2 | -17 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\RadiationSickness.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CRadiationSickness.cs) | C# | -21 | 0 | -3 | -24 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\RocketStormCooldown.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CRocketStormCooldown.cs) | C# | -16 | 0 | -2 | -18 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Stamina.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CStamina.cs) | C# | -13 | 0 | -1 | -14 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Stunned.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CStunned.cs) | C# | -18 | 0 | -2 | -20 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\SuperSlimed.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CSuperSlimed.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Buffs\Tetnus.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CBuffs%5CTetnus.cs) | C# | -17 | 0 | -2 | -19 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\DamageClasses\ChargerDamageClass.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CDamageClasses%5CChargerDamageClass.cs) | C# | -14 | 0 | -4 | -18 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Dusts\ConsumingDust.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CDusts%5CConsumingDust.cs) | C# | -24 | 0 | -5 | -29 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\AAABattery.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CAAABattery.cs) | C# | -44 | 0 | -4 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\BreathingAid.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CBreathingAid.cs) | C# | -46 | 0 | -3 | -49 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Capacitor.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CCapacitor.cs) | C# | -37 | 0 | -3 | -40 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\CarBattery.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CCarBattery.cs) | C# | -44 | 0 | -4 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\ChargeRepository.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CChargeRepository.cs) | C# | -44 | 0 | -4 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Charger.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CCharger.cs) | C# | -41 | 0 | -3 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\ChargerEmblem.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CChargerEmblem.cs) | C# | -43 | 0 | -4 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Diaphragm.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CDiaphragm.cs) | C# | -42 | 0 | -4 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Exhaler.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CExhaler.cs) | C# | -43 | 0 | -3 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\ExtensionCord.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CExtensionCord.cs) | C# | -43 | 0 | -3 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Generator.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CGenerator.cs) | C# | -48 | 0 | -4 | -52 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\GripTape.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CGripTape.cs) | C# | -41 | 0 | -4 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Haler.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CHaler.cs) | C# | -42 | 0 | -3 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\HydrogenGas.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CHydrogenGas.cs) | C# | -37 | 0 | -3 | -40 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Inhaler.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CInhaler.cs) | C# | -39 | 0 | -3 | -42 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\IronLung.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CIronLung.cs) | C# | -44 | 0 | -4 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\LeatherGlove.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CLeatherGlove.cs) | C# | -37 | 0 | -3 | -40 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\LightningRod.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CLightningRod.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\OverCritter.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5COverCritter.cs) | C# | -38 | 0 | -3 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Overcharger.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5COvercharger.cs) | C# | -44 | 0 | -4 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\PowerBank.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CPowerBank.cs) | C# | -46 | 0 | -5 | -51 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\RedDot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CRedDot.cs) | C# | -44 | 0 | -3 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\Respirator.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CRespirator.cs) | C# | -41 | 0 | -3 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\SecretStimulants.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CSecretStimulants.cs) | C# | -42 | 0 | -3 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\ShootingGlove.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CShootingGlove.cs) | C# | -42 | 0 | -3 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\TrackingSpecs.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CTrackingSpecs.cs) | C# | -42 | 0 | -3 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Acessories\UltimateChargingGear.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAcessories%5CUltimateChargingGear.cs) | C# | -47 | 0 | -3 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\BloontoniumDart.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CBloontoniumDart.cs) | C# | -28 | 0 | -5 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\BottledSlime.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CBottledSlime.cs) | C# | -35 | 0 | -6 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\CustomDart.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CCustomDart.cs) | C# | -139 | 0 | -29 | -168 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\DartComponent.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CDartComponent.cs) | C# | -33 | 0 | -6 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\Atomizer.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CAtomizer.cs) | C# | -28 | 0 | -3 | -31 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\CryoCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CCryoCannister.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\CursedCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CCursedCannister.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\DartCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CDartCannister.cs) | C# | -27 | 0 | -2 | -29 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\DartFrogDebilitator.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CDartFrogDebilitator.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\DeathFactor.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CDeathFactor.cs) | C# | -34 | 0 | -3 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\ExplosiveCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CExplosiveCannister.cs) | C# | -27 | 0 | -3 | -30 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\GodKillerCocktail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CGodKillerCocktail.cs) | C# | -75 | 0 | -4 | -79 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\IchorCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CIchorCannister.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\JellyfishCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CJellyfishCannister.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\LavaCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CLavaCannister.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\LiquidLeadCannister.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CLiquidLeadCannister.cs) | C# | -33 | 0 | -3 | -36 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Payloads\RadioactiveParsel.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CPayloads%5CRadioactiveParsel.cs) | C# | -52 | 0 | -4 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\BetsysBackwash.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CBetsysBackwash.cs) | C# | -32 | 0 | -3 | -35 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\BombingBay.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CBombingBay.cs) | C# | -37 | 0 | -4 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\CropDuster.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CCropDuster.cs) | C# | -33 | 0 | -4 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\EagleEye.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CEagleEye.cs) | C# | -58 | 0 | -7 | -65 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\FeatheredTail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CFeatheredTail.cs) | C# | -27 | 0 | -3 | -30 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\HolyLightTail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CHolyLightTail.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\MagesTail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CMagesTail.cs) | C# | -36 | 0 | -2 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\PixieDuster.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CPixieDuster.cs) | C# | -33 | 0 | -4 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\PrismaticTail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CPrismaticTail.cs) | C# | -58 | 0 | -5 | -63 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\RocketJets.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CRocketJets.cs) | C# | -47 | 0 | -5 | -52 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\TheCorruptor.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CTheCorruptor.cs) | C# | -45 | 0 | -5 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\ToxicTail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CToxicTail.cs) | C# | -32 | 0 | -2 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tails\UnholyTail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTails%5CUnholyTail.cs) | C# | -48 | 0 | -4 | -52 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\AdamantiteTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CAdamantiteTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\BoneTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CBoneTip.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\ChlorophyteTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CChlorophyteTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\HallowedTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CHallowedTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\HellstoneTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CHellstoneTip.cs) | C# | -34 | 0 | -4 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\HypodermicNeedle.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CHypodermicNeedle.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\LihzahrdTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CLihzahrdTip.cs) | C# | -33 | 0 | -4 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\LunarTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CLunarTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\MeteorTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CMeteorTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\ShroomiteTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CShroomiteTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\SpectreTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CSpectreTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\TitaniumTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CTitaniumTip.cs) | C# | -31 | 0 | -3 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Darts\Tips\UnicornTip.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CDarts%5CTips%5CUnicornTip.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\MiniCannonball.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CMiniCannonball.cs) | C# | -35 | 0 | -6 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\MonkeyDart.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CMonkeyDart.cs) | C# | -28 | 0 | -5 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\NectarNail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CNectarNail.cs) | C# | -36 | 0 | -6 | -42 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Potato.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CPotato.cs) | C# | -41 | 0 | -6 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\RocketPod.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CRocketPod.cs) | C# | -28 | 0 | -5 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Rocks\BouncyRock.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CRocks%5CBouncyRock.cs) | C# | -40 | 0 | -6 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Rocks\HotRock.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CRocks%5CHotRock.cs) | C# | -39 | 0 | -7 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Rocks\Rock.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CRocks%5CRock.cs) | C# | -35 | 0 | -6 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Rocks\Sinker.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CRocks%5CSinker.cs) | C# | -36 | 0 | -6 | -42 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\Rocks\Splitter.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CRocks%5CSplitter.cs) | C# | -35 | 0 | -6 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Ammo\SoulofBunnies.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CAmmo%5CSoulofBunnies.cs) | C# | -31 | 0 | -6 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\AdamantiteCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CAdamantiteCasque.cs) | C# | -47 | -2 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\AncientHallowedCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CAncientHallowedCasque.cs) | C# | -47 | -2 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ChaosArmor\ChaosHelmet.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CChaosArmor%5CChaosHelmet.cs) | C# | -46 | -2 | -7 | -55 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ChaosArmor\ChaosLeggings.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CChaosArmor%5CChaosLeggings.cs) | C# | -39 | -2 | -4 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ChaosArmor\ChaosPlate.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CChaosArmor%5CChaosPlate.cs) | C# | -41 | -2 | -5 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ChlorophyteCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CChlorophyteCasque.cs) | C# | -40 | -2 | -5 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\CobaltCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CCobaltCasque.cs) | C# | -47 | -2 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ElectrudiumArmor\ElectrudiumChainmail.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CElectrudiumArmor%5CElectrudiumChainmail.cs) | C# | -32 | -2 | -5 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ElectrudiumArmor\ElectrudiumGreaves.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CElectrudiumArmor%5CElectrudiumGreaves.cs) | C# | -32 | -2 | -4 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\ElectrudiumArmor\ElectrudiumHelmet.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CElectrudiumArmor%5CElectrudiumHelmet.cs) | C# | -45 | -2 | -6 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\FestiveArmor\FestiveBreastplate.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CFestiveArmor%5CFestiveBreastplate.cs) | C# | -37 | -2 | -5 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\FestiveArmor\FestiveHelmet.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CFestiveArmor%5CFestiveHelmet.cs) | C# | -49 | -2 | -6 | -57 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\FestiveArmor\FestiveLeggings.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CFestiveArmor%5CFestiveLeggings.cs) | C# | -37 | -2 | -6 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\HallowedCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CHallowedCasque.cs) | C# | -47 | -2 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\MechArmor\MAD.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CMechArmor%5CMAD.cs) | C# | -46 | -2 | -8 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\MechArmor\MechHelmet.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CMechArmor%5CMechHelmet.cs) | C# | -39 | -2 | -4 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\MechArmor\MechLeggings.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CMechArmor%5CMechLeggings.cs) | C# | -45 | -2 | -7 | -54 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\MechArmor\MechLung.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CMechArmor%5CMechLung.cs) | C# | -52 | -2 | -11 | -65 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\MythrilCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CMythrilCasque.cs) | C# | -47 | -2 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\OrichalcumCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5COrichalcumCasque.cs) | C# | -41 | -2 | -5 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\PalladiumCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CPalladiumCasque.cs) | C# | -41 | -2 | -5 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Armor\TitaniumCasque.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CArmor%5CTitaniumCasque.cs) | C# | -41 | -2 | -5 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\BakedPotato.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CBakedPotato.cs) | C# | -34 | 0 | -4 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\BasicCircuitry.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CBasicCircuitry.cs) | C# | -30 | 0 | -4 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\BlueCharge.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CBlueCharge.cs) | C# | -29 | 0 | -2 | -31 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\ChargedComponents.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CChargedComponents.cs) | C# | -30 | 0 | -4 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\ChristmasCheer.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CChristmasCheer.cs) | C# | -22 | 0 | -3 | -25 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\ConcentratedGelSolution.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConcentratedGelSolution.cs) | C# | -27 | 0 | -4 | -31 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\ChargePotion.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CChargePotion.cs) | C# | -46 | -1 | -4 | -51 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\CosmicVoltaicFragment.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CCosmicVoltaicFragment.cs) | C# | -39 | 0 | -4 | -43 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\FragmentedQuasar.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CFragmentedQuasar.cs) | C# | -27 | 0 | -2 | -29 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\FrightfulVoltaicScrap.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CFrightfulVoltaicScrap.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\ImpatiencePotion.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CImpatiencePotion.cs) | C# | -47 | -1 | -4 | -52 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\MightyVoltaicScrap.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CMightyVoltaicScrap.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\OpticVoltaicScrap.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5COpticVoltaicScrap.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\StaminaPotion.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CStaminaPotion.cs) | C# | -45 | -1 | -4 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\StellerVoltaicFragment.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CStellerVoltaicFragment.cs) | C# | -39 | 0 | -4 | -43 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Consumables\VoltaicNugget.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CConsumables%5CVoltaicNugget.cs) | C# | -39 | 0 | -4 | -43 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\DartFrogExtract.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CDartFrogExtract.cs) | C# | -21 | 0 | -3 | -24 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\ExoticEscargot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CExoticEscargot.cs) | C# | -28 | 0 | -4 | -32 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\JellyfishTentacle.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CJellyfishTentacle.cs) | C# | -21 | 0 | -3 | -24 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\OrangeCharge.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5COrangeCharge.cs) | C# | -29 | 0 | -2 | -31 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Placeable\AncientDebris.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CPlaceable%5CAncientDebris.cs) | C# | -20 | 0 | -2 | -22 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Placeable\AncientTech.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CPlaceable%5CAncientTech.cs) | C# | -20 | 0 | -2 | -22 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Placeable\DartAssemblyStation.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CPlaceable%5CDartAssemblyStation.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Placeable\ElectrudiumBar.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CPlaceable%5CElectrudiumBar.cs) | C# | -30 | 0 | -4 | -34 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Placeable\ElectrudiumOre.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CPlaceable%5CElectrudiumOre.cs) | C# | -21 | -2 | -3 | -26 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Placeable\UnstableChaosShard.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CPlaceable%5CUnstableChaosShard.cs) | C# | -23 | 0 | -2 | -25 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\RadioactiveDebris.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CRadioactiveDebris.cs) | C# | -25 | 0 | -4 | -29 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Rubber.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CRubber.cs) | C# | -27 | 0 | -4 | -31 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\SealedTinCan.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CSealedTinCan.cs) | C# | -73 | 0 | -3 | -76 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\VoodooBunny.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CVoodooBunny.cs) | C# | -41 | 0 | -5 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Airgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CAirgun.cs) | C# | -44 | 0 | -8 | -52 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Bellows.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBellows.cs) | C# | -45 | 0 | -8 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\BloontoniumBlaster.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBloontoniumBlaster.cs) | C# | -41 | 0 | -9 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\BagpipeBlaster.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBagpipeBlaster.cs) | C# | -49 | 0 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Balloon.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBalloon.cs) | C# | -50 | 0 | -9 | -59 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\AdamantiteBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CAdamantiteBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\BlowgunRevolver.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CBlowgunRevolver.cs) | C# | -42 | 0 | -7 | -49 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\ChlorophyteBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CChlorophyteBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\CobaltBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CCobaltBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\HallowedBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CHallowedBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\HellfireBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CHellfireBlowgun.cs) | C# | -52 | 0 | -9 | -61 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\MythrilBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CMythrilBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\OrichalcumBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5COrichalcumBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\PalladiumBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CPalladiumBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\PhantomBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CPhantomBlowgun.cs) | C# | -42 | 0 | -7 | -49 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Blowguns\TitaniumBlowgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CBlowguns%5CTitaniumBlowgun.cs) | C# | -40 | 0 | -7 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Blowers\Tronbone.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBlowers%5CTronbone.cs) | C# | -50 | 0 | -6 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Bola.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBola.cs) | C# | -46 | 0 | -7 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\BunnyGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CBunnyGun.cs) | C# | -59 | 0 | -6 | -65 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\CentrifugalGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCentrifugalGun.cs) | C# | -39 | 0 | -9 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\ChargeWeapon.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CChargeWeapon.cs) | C# | -194 | -2 | -27 | -223 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\CompoundBow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCompoundBow.cs) | C# | -53 | 0 | -9 | -62 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\ConsumingLens.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CConsumingLens.cs) | C# | -78 | 0 | -10 | -88 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\CopperCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CCopperCrossbow.cs) | C# | -53 | 0 | -8 | -61 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\CrimtaneCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CCrimtaneCrossbow.cs) | C# | -51 | 0 | -9 | -60 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\DemoniteCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CDemoniteCrossbow.cs) | C# | -45 | 0 | -8 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\GoldCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CGoldCrossbow.cs) | C# | -45 | 0 | -8 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\HellfireCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CHellfireCrossbow.cs) | C# | -46 | 0 | -7 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\IronCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CIronCrossbow.cs) | C# | -48 | 0 | -7 | -55 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\LeadCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CLeadCrossbow.cs) | C# | -46 | 0 | -8 | -54 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\PlatinumCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CPlatinumCrossbow.cs) | C# | -46 | 0 | -8 | -54 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\SilverCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CSilverCrossbow.cs) | C# | -49 | 0 | -9 | -58 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\TinCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CTinCrossbow.cs) | C# | -48 | 0 | -8 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Crossbows\TungstenCrossbow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CCrossbows%5CTungstenCrossbow.cs) | C# | -46 | 0 | -8 | -54 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\DartlingGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CDartlingGun.cs) | C# | -41 | 0 | -9 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\DragonsBreath.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CDragonsBreath.cs) | C# | -42 | 0 | -6 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\HandCannon.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CHandCannon.cs) | C# | -42 | 0 | -6 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\HydraRocketLauncher.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CHydraRocketLauncher.cs) | C# | -41 | 0 | -9 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\LaserDartlingGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CLaserDartlingGun.cs) | C# | -48 | 0 | -10 | -58 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\LongBow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CLongBow.cs) | C# | -44 | 0 | -9 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\MegaMortar.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CMegaMortar.cs) | C# | -40 | 0 | -6 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\MolotovMortar.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CMolotovMortar.cs) | C# | -34 | 0 | -7 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\NectarNailGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CNectarNailGun.cs) | C# | -34 | 0 | -5 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\NikolasObliterator.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CNikolasObliterator.cs) | C# | -40 | 0 | -6 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\PotatoCannon.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CPotatoCannon.cs) | C# | -50 | 0 | -6 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\PremeCalamari.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CPremeCalamari.cs) | C# | -57 | 0 | -10 | -67 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\RailRailGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CRailRailGun.cs) | C# | -49 | 0 | -6 | -55 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Railgun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CRailgun.cs) | C# | -30 | 0 | -5 | -35 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\RayOfBloon.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CRayOfBloon.cs) | C# | -55 | 0 | -11 | -66 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\RocketBalloon.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CRocketBalloon.cs) | C# | -41 | 0 | -6 | -47 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Rubberband.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CRubberband.cs) | C# | -53 | 0 | -7 | -60 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\RubberbandGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CRubberbandGun.cs) | C# | -43 | 0 | -9 | -52 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\ScorchingScream.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CScorchingScream.cs) | C# | -51 | 0 | -7 | -58 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\AntlerSlinger.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CAntlerSlinger.cs) | C# | -58 | 0 | -7 | -65 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\AshwoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CAshwoodSlingshot.cs) | C# | -52 | 0 | -8 | -60 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\BorealWoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CBorealWoodSlingshot.cs) | C# | -51 | 0 | -8 | -59 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\EbonwoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CEbonwoodSlingshot.cs) | C# | -52 | 0 | -9 | -61 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\MultiShot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CMultiShot.cs) | C# | -52 | 0 | -8 | -60 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\PalmWoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CPalmWoodSlingshot.cs) | C# | -55 | 0 | -8 | -63 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\PearlwoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CPearlwoodSlingshot.cs) | C# | -51 | 0 | -8 | -59 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\ReinforcedSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CReinforcedSlingshot.cs) | C# | -49 | 0 | -8 | -57 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\RichMahoganySlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CRichMahoganySlingshot.cs) | C# | -51 | 0 | -8 | -59 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\ShadewoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CShadewoodSlingshot.cs) | C# | -52 | 0 | -9 | -61 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\TripleShot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CTripleShot.cs) | C# | -46 | 0 | -7 | -53 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\Slingshots\WoodSlingshot.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSlingshots%5CWoodSlingshot.cs) | C# | -49 | 0 | -7 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\SnailGun.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSnailGun.cs) | C# | -38 | 0 | -6 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\SpiderBow.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSpiderBow.cs) | C# | -39 | 0 | -6 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\SuperSlimer.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSuperSlimer.cs) | C# | -43 | 0 | -6 | -49 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\SuperSoaker.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSuperSoaker.cs) | C# | -53 | 0 | -9 | -62 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\SupremeCalamari.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CSupremeCalamari.cs) | C# | -43 | 0 | -7 | -50 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\Weapons\TeslaCoil.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CWeapons%5CTeslaCoil.cs) | C# | -58 | 0 | -6 | -64 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Items\YellowCharge.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CItems%5CYellowCharge.cs) | C# | -29 | 0 | -2 | -31 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Absurd.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CAbsurd.cs) | C# | -38 | -1 | -1 | -40 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Anxius.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CAnxius.cs) | C# | -36 | -1 | -2 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\ChargedPrefix.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CChargedPrefix.cs) | C# | -29 | -7 | -1 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Depleated.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CDepleated.cs) | C# | -35 | -1 | -2 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Ecstatic.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CEcstatic.cs) | C# | -36 | -1 | -2 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Exuberant.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CExuberant.cs) | C# | -39 | -1 | -2 | -42 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Negative.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CNegative.cs) | C# | -36 | -1 | -2 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Neutral.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CNeutral.cs) | C# | -36 | -1 | -2 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\Static.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CStatic.cs) | C# | -36 | -1 | -2 | -39 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Prefixes\SuperChargedPrefix.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CPrefixes%5CSuperChargedPrefix.cs) | C# | -29 | -7 | -1 | -37 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\BalloonProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CBalloonProjectile.cs) | C# | -37 | 0 | -6 | -43 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\BellowsAirProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CBellowsAirProjectile.cs) | C# | -36 | 0 | -5 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\BloontoniumDartProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CBloontoniumDartProjectile.cs) | C# | -39 | 0 | -4 | -43 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\BolaProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CBolaProjectile.cs) | C# | -40 | 0 | -6 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\BombBayProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CBombBayProjectile.cs) | C# | -86 | 0 | -8 | -94 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\CoconutProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CCoconutProjectile.cs) | C# | -36 | 0 | -4 | -40 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\ConsumingLensLaser.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CConsumingLensLaser.cs) | C# | -57 | 0 | -6 | -63 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\CropDusterProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CCropDusterProjectile.cs) | C# | -55 | 0 | -8 | -63 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\CustomDartProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CCustomDartProjectile.cs) | C# | -93 | 0 | -18 | -111 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\DragonsBreathProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CDragonsBreathProjectile.cs) | C# | -33 | 0 | -5 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\HandCannonBombProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CHandCannonBombProjectile.cs) | C# | -50 | 0 | -6 | -56 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\HolyCrossProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CHolyCrossProjectile.cs) | C# | -88 | 0 | -10 | -98 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\LaserProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CLaserProjectile.cs) | C# | -103 | 0 | -19 | -122 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\LightningProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CLightningProjectile.cs) | C# | -121 | -6 | -15 | -142 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\MonkeyDartProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CMonkeyDartProjectile.cs) | C# | -39 | 0 | -4 | -43 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\NectarNailProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CNectarNailProjectile.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\PixieDust.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CPixieDust.cs) | C# | -43 | 0 | -3 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\PotatoProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CPotatoProjectile.cs) | C# | -39 | 0 | -6 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\PremeCalamariLaser.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CPremeCalamariLaser.cs) | C# | -33 | 0 | -3 | -36 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\RayOfBloonLaser.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRayOfBloonLaser.cs) | C# | -57 | 0 | -6 | -63 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\RocketBalloonProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocketBalloonProjectile.cs) | C# | -37 | 0 | -5 | -42 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\RocketPodProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocketPodProjectile.cs) | C# | -41 | 0 | -5 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\RocketStormProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocketStormProjectile.cs) | C# | -54 | 0 | -8 | -62 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\BouncyRockProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CBouncyRockProjectile.cs) | C# | -55 | -2 | -13 | -70 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\ExplodingRockProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CExplodingRockProjectile.cs) | C# | -35 | 0 | -3 | -38 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\HotRockProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CHotRockProjectile.cs) | C# | -42 | 0 | -6 | -48 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\RockProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CRockProjectile.cs) | C# | -38 | 0 | -4 | -42 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\SinkerProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CSinkerProjectile.cs) | C# | -39 | 0 | -6 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\SpikyRockProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CSpikyRockProjectile.cs) | C# | -69 | -2 | -11 | -82 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\SplitterBrokenProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CSplitterBrokenProjectile.cs) | C# | -39 | 0 | -5 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\Rocks\SplitterProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRocks%5CSplitterProjectile.cs) | C# | -54 | 0 | -6 | -60 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\RubberbandProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CRubberbandProjectile.cs) | C# | -52 | -2 | -13 | -67 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\SnailProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CSnailProjectile.cs) | C# | -36 | 0 | -5 | -41 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\SuperSlimerProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CSuperSlimerProjectile.cs) | C# | -40 | 0 | -6 | -46 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\SuperSoakerProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CSuperSoakerProjectile.cs) | C# | -39 | -1 | -5 | -45 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\SupremeCalamariProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CSupremeCalamariProjectile.cs) | C# | -27 | 0 | -3 | -30 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Projectiles\TronboneSonicProjectile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CProjectiles%5CTronboneSonicProjectile.cs) | C# | -40 | 0 | -4 | -44 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\AncientDebris.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CAncientDebris.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\AncientTech.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CAncientTech.cs) | C# | -23 | 0 | -3 | -26 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\DartAssembleStationTileEntity.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CDartAssembleStationTileEntity.cs) | C# | -49 | 0 | -5 | -54 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\DartAssemblyStationTile.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CDartAssemblyStationTile.cs) | C# | -68 | -2 | -11 | -81 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\ElectrudiumBar.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CElectrudiumBar.cs) | C# | -23 | 0 | -3 | -26 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\ElectrudiumOre.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CElectrudiumOre.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\PotatoPlant.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CPotatoPlant.cs) | C# | -95 | -13 | -22 | -130 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\Tiles\UnstableChaosShard.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CTiles%5CUnstableChaosShard.cs) | C# | -30 | 0 | -3 | -33 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\UI\ChargeMeter\ChargeMeter.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CUI%5CChargeMeter%5CChargeMeter.cs) | C# | -72 | -3 | -20 | -95 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\UI\DartAssemblyStation\DartAssemblyState.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CUI%5CDartAssemblyStation%5CDartAssemblyState.cs) | C# | -129 | 0 | -12 | -141 |
| [c:\Users\Karl\Documents\My Games\Terraria\tModLoader\ModSources\ChargerClass\Content\UI\VanillaItemSlotWrapper.cs](/c:%5CUsers%5CKarl%5CDocuments%5CMy%20Games%5CTerraria%5CtModLoader%5CModSources%5CChargerClass%5CContent%5CUI%5CVanillaItemSlotWrapper.cs) | C# | -38 | -2 | -5 | -45 |

[Summary](results.md) / [Details](details.md) / [Diff Summary](diff.md) / Diff Details