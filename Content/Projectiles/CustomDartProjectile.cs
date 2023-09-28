using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.Extensions;
using ChargerClass.Content.Items.Ammo.Darts.Tips;
using ChargerClass.Content.Items.Ammo.Darts.Payloads;
using ChargerClass.Content.Items.Ammo.Darts.Tails;
using ChargerClass.Content.Items.Ammo.Darts;

namespace ChargerClass.Content.Projectiles;

public class CustomDartProjectile : ModProjectile
{
        public DartComponent Tail, Payload, Tip;
        private Texture2D texture;

        private static readonly int tailHeight = 10, payloadHeight = 14, tipHeight = 10, width = 10;
        
	public override void SetDefaults()
	{
            Projectile.width = 15;
            Projectile.height = 15;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
            texture = ModContent.Request<Texture2D>("ChargerClass/Content/Items/Ammo/Darts/CustomDart").Value;

            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override bool PreDraw (ref Color lightColor){
            var origin = new Vector2(width, tipHeight + payloadHeight + tailHeight) / 2;
            Vector2 position = Projectile.position - Main.screenPosition;
            Vector2 normVel = Projectile.velocity;
            normVel.Normalize();
            
            int id = Tip is null? 0 : Tip.Item.type - ModContent.ItemType<HypodermicNeedle>();
            var frame = new Rectangle(id * (width + 2), 0, width, tipHeight);
            Main.EntitySpriteDraw(texture, position, frame, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);

            position -= normVel * tipHeight * Projectile.scale;
            id = Payload is null? 0 : Payload.Item.type - ModContent.ItemType<DartCannister>();
            frame = new Rectangle(id * (width + 2),  tipHeight + 2, width, payloadHeight);
            Main.EntitySpriteDraw(texture, position, frame, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);

            position -= normVel * payloadHeight * Projectile.scale;
            id = Tail is null? 0 : Tail.Item.type - ModContent.ItemType<FeatheredTail>();
            frame = new Rectangle(id * (width + 2), payloadHeight + tipHeight + 4, width, tailHeight);
            Main.EntitySpriteDraw(texture, position, frame, lightColor, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
}