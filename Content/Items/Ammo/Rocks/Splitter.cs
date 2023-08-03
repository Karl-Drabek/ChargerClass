using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Ammo.Rocks
{
	public class Splitter : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spltter");
            Tooltip.SetDefault("splits into two smaller rocks after a little while");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults() {
            Item.width = 8;
            Item.height = 8;

            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 8);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.SplitterProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = ModContent.ItemType<Rock>();
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}