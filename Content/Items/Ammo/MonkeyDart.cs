using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo;

public class MonkeyDart : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            Item.width = 19;
            Item.height = 7;

            Item.damage = 20;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1f;
            Item.value = Item.buyPrice(0, 0, 2, 0);
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<MonkeyDartProjectile>();

            Item.ammo = Item.type;
        }
    }