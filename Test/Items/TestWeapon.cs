using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content;

namespace ChargerClass.Test.Items
{
	public class TestWeapon : Test
	{

		public override void SafeSetDefaults()
		{
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 2, 0, 0);;

            Item.damage = 25;
            Item.crit = 3;
            Item.knockBack = 3f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
		}
	}
}