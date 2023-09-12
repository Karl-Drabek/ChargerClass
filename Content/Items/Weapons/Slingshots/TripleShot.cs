using Microsoft.Xna.Framework;
using ChargerClass;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Common.Players;
using ChargerClass.Common.GlobalProjectiles;

namespace ChargerClass.Content.Items.Weapons.Slingshots
{
	public class TripleShot : ChargeWeapon
	{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
            }
		public override void SafeSetDefaults()
		{
            Item.width = 24;
            Item.height = 40;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Green;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.useTime = 25;

            chargeAmount = 450;
            Item.damage = 20;
            Item.crit = 0;
            Item.knockBack = 1f;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 8f;
            Item.useAmmo = ModContent.ItemType<Items.Ammo.Rocks.Rock>();
		}

            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
                  for(int i = 0; i < 3; i++){
                        Projectile proj = Projectile.NewProjectileDirect(source, position, velocity.RotatedBy(MathHelper.ToRadians(8 - 4 * i)), type, damage, knockback);
                        InternalPostProjectileEffects(proj, player.GetModPlayer<ChargeModPlayer>());
                  }
                  return false;
            }

            public override bool CanConsumeAmmo(Item item, Player player) => !Main.rand.NextBool(10 * chargeLevel, 100);

		public override Vector2? HoldoutOffset() => new Vector2(0f, 0f);
	}
}