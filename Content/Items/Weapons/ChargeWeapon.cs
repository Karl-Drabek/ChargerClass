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

        private int GetChargeLevel() => (int)(charge / chargeAmount);

        public sealed override void SetDefaults() {
            blowWeapon = false;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.useAnimation = 15;
            SafeSetDefaults(); //allows members to set defualts here
            Item.DamageType = ModContent.GetInstance<ChargerDamageClass>();
            Item.useStyle = ItemUseStyleID.Shoot;
        }

        public int GetTotalCharge() => charge + bonusCharge;

        public virtual void SafeSetDefaults() {} //use Projectile method to insure compatibility

        public sealed override bool CanShoot(Player player) => false; //we have our own shooting system so Projectile is not necessary
        
        public override void HoldItem(Player player){
            //Main.NewText(player.itemAnimation);
            if(player.itemAnimation == player.itemAnimationMax - 1){ //use style for some reason does not update charge. really confusing stuff
                ChargeModPlayer modPlayer = player.GetModPlayer<ChargeModPlayer>();

                if(player.mouseInterface || !player.HasAmmo(Item)){ //if the player runs out of ammo or hovers over UI
                    player.itemAnimation = 0; //end the animation
                    charge = 0; //reset charge
                }
                else if(!Main.mouseLeft) {//if player releases fire button
                    if(charge == 0) return; //exit if not charging
                    else if((charge > chargeAmount / 4) && (player.itemAnimation == player.itemAnimationMax - 1)) Shoot(player, modPlayer);//shoot the weapon if on first frame and greater than min charge
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
                    player.itemRotation = (float)Math.Atan2( //Point item towards curser with orientation (not my code).
                        (Main.MouseWorld.Y - player.Center.Y) * player.direction, //numerator for arctan
                        (Main.MouseWorld.X - player.Center.X) * player.direction); //Denominator for arctan
                    player.direction = Main.MouseWorld.X > player.Center.X ? 1 : -1; //Orient player towards mouse.
                }
            }
        }

        public void Shoot(Player player, ChargeModPlayer modPlayer){
            Item ammo = Item.ammo == Item.type ? Item : player.ChooseAmmo(Item);//get the ammo item for the weapon

            Vector2 position = Main.CurrentPlayer.Center; //Shoots from the location of the current Player's center
            Vector2 velocity = 
                Vector2.Normalize(Main.MouseWorld/*doesnt work with zoom*/ - Main.CurrentPlayer.Center)//gets the direction to the mouse, normalizes it for consistancy
                * (ammo.shootSpeed + Item.shootSpeed) * charge / ChargeModPlayer.DefaultCharge; 
            int type = ammo.shoot;
            int damage = player.GetWeaponDamage(Item);
            float knockback = player.GetWeaponKnockback(Item);
            chargeLevel = GetChargeLevel();

            modPlayer.ModifyProjectileSpeed(ref velocity);
            modPlayer.ModifyChargeLevel(ref chargeLevel, player.GetWeaponCrit(Item));//eventually don't use this
            ModifyShootStats(player, ref position, ref velocity, ref type, ref damage, ref knockback);
            
            var source = new EntitySource_ItemUse_WithAmmo(Main.CurrentPlayer, Item, Item.useAmmo);
            if(Shoot(player, source, position, velocity, type, damage, knockback)){
                Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback);
                PostProjectileEffects(proj, modPlayer);
            }
            //(count > 1) ? velocity.RotatedByRandom(MathHelper.ToRadians(count + (float)Math.Sqrt(4 * count))) : velocity,
            if(CanConsumeAmmo(Item, player)) player.ConsumeItem(ammo.type); //uses one of the weapon's ammo type. if it is none it is throwable so consume the ammo.
            modPlayer.ShootInfo(this, charge);
        }

        public void PostProjectileEffects(Projectile proj, ChargeModPlayer modPlayer){
            ChargerProjectile chargerProj = proj.GetGlobalProjectile<ChargerProjectile>();
            SafePostProjectileEffects(proj, chargerProj, modPlayer);

            chargerProj.LightningPole = modPlayer.GetLightningRod();
            if(modPlayer.GetShock()) chargerProj.Electrified = true;
            if(modPlayer.GetChargeRepository()) chargerProj.Repository = charge;
            if(modPlayer.LeatherGlove){
                chargerProj.LeatherGlove = true;
                chargerProj.LeatherGloveChargeLevel = chargeLevel;
            }
        }

        public sealed override void ModifyWeaponCrit(Player player, ref float crit){
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
            knockback *= (float)charge / ChargeModPlayer.DefaultCharge + 0.5f;
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

        public virtual void SafeModifyWeaponCrit(Player player, ref float crit) {}
        public virtual void SafeModifyWeaponDamage(Player player, ref StatModifier damage) {}
        public virtual void SafeModifyWeaponKnockback(Player player, ref StatModifier knockback) {}

        public virtual void SafePostProjectileEffects(Projectile proj, ChargerProjectile chargerProj, ChargeModPlayer modPlayer){}
    }
}