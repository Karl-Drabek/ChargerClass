using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;

public class SuperSlimer : ChargeWeapon
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

            chargeAmount = 110;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 31, 0);
            Item.useTime = 30;
            ticsPerShot = 3;

            Item.damage = 6;
            Item.crit = 0;
            Item.knockBack = 0f;

            Item.shoot = ModContent.ProjectileType<Projectiles.SuperSlimerProjectile>();
            Item.shootSpeed = 8f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.BottledSlime>();
	}

            public override void AddRecipes()
	{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.SuperSoaker>(), 1);
            recipe.AddIngredient(ItemID.SlimeGun, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
	}
}