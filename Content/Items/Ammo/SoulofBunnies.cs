using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Ammo;

public class SoulofBunnies : ModItem
{
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.ItemIconPulse[Item.type] = true;
		ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults() {
            Item.width = 34;
            Item.height = 24;

            Item.rare = ItemRarityID.Master;

            Item.maxStack = 1;
            Item.consumable = false;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 4f;

            Item.ammo = Item.type;
        }

	public override bool CanConsumeAmmo(Item ammo, Player player) => false;
    }