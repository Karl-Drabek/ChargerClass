using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles.Rocks;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class EbonwoodSlingshot : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ebonwood Slingshot");
			Tooltip.SetDefault("Chance to shoot exploding projectiles");
		}

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 350;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 20);

            Item.damage = 12;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 6f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

        public override void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo){
            if(ChargerClassModSystem.Random.NextDouble() <= 0.1f * chargeLevels){
                type = ModContent.ProjectileType<ExplodingRockProjectile>();
            }
        }

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ebonwood, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}