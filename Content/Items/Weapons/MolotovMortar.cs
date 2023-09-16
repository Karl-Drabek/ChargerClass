using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Content.Items.Weapons
{
	public class MolotovMortar : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 58;
            Item.height = 20;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 160;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 2, 30);

            Item.damage = 8;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.useTime = 48;

            ticsPerShot = 10;

            Item.shoot = ProjectileID.MolotovCocktail;
            Item.shootSpeed = 5f;
            Item.useAmmo = ItemID.MolotovCocktail;
		}
	}
}