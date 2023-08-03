using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class PalmWoodSlingshot : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Palm Wood Slingshot");
			Tooltip.SetDefault("3% chance to shoot a coconut");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 20);

            Item.damage = 8;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 6f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

        public override void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo){
            if(ChargerClassModSystem.Random.NextDouble() <= 0.03f * chargeLevels){
                type = ModContent.ProjectileType<CoconutProjectile>();
                veloctiy *= 0.6f;
                damage = (int)((Item.damage + 20) * modifier);
                knockback = (Item.knockBack + 8f) * modifier;
            }
        }
        
		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}
        
		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PalmWood, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}