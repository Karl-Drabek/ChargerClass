using System;
using System.Collections.Generic;
using ChargerClass.Common.Configs;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Weapons;
public class TestChargeWeapon : ModItem
{
	public override void SetDefaults() {
		Item.shootSpeed = 32f;
		Item.UseSound = SoundID.Item23;
		Item.knockBack = 0.5f;
		Item.value = Item.buyPrice(gold: 12, silver: 60);
		Item.width = 32;
		Item.height = 32;
		Item.useTime = 30;
		Item.useAnimation = 15;
		Item.rare = ItemRarityID.LightRed;
		Item.damage = 27;
		SafeSetDefaults(); //allows members to set defualts here
		Item.DamageType = ChargerDamageClass.Instance;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.shoot = ModContent.ProjectileType<TestChargeWeaponProjectile>();
		Item.noMelee = true;
		Item.channel = true;
	}

	public virtual void SafeSetDefaults() {} //use Projectile method to insure compatibility

 	public int charge = 0;
    public int chargeAmount = 10;
    public bool blowWeapon;
    public int bonusCharge = 0;	
    public int chargeLevel; //only accurate after GetChargeLevel has been called

    EntitySource_ItemUse_WithAmmo tempSource;
    int tempType, tempDamage, ticCounter;
    float tempKnockback, tempSpeed, tempCrit;
    public int ShotsRemaining;

    public int ticsPerShot = 0; //if greater than zero fire Shoots Over time

    public int GetChargeLevel(Player player) => chargeLevel = (int)(charge / GetChargeAmount(player));

    public float GetChargeAmount(Player player) => player.GetModPlayer<ChargeModPlayer>().GetChargeAmountModifier().ApplyTo(chargeAmount);

    public int GetTotalCharge() => charge + bonusCharge;

    public void Shoot(Player player, ChargeModPlayer modPlayer){

        GetChargeLevel(player);
        int type, damage, usedAmmoItemId;
        float speed, knockBack;
        if(Item.useAmmo != AmmoID.None) player.PickAmmo(Item, out type, out speed, out damage, out knockBack, out usedAmmoItemId, true); //doesnt comsume ammo
        else{
            type = Item.shoot;
            damage = player.GetWeaponDamage(Item);
            knockBack = player.GetWeaponKnockback(Item);
            speed = Item.shootSpeed;
            usedAmmoItemId = Item.consumable ? Item.type : Item.useAmmo;
        }
        Vector2 position = player.Center;
        float chargeSpeed = (Math.Clamp((float)charge / ChargeModPlayer.DefaultCharge, 0, 1) + 1) / 2f * speed;
        Vector2 velocity = Vector2.Normalize(Main.MouseWorld/*doesnt work with zoom*/ - player.Center) * chargeSpeed;
        var source = new EntitySource_ItemUse_WithAmmo(player, Item, usedAmmoItemId);

        //modify speed and charge level based ChargerClass accesories
        modPlayer.ModifyProjectileSpeed(ref velocity);
        modPlayer.ModifyChargeLevel(ref chargeLevel, player.GetWeaponCrit(Item));

        //if gun is inteded to shoot a volley save stats for further projectiles
        if(ticsPerShot > 0){
            tempSource = source;
            tempType = type;
            tempDamage = damage;
            tempKnockback = knockBack;
            tempSpeed = chargeSpeed;
            tempCrit = player.GetWeaponCrit(Item);
            ShotsRemaining = chargeLevel;

        }

        ChargedShoot(player, modPlayer, source, position, velocity, type, damage, knockBack); //Shoot Projectile

        Item ammo = ContentSamples.ItemsByType[usedAmmoItemId];
        if(ammo.consumable && !player.IsAmmoFreeThisShot(Item, ammo, type)) player.ConsumeItem(usedAmmoItemId);
        //modPlayer.ShootInfo(this, charge); //give info about the shot for ChargerClass Items.
    }

    private void ChargedShoot(Player player, ChargeModPlayer modPlayer, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
        Vector2 muzzleOffset = Vector2.Normalize(velocity);
        ModifyMuzzleOffset(ref muzzleOffset);
        if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) position += muzzleOffset;
        CombinedHooks.ModifyShootStats(player, Item, ref position, ref velocity, ref type, ref damage, ref knockback); //modify stats for the weapon
        if(CombinedHooks.Shoot(player, Item, source, position, velocity, type, damage, knockback)){
            int owner = -1;
            float ai0 , ai1, ai2;
            ai0 = ai1 = ai2 = 0f;
            ModifyOtherStats(player, ref owner, ref ai0, ref ai1, ref ai2);
            if(ChargerClassConfig.Instance.ShotInfoToggle) Main.NewText($"Shot Stats:\n    Charge Levels: {chargeLevel}\n    Speed: {(int)Math.Sqrt(velocity.X*velocity.X+velocity.Y*velocity.Y)}\n    Damage: {damage}\n    Knock Back: {(int)knockback}\n    Crit Chance: {player.GetWeaponCrit(Item)}");
            Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, owner, ai0, ai1, ai2);
            CombinedPostProjectileEffects(proj, modPlayer);
        }
    }

    public void CombinedPostProjectileEffects(Projectile proj, ChargeModPlayer modPlayer){
        ChargerProjectile chargerProj = proj.GetGlobalProjectile<ChargerProjectile>();
        PostProjectileEffects(proj, chargerProj, modPlayer); //allow children to apply effects to projectiles.
        //modPlayer.PostProjectileEffects(this, proj, chargerProj);
    }

    public sealed override void ModifyWeaponCrit(Player player, ref float crit){
        if(tempCrit != 0){
            crit = tempCrit;
            return;
        }
        float percentCharged = (float)charge / ChargeModPlayer.DefaultCharge;
        if(percentCharged == 1) percentCharged += 0.25f;
        crit += 10 * percentCharged;
        SafeModifyWeaponCrit(player, ref crit);
    }

    public sealed override void ModifyWeaponDamage(Player player, ref StatModifier damage){
        if(charge < chargeAmount / 4) return; //ensures modifer work properly for tooltips
        float percentCharged = (float)charge / ChargeModPlayer.DefaultCharge;
        if(percentCharged == 1) percentCharged += 0.25f;
        damage *= percentCharged;
        SafeModifyWeaponDamage(player, ref damage);
    }
    public sealed override void ModifyWeaponKnockback(Player player, ref StatModifier knockback){
        knockback *= (float)charge / ChargeModPlayer.DefaultCharge;
        SafeModifyWeaponKnockback(player, ref knockback);
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips) {
        for(int i = 0; i < tooltips.Count; i++){
            if(blowWeapon && tooltips[i].Name == "Damage"){
                tooltips.Insert(i + 1, new TooltipLine(Mod, "BlowWeapon", $"Blowing weapon"));
            }
            if(tooltips[i].Name == "Speed"){
                tooltips.Insert(i, new TooltipLine(Mod, "ChargeValue", $"{ChargeAmountDescription(chargeAmount)} charge levels"));
                return;
            }
        }
    }

    public string ChargeAmountDescription(int chargeAmount) => chargeAmount switch{
        < 150 => "Tiny",
        < 250 => "Small",
        < 350 => "Normal",
        < 500 => "Large",
        < 650 => "Huge",
        _ => "Ginormous"
    };


    public virtual void WhileCharging(Player player) {}
    public virtual void ItemAnimation(Player player) {}
    public virtual void ModifyMuzzleOffset(ref Vector2 muzzleOffset) {}
    public virtual void ModifyOtherStats(Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2) {}
    public virtual void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){}
    public virtual bool SafeCanShoot(Player player) => true;
    public virtual void SafeModifyWeaponCrit(Player player, ref float crit) {}
    public virtual void SafeModifyWeaponDamage(Player player, ref StatModifier damage) {}
    public virtual void SafeModifyWeaponKnockback(Player player, ref StatModifier knockback) {}
}