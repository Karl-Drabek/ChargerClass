using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.DataStructures;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Common.GlobalNPCs;
using ChargerClass.Common.Configs;

namespace ChargerClass.Content.Items.Weapons
{
	public abstract class ChargeWeapon : ModItem
	{
	    public int charge = 0;
	    public int chargeAmount = 10;
        public string chargeEffect = "";
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

        public sealed override void SetDefaults() {
            blowWeapon = false;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useAnimation = 10;
            Item.useTime = 10;
            SafeSetDefaults(); //allows members to set defualts here
            Item.DamageType = ChargerDamageClass.Instance;
            Item.useStyle = ItemUseStyleID.Shoot;
        }

        public int GetTotalCharge() => charge + bonusCharge;

        public virtual void SafeSetDefaults() {} //use Projectile method to insure compatibility

        public sealed override bool CanShoot(Player player) => false; //we have our own shooting system so Projectile is not necessary
        
        public override void HoldItem(Player player){
            if(player.whoAmI != Main.myPlayer) return;
            if(player.itemAnimation == player.itemAnimationMax - 1){ //use style for some reason does not update charge. really confusing stuff
                ChargeModPlayer modPlayer = player.GetModPlayer<ChargeModPlayer>();

                if(player.mouseInterface || !player.HasAmmo(Item)){ //if the player runs out of ammo or hovers over UI
                    player.itemAnimation = 0; //end the animation
                    charge = 0; //reset charge
                }
                else if(!Main.mouseLeft) {//if player releases fire button
                    if(charge == 0) return; //exit if not charging
                    else if(player.itemAnimation == player.itemAnimationMax - 1){
                        if(SafeCanShoot(player) && (charge > chargeAmount / 4)) Shoot(player, modPlayer);//shoot the weapon if on first frame and greater than min charge
                        else player.itemAnimation = 0;
                    } 
                    charge = 0; //resets the charge after shooting or if not greater than minimum charge. Then let animation play out.
                }
                else{ //it is assumed the player is charging the weapon
                    int maxCharge = modPlayer.GetMaxCharge();
                    if(bonusCharge > 0){
                        charge += bonusCharge;
                        bonusCharge = 0;
                    }
                    if(charge < maxCharge)charge += 300 / CombinedHooks.TotalUseTime(Item.useTime, player, Item); //increase charge if not maxed. 
                    else charge = maxCharge;
                    player.itemAnimation = player.itemAnimationMax; //reset the animation so it doesnt end
                    AnimatePlayer(player, false);
                }
            }else if(player.ItemAnimationActive){ //finish shooting bullets if shots remaining
                ItemAnimation(player);
                if(ShotsRemaining > 0){
                    player.itemAnimation = player.itemAnimationMax - 2;
                    AnimatePlayer(player, true);
                    if(++ticCounter >= ticsPerShot){
                        ticCounter = 0;
                        ShotsRemaining--;
                        Vector2 velocity = Vector2.Normalize(Main.MouseWorld - player.Center) * tempSpeed;
                        ChargeModPlayer modPlayer = player.GetModPlayer<ChargeModPlayer>();
                        ChargedShoot(player, modPlayer, tempSource, player.Center, velocity, tempType, tempDamage, tempKnockback);
                    }
                }else{
                    tempCrit = 0;
                }
            };
        }

        public void AnimatePlayer(Player player, bool charging){
            player.ChangeDir(Main.MouseWorld.X > player.Center.X ? 1 : -1); //Orient player towards mouse.
            player.itemRotation = (float)Math.Atan2( //Point item towards curser with orientation (not my code).
                (Main.MouseWorld.Y - player.Center.Y) * player.direction, //numerator for arctan
                (Main.MouseWorld.X - player.Center.X) * player.direction); //Denominator for arctan
        }

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
            float chargeSpeed = speed * (((float)charge / ChargeModPlayer.DefaultCharge) + 0.25f);
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

            player.ConsumeItem(usedAmmoItemId);
            modPlayer.ShootInfo(this, charge); //give info about the shot for ChargerClass Items.
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
            modPlayer.PostProjectileEffects(this, proj, chargerProj);
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
			var line = new TooltipLine(Mod, "Charge Value", $"{ChargeAmountDescription(chargeAmount)} charge levels");
			tooltips.Add(line);
            line = new TooltipLine(Mod, "Charge Effect", $"Charge Effect: {chargeEffect}");
			tooltips.Add(line);
        }

        public string ChargeAmountDescription(int chargeAmount) => chargeAmount switch{
            < 150 => "Tiny",
            < 250 => "Small",
            < 350 => "Normal",
            < 500 => "Large",
            < 650 => "Huge",
            _ => "Ginormous"
        };

        public virtual void ItemAnimation(Player player) {}
        public virtual void ModifyMuzzleOffset(ref Vector2 muzzleOffset) {}
        public virtual void ModifyOtherStats(Player player, ref int owner, ref float ai0, ref float ai1, ref float ai2) {}
        public virtual void PostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){}
        public virtual bool SafeCanShoot(Player player) => true;
        public virtual void SafeModifyWeaponCrit(Player player, ref float crit) {}
        public virtual void SafeModifyWeaponDamage(Player player, ref StatModifier damage) {}
        public virtual void SafeModifyWeaponKnockback(Player player, ref StatModifier knockback) {}
    }
}