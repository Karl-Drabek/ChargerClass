using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Tiles;

namespace ChargerClass.Content.Items.Ammo;

public class Potato : ModItem
{
        public override void SetStaticDefaults() {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            Item.createTile = ModContent.TileType<PotatoPlant>();
            Item.placeStyle = 0;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.maxStack = Item.CommonMaxStack;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.width = 14;
            Item.height = 14;
            Item.noMelee = true;

            Item.damage = 5;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.consumable = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice(0, 0, 0, 99);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.PotatoProjectile>();
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }

        public override bool CanShoot(Player player) => false;
    }