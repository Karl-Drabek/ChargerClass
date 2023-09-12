using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons
{
	public class RubberbandGun : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 180;
            Item.useTime = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 20);
            ticsPerShot = 8;
            Item.autoReuse = true;

            Item.damage = 3;
            Item.crit = 0;
            Item.knockBack = 0f;

            blowWeapon = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.RubberbandProjectile>();
            Item.shootSpeed = 4f;
            Item.useAmmo = ModContent.ItemType<Items.Weapons.Rubberband>();
		}

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  if(Main.rand.NextBool(3 * chargeLevel, 100)){
                        type = ModContent.ProjectileType<Projectiles.FlamingRubberbandProjectile>();
                        damage = (int)(1.5f * damage);
                  }
            }

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
		}
	}
}