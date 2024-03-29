using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons;

public class Rubberband : ChargeWeapon
{
            public static readonly int SnapChance = 1 ;
      public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SnapChance);
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 99;
            }
	public override void SafeSetDefaults()
	{
            Item.width = 36;
            Item.height = 22;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 300;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.useTime = 12;
            Item.value = Item.sellPrice(0, 0, 0, 1);

            Item.damage = 14;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.maxStack = 999;
            Item.consumable = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.RubberbandProjectile>();
            Item.shootSpeed = 6f;
            Item.ammo = Item.type;
	}

            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
                  if(Main.rand.NextBool(Utils.Clamp(chargeLevel * SnapChance, 0, 100), 100)){
                        player.Hurt(PlayerDeathReason.ByPlayerItem(player.whoAmI, Item), damage, player.direction);
                        return false;
                  }
                  return true;
            }

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
	}
}