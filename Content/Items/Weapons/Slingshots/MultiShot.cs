using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class MultiShot : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 60;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Blue;

            chargeAmount = 155;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 34;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 4, 50, 0);

            Item.damage = 24;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ModContent.ProjectileType<Projectiles.Rocks.RockProjectile>();
            Item.shootSpeed = 9f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
                  int count = chargeLevel + 1;
                  float spreadMult = 4; //degrees between projectiles in spread
                  float spread = count * spreadMult / 2; //start degrees for projectiles
                  for(int i = 0; i < count; i++){
                        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity.RotatedBy(MathHelper.ToRadians(spread - spreadMult * i)), type, damage, knockback);
                        CombinedPostProjectileEffects(proj, player.GetModPlayer<ChargeModPlayer>());
                  }
                  return false;
            }

		public override Vector2? HoldoutOffset() => new Vector2(0f, 0f);

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Slingshots.TripleShot>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}