using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Ammo
{
	public class Pellet : ModItem
	{
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Pellet");
			Tooltip.SetDefault("Used in an airgun");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults() {
            Item.width = 10;
            Item.height = 9;

            Item.damage = 4;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 5);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.PelletProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(8);
            recipe.AddIngredient(ItemID.IronBar, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}