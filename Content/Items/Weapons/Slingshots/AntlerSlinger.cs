using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class AntlerSlinger : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antler Slinger");
			Tooltip.SetDefault("Charges add a chance to shoot an icy rock. \n On death enemies explode with ice spikes");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 2, 0, 0);;

            chargeAmount = 550;
            Item.damage = 25;
            Item.crit = 3;
            Item.knockBack = 3f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}
	}
}