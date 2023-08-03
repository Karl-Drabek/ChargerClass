using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items
{
	public class Rubber : ModItem
	{
        public override void SetStaticDefaults() {
            Tooltip.SetDefault("Great for slinging!");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults() {
            Item.width = 10;
            Item.height = 9;

            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.RockProjectile>();

            Item.ammo = Item.type;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(ItemID.Gel, 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}