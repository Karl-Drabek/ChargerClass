using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.ModSystems;

namespace ChargerClass.Content.Items.Ammo;

public class RocketPod : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults() {
            Item.width = 14;
            Item.height = 22;

            Item.damage = 24;
            Item.DamageType = ChargerDamageClass.Instance;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice(0, 0, 4, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.shoot = ModContent.ProjectileType<RocketPodProjectile>();

            Item.ammo = Item.type;
        }

        public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ModContent.ItemType<BloontoniumDart>());
            recipe.AddRecipeGroup(ChargerClassGeneralSystem.Rockets);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
	}
    }