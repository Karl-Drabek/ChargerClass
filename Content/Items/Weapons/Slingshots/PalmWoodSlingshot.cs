using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class PalmWoodSlingshot : ChargeWeapon
{
        public static readonly int CoconutChance = 5;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CoconutChance);
        public override void SetStaticDefaults() {
                Item.ResearchUnlockCount = 1;
        }
	public override void SafeSetDefaults()
	{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 250;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 24;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 20);

            Item.damage = 18;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 6f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback){
            if(Main.rand.NextBool(Utils.Clamp(CoconutChance * chargeLevel, 0, 100), 100)){
                type = ModContent.ProjectileType<CoconutProjectile>();
                velocity *= 0.75f;
                damage = (int)(2f * damage);
                knockback *= 2;
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