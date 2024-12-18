using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Weapons.Tests;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class WoodSlingshotHoldout : ChargeWeaponHoldout{
  public override void SafeSetDefaults(){}
  public override void ModifyWeaponCrit(Player player, ref float crit){
    int chargeLevel = GetChargeLevel(player);
    crit += chargeLevel * WoodSlingshotTest.CritChanceIncrease;
  }
}