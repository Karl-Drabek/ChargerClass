using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Weapons.Blowers.Blowguns
{
	public class BlowgunRevolver : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 82;
            Item.height = 20;
            Item.scale = 1f;
            Item.rare = ItemRarityID.LightRed;

            chargeAmount = 400;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.useTime = 26;

            Item.damage = 286;
            Item.crit = 6;
            Item.knockBack = 0f;

            blowWeapon = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Dart;
		}

		public override void AddRecipes()
		{
                  Recipe recipe = CreateRecipe();
                  recipe.AddRecipeGroup(ChargerClassGeneralSystem.HardmodeOreBlowguns);
                  recipe.AddIngredient(ItemID.Revolver);
                  recipe.AddTile(TileID.AdamantiteForge);
                  recipe.Register();
		}
	}
}