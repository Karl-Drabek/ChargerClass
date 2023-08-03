using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class TripleShot : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Triple Shot");
			Tooltip.SetDefault("Shoots three bullets. \n 10% chance not to consume ammo per charge");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 50, 0);

            chargeAmount = 450;
            Item.damage = 13;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 8f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

		public override void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo) {
            count = 3;
			if (ChargerClassModSystem.Random.NextDouble() <= 0.1f * chargeLevels) consumeAmmo = false;
        }

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}
	}
}