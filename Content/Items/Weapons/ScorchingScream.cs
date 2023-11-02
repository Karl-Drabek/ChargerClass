using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons;

public class ScorchingScream : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
	public override void SafeSetDefaults()
	{
            Item.width = 58;
            Item.height = 22;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Orange;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 1, 25);
            Item.useTime = 28;

            Item.damage = 22;
            Item.crit = 0;
            Item.knockBack = 3f;
            ticsPerShot = 4;

            Item.shoot = ProjectileID.FlamesTrap;
            Item.shootSpeed = 6f;
	}

            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
                  velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
            }
	public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  proj.hostile = false;
                  proj.friendly = true;
                  proj.scale = 0.25f;
            }

	public override void AddRecipes()
	{
                  Recipe recipe = CreateRecipe();
                  recipe.AddIngredient(ItemID.HellstoneBar, 14);
                  recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Bellows>(), 1);
                  recipe.AddTile(TileID.Anvils);
                  recipe.Register();
	}
}