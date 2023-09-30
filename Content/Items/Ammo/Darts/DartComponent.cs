using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using Terraria.Localization;

namespace ChargerClass.Content.Items.Ammo.Darts
{
	public abstract class DartComponent : ModItem
	{
        public int Pen, DartSheetPlacement;

        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 0;
        }

        public override void SetDefaults() {
            Pen = 0;
            SafeSetDefaults();
            Item.DamageType = ChargerDamageClass.Instance;
            Item.maxStack = 999;
        }

        public virtual void SafeSetDefaults() {}
    }
}