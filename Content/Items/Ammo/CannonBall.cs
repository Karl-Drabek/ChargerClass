using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo
{
	public class CannonBall : ModItem
	{
        public override void SetStaticDefaults() {

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults() {
            Item.width = 10;
            Item.height = 9;

            Item.damage = 5;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 99);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.CannonBallProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(10);
            recipe.AddIngredient(ItemID.StoneBlock, 999);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}