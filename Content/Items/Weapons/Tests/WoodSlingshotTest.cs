using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles.Holdouts;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Weapons.Tests;

public class WoodSlingshotTest : ChargedWeapon
{
        
        public static readonly int CritChanceIncrease = 5;
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(CritChanceIncrease);
        public override void SafeSetDefaults()
        {
                Item.width = 24;
                Item.height = 32;
                Item.scale = 1f;
                Item.rare = ItemRarityID.White;

                chargeAmount = 250;

                Item.UseSound = SoundID.Item1;
                Item.value = Item.sellPrice(0, 0, 0, 20);
                Item.useTime = 22;

                Item.damage = 14;
                Item.crit = 0;
                Item.knockBack = 0f;
                
                Item.useAmmo = Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
                Item.shoot = ModContent.ProjectileType<WoodSlingshotHoldout>();
                Item.shootSpeed = 6f;
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