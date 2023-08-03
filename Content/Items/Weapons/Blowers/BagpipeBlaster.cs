using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons.Blowers
{
	public class BagpipeBlaster : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bagpipe Blaster");
			Tooltip.SetDefault("Shoots a barrage of darts. Number depends on the charge.");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 150;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 20, 55);

            Item.damage = 14;
            Item.crit = 0;
            Item.knockBack = 1f;

            blowWeapon = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Leather, 5);
            recipe.AddIngredient(ItemID.BreathingReed, 1);
            recipe.AddIngredient(ItemID.Blowgun, 1);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Blowers.Balloon>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}