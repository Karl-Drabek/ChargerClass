using Terraria;
using Terraria.ID;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons;

public class LongBow : ChargeWeapon
{
            public static readonly int CritChanceIncrease = 10;
            public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncrease);

            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
            
	public override void SafeSetDefaults()
	{
            Item.width = 16;
            Item.height = 58;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 450;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 30);

            Item.damage = 46;
            Item.crit = 4;
            Item.knockBack = 0f;
            Item.useTime = 32;

            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Arrow;
	}

            public override void SafeModifyWeaponCrit(Player player, ref float crit) {
                  crit += CritChanceIncrease * chargeLevel;
            }

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  chargerProj.PenOnCrit = true;
            }
}