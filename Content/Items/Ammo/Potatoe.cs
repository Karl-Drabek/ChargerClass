using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Tiles;

namespace ChargerClass.Content.Items.Ammo
{
	public class Potatoe : ModItem
	{
        public override void SetStaticDefaults() {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<PotatoePlant>());
            Item.width = 10;
            Item.height = 9;

            Item.damage = 5;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 99);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.PotatoeProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }
    }
}