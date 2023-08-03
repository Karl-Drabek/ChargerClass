using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class PearlwoodSlingshot : ChargeWeapon
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pearlwood Slingshot");
			Tooltip.SetDefault("15% chance to confuse enemy");
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

            Item.damage = 14;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 6f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

        public override void PostProjectileEffects(ChargerProjectile chargerProj, int chargeLevels){
            if (ChargerClassModSystem.Random.NextDouble() <= 0.15f * chargeLevels) chargerProj.Confused = true;
        }

		public override Vector2? HoldoutOffset() {
			return new Vector2(0f, 0f);
		}

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Pearlwood, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
		}
	}
}