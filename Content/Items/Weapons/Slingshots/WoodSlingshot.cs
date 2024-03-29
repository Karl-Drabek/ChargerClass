using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Slingshots;

public class WoodSlingshot : ChargeWeapon
{
        public static readonly int CritChanceIncrease = 5;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncrease);
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 1;
        }
	public override void SafeSetDefaults()
	{
            Item.width = 24;
            Item.height = 32;
            Item.scale = 1f;
            
            Item.rare = ItemRarityID.White;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 0, 20);

            Item.damage = 14;
            Item.crit = 0;
            Item.knockBack = 0f;
            Item.useTime = 22;
            chargeAmount = 250;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 6f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
	}

        public override void SafeModifyWeaponCrit(Player player, ref float crit){
            crit += chargeLevel * CritChanceIncrease;
        }

	public override Vector2? HoldoutOffset() {
		return new Vector2(0f, 0f);
	}

	public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Rubber>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
	}
}