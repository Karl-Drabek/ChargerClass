using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Items.Ammo.Darts;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Projectiles;

public class CustomDartProjectile : ModProjectile
{
    public DartComponent Tail, Payload, Tip;
    private Texture2D texture => TextureAssets.Projectile[Type].Value;
    public override string Texture => "ChargerClass/Content/Items/Ammo/Darts/DartSheet";

    private static readonly int tailHeight = 10, payloadHeight = 14, tipHeight = 10, width = 10;
    
	public override void SetDefaults()
	{
        Projectile.width = width;
        Projectile.height = width;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = ChargerDamageClass.Instance;
        Projectile.penetrate = 1;
        Projectile.timeLeft = 180;
        Projectile.alpha = 0;
        Projectile.light = 0.0f;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 0;

        AIType = ProjectileID.WoodenArrowFriendly;
    }

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone){
        float buffTimeMultiplier = Tip.DartSheetPlacement == 0 ? 1.25f : 1f;
        if(Tail is not null) Tail.OnHitNPC(Projectile, target, hit, damageDone, buffTimeMultiplier);
        if(Payload is not null) Payload.OnHitNPC(Projectile, target, hit, damageDone, buffTimeMultiplier);
        if(Tip is not null) Tip.OnHitNPC(Projectile, target, hit, damageDone, buffTimeMultiplier);
    }

    public override void AI(){
        if(Tail is not null) Tail.AI(Projectile, Payload.Type);
        if(Payload is not null) Payload.AI(Projectile, Payload.Type);
        if(Tip is not null) Tip.AI(Projectile, Payload.Type);
    }

    public override void OnKill(int timeLeft){
        if(Tail is not null) Tail.OnKill(Projectile, timeLeft);
        if(Payload is not null) Payload.OnKill(Projectile, timeLeft);
        if(Tip is not null) Tip.OnKill(Projectile, timeLeft);
    }

	public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers){
        if(Tail is not null) Tail.ModifyHitNPC(Projectile, target, ref modifiers);
        if(Payload is not null) Payload.ModifyHitNPC(Projectile, target, ref modifiers);
        if(Tip is not null) Tip.ModifyHitNPC(Projectile, target, ref modifiers);
    }

	public override void OnSpawn(IEntitySource source){
        if(source is EntitySource_ItemUse_WithAmmo useAmmoSource && useAmmoSource.AmmoItemIdUsed == ModContent.ItemType<CustomDart>()){
            ChargeModPlayer modPlayer = useAmmoSource.Player.GetModPlayer<ChargeModPlayer>();
            Tail = (DartComponent)ItemLoader.GetItem(modPlayer.TailForCustomDart);
            Payload = (DartComponent)ItemLoader.GetItem(modPlayer.PayloadForCustomDart);
            Tip = (DartComponent)ItemLoader.GetItem(modPlayer.TipForCustomDart);
        }else if(Projectile.owner >= 0){
            ChargeModPlayer modPlayer = Main.player[Projectile.owner].GetModPlayer<ChargeModPlayer>();
            Tail = (DartComponent)ItemLoader.GetItem(modPlayer.TailForCustomDart);
            Payload = (DartComponent)ItemLoader.GetItem(modPlayer.PayloadForCustomDart);
            Tip = (DartComponent)ItemLoader.GetItem(modPlayer.TipForCustomDart);
        }

        if(Tip is not null) Projectile.penetrate = Tip.Pen;
        if(Tail is not null) Projectile.aiStyle = Tail.AIStyle;


        if(Tail is not null) Tail.OnSpawn(Projectile, source);
        if(Payload is not null) Payload.OnSpawn(Projectile, source);
        if(Tip is not null) Tip.OnSpawn(Projectile, source);
    }

    public override bool PreDraw (ref Color lightColor){
        var origin = new Vector2(Projectile.width, Projectile.height) / 2;
        Vector2 position = Projectile.Center - Main.screenPosition;
        Vector2 normVel = Vector2.Normalize(Projectile.velocity);
        lightColor.A = (byte)(byte.MaxValue - Projectile.alpha);
        
        int id = Tip is null? 0 : Tip.DartSheetPlacement;
        var frame = new Rectangle(id * (width + 2), 0, width, tipHeight);
        Main.EntitySpriteDraw(texture, position, frame, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);

        position -= normVel * tipHeight * Projectile.scale;
        id = Tip is null? 0 : Payload.DartSheetPlacement;
        frame = new Rectangle(id * (width + 2),  tipHeight + 2, width, payloadHeight);
        Main.EntitySpriteDraw(texture, position, frame, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);

        position -= normVel * payloadHeight * Projectile.scale;
        id = Tip is null? 0 : Tail.DartSheetPlacement;
        frame = new Rectangle(id * (width + 2), payloadHeight + tipHeight + 4, width, tailHeight);
        Main.EntitySpriteDraw(texture, position, frame, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);

        return false;
    }
}