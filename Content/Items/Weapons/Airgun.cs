using Terraria;
using Terraria.ID;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons;

public class Airgun : ChargeWeapon
{
            public static readonly int CritChanceIncreases = 3;
	public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncreases);
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
            
	public override void SafeSetDefaults()
	{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 40);
            Item.useTime = 16;

            Item.damage = 35;
            Item.crit = 1;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
	}

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  chargerProj.CatchCritters = true;
            }

            public override void SafeModifyWeaponCrit(Player player, ref float crit){
                  crit += chargeLevel * CritChanceIncreases;
            }
}