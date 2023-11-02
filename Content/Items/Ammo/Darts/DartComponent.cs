using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Items.Ammo.Darts;

public abstract class DartComponent : ModItem
{
        public int Pen, DartSheetPlacement, AIStyle;

        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 0;
        }

        public override void SetDefaults() {
            Pen = 0;
            AIStyle = 1;
            SafeSetDefaults();
            Item.DamageType = ChargerDamageClass.Instance;
            Item.maxStack = 999;
        }

        public virtual void SafeSetDefaults() {}

        public virtual void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone, float buffTimeMultiplier){}
        public virtual void AI(Projectile projectile,int payloadType){}
        public virtual void OnKill(Projectile projectile, int timeLeft){}
        public virtual void OnSpawn(Projectile projectile, IEntitySource source){}

        public virtual void ModifyHitNPC(Projectile projetile, NPC target, ref NPC.HitModifiers modifiers){}
}