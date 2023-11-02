using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons;

public class SuperSoaker : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }

	public override void SafeSetDefaults()
	{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            chargeAmount = 90;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 90);
            Item.useTime = 26;
            ticsPerShot = 3;

            Item.damage = 5;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.WaterGun;
            Item.shootSpeed = 8f;
            Item.useAmmo = ItemID.BottledWater;
	}

            public override void ModifyOtherStats(Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2) {
                  if(player.ZoneDesert) ai0 = 1f;
                  else if(player.ZoneSnow) ai0 = 2f;
                  return;
            }

            public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
                  if(modPlayer.Player.ZoneDesert || modPlayer.Player.ZoneSnow) proj.timeLeft /= 4;
                  proj.friendly = true;
            }

            public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 200);
            recipe.AddIngredient(ItemID.WaterGun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}