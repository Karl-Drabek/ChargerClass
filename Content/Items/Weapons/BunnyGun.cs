using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.Items.Ammo;

namespace ChargerClass.Content.Items.Weapons;

public class BunnyGun : ChargeWeapon
{
            public override void SetStaticDefaults() {
                  Item.ResearchUnlockCount = 1;
                  ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
            }
            
	public override void SafeSetDefaults()
	{
            Item.width = 88;
            Item.height = 42;
            Item.scale = 1f;
            Item.rare = -12;

            chargeAmount = 100;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 10, 40, 0);
            Item.useTime = 12;
            
            ticsPerShot = 3;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 10f;
            Item.useAmmo = ModContent.ItemType<SoulofBunnies>();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
                  if (Main.netMode != NetmodeID.MultiplayerClient) {
                        NPC npc = NPC.NewNPCDirect(new EntitySource_Parent(player), position, RandomBunny());
                        npc.velocity = velocity;
                  }else {
                        NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: RandomBunny());
                  }
                  return false;
		int RandomBunny() => Main.rand.NextBool()? NonExplosiveBunny() : NPCID.ExplosiveBunny;
                  int NonExplosiveBunny() => Main.rand.NextBool()? SpecialBunny() : GoldBunnyCheck();
                  int GoldBunnyCheck() => Main.rand.NextBool(1, 20)? NPCID.GoldBunny : NPCID.Bunny;
                  int SpecialBunny() => Main.rand.Next(0, 4) switch{
                        0 => NPCID.BunnySlimed,
                        1 => NPCID.BunnyXmas,
                        2 => NPCID.PartyBunny,
                        _ => GemBunny()
                  };
                  int GemBunny() => Main.rand.Next(0, 7) switch{
                        0 => NPCID.GemBunnyAmethyst,
                        1 => NPCID.GemBunnyAmber,
                        2 => NPCID.GemBunnyDiamond,
                        3 => NPCID.GemBunnyEmerald,
                        4 => NPCID.GemBunnyRuby,
                        5 => NPCID.GemBunnySapphire,
                        _ => NPCID.GemBunnyTopaz
                  };
	}
}