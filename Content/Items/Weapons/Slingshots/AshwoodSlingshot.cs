using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class AshwoodSlingshot : ChargeWeapon
{
        public static readonly int HellfireChance = 10;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(HellfireChance);
        public override void SetStaticDefaults() {
                Item.ResearchUnlockCount = 1;
        }
	public override void SafeSetDefaults()
	{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = ItemRarityID.White;

            chargeAmount = 300;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 20;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 20);

            Item.damage = 30;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 6f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

        public override void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){
            if (Main.rand.NextBool(Utils.Clamp(HellfireChance * (chargeLevel + 1), 0, 100), 100)) chargerProj.Hellfire = true;
        }

	public override Vector2? HoldoutOffset() {
		return new Vector2(0f, 0f);
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
           recipe.AddIngredient(ItemID.AshWood, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
	}
}