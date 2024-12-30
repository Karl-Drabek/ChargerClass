using System;
using ChargerClass.Common.Configs;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class TestChargeWeaponProjectile : ModProjectile
{
    public int charge = 0;
    public int chargeLevel; //only accurate after GetChargeLevel has been called
    public override void SetStaticDefaults() {
        ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
    }

    public override void SetDefaults() {
        Projectile.width = 22;
        Projectile.height = 22;
        Projectile.friendly = true;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.ownerHitCheck = true;
        Projectile.aiStyle = -1;
        Projectile.hide = true;
    }
    public override void AI() {
        Player player = Main.player[Projectile.owner];
        Item Item = player.HeldItem;
        TestChargeWeapon test = Item.ModItem as TestChargeWeapon;

        Projectile.timeLeft = 60;
        
        Vector2 playerCenter = player.RotatedRelativePoint(player.MountedCenter);

        if (Main.myPlayer == Projectile.owner) {
            if (player.channel){
                float holdoutDistance = player.HeldItem.shootSpeed * Projectile.scale;
                Vector2 holdoutOffset = holdoutDistance * Vector2.Normalize(Main.MouseWorld - playerCenter);
                if (holdoutOffset.X != Projectile.velocity.X || holdoutOffset.Y != Projectile.velocity.Y) {
                    // This will sync the projectile, most importantly, the velocity.
                    Projectile.netUpdate = true;
                }
                Projectile.velocity = holdoutOffset;
            }else Projectile.Kill();
        }

        int maxCharge = player.GetModPlayer<ChargeModPlayer>().GetMaxCharge();
        if(charge < maxCharge)charge += 300 / CombinedHooks.TotalUseTime(Item.useTime, player, Item); //increase charge if not maxed. 
        else charge = maxCharge;
        Main.NewText(charge);

        if (Projectile.velocity.X > 0f) player.ChangeDir(1);
        else if (Projectile.velocity.X < 0f) player.ChangeDir(-1);
        Projectile.spriteDirection = Projectile.direction;
        player.ChangeDir(Projectile.direction); // Change the player's direction based on the projectile's own
        player.heldProj = Projectile.whoAmI; // We tell the player that the drill is the held projectile, so it will draw in their hand
        player.SetDummyItemTime(2); // Make sure the player's item time does not change while the projectile is out
        Projectile.Center = playerCenter; // Centers the projectile on the player. Projectile.velocity will be added to this in later Terraria code causing the projectile to be held away from the player at a set distance.
        Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        player.itemRotation = (Projectile.velocity * Projectile.direction).ToRotation();
    }
}