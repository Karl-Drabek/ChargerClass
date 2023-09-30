using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts.Tails
{
	public class MagesTail : DartComponent
	{
        public override void SafeSetDefaults() {
            Item.width = 10;
            Item.height = 10;
            DartSheetPlacement = 9;
            Item.value = Item.sellPrice(0, 0, 0, 8);
            Item.rare = ItemRarityID.Orange;
            
            Item.shootSpeed = 4f;
        }
    }
}