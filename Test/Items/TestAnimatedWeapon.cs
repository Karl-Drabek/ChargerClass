/*using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Test.Items
{
	public class TestAnimatedWeapon : ModItem
	{

		public override void SetDefaults()
		{
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.width = 20;
			Item.height = 12;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;
			Item.autoReuse = true;
			
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.sellPrice(0, 10);

			Item.damage = 8;
            Item.crit = 6;
            Item.knockBack = 3f;

			Item.shootSpeed = 0f;
			Item.shoot = ModContent.ProjectileType<Projectiles.CentrifeugalGunChamber>();
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.channel = false;
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}*/