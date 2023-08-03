using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using ChargerClass.Common.GlobalProjectiles;
using ChargerClass.Content.Projectiles;
using ChargerClass.Common.Players;

namespace ChargerClass.Content.Items.Weapons
{
	public abstract class ChargeWeapon : ModItem
	{
	    public int charge = 0;
	    public int chargeAmount = 10;
	    public int minCharge;
        public bool blowWeapon;
        
        public int GetChargeLevels() => (int)(charge / chargeAmount);

        public sealed override void SetDefaults() { //Don't use Item.useTime or Item.useAnimation, instead use chargeAmount;
            minCharge = (int) (chargeAmount / 5); //can be overriden by SafeSetDefaults()
            blowWeapon = false;
            SafeSetDefaults(); //allows members to set defualts here
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged; //overrides any conflicts in SafeSetDefaults();
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public virtual void SafeSetDefaults() {} //use Projectile method to insure compatibility

        public sealed override bool CanShoot(Player player) => false; //we have our own shooting system so Projectile is not necessary

        public override void HoldItem(Player player){
            if(!player.mouseInterface) player.direction = Main.MouseWorld.X > player.Center.X ? 1 : -1; //turn the player based on which side of them the cursur is on
            player.itemRotation = (float) Math.Atan2((Main.MouseWorld.Y - player.Center.Y) * player.direction, (Main.MouseWorld.X - player.Center.X) * player.direction);
            //I don't fully understand how the itemRotation works. Arctan two finds he arctan of the qoutient of x and y.
            //Projectile should be the angle to the cursur but for some reason you have to multiply by the direction otherwise it will render upside down and in the wrong spot
            
            ChargeModPlayer modPlayer = player.GetModPlayer<ChargeModPlayer>(); //ModPlayer with ChargerClass specific variables.

            if(Main.mouseLeft && !player.mouseInterface && player.HasAmmo(Item)){ //if still charging
                
                if(charge < modPlayer.MaxCharge){ //and charge is less than the maximum charge
                    charge += modPlayer.ChargeSpeed; //increase the charge by the player's charge speed.
                }

            }else if(charge > minCharge && player.HasAmmo(Item)){ //otherwise if they are no longer changing, but charge is still stored: shoot a projectile
                
                float modifier = (float)charge / (float)modPlayer.MaxCharge; //percent charged
                int chargeLevels = GetChargeLevels(); //total full charge level
                Item ammo = Item.useAmmo == AmmoID.None ? Item : player.ChooseAmmo(Item);//get the ammo item for the weapon

                Vector2 velocity =  Vector2.Normalize(Main.MouseWorld/*doesnt work with zoom*/ - Main.CurrentPlayer.Center) * (Item.shootSpeed + ammo.shootSpeed) * modifier; //gets the direction to the mouse, normalizes it for consistancy and applies modifiers
                int type = ammo.shoot;
                int damage = (int)((Item.damage + ammo.damage) * modifier);
                float knockback = (Item.knockBack + ammo.knockBack) * modifier;
                int count = 1;
                bool consumeAmmo = true;

                modPlayer.GetChargeDamage(ref damage, chargeLevels);
                player.GetWeaponCrit(Item);
                modPlayer.GetProjectileSpeed(ref velocity);
                modPlayer.ModifyChargeLevel(ref chargeLevels, player.GetWeaponCrit(Item));
                ChargeLevelEffects(ref velocity, ref type, ref damage, ref knockback, ref chargeLevels, ref count, modifier, ref consumeAmmo);

                for(int i = 0; i < count; i++){
                    Projectile proj = Projectile.NewProjectileDirect(new EntitySource_ItemUse_WithAmmo(Main.CurrentPlayer, Item, Item.useAmmo), //I'm not sure what Projectile even does but apearently its necessary.
                    Main.CurrentPlayer.Center, //Shoots from the location of the current Player's center
                    (count > 1) ? velocity.RotatedByRandom(MathHelper.ToRadians(count + (float)Math.Sqrt(4 * count))) : velocity,
                    type, damage, knockback, Main.myPlayer); //owner should be the player, I am unsure if Projectile is necessary
                    ChargerProjectile chargerProj = proj.GetGlobalProjectile<ChargerProjectile>();
                    PostProjectileEffects(chargerProj, chargeLevels);
                    if(modPlayer.GetShock()) chargerProj.Electrified = true;
                    if(modPlayer.GetChargeRepository()) chargerProj.Repository = charge;
                    chargerProj.LightningPole = modPlayer.GetLightningRod();
                    if(modPlayer.LeatherGlove){
                        chargerProj.LeatherGlove = true;
                        chargerProj.LeatherGloveChargeLevel = chargeLevels;
                    }
                }

                if(consumeAmmo) player.ConsumeItem(ammo.type); //uses one of the weapon's ammo type. if it is none it is throwable so consume the ammo.
                modPlayer.ShootInfo(charge >= modPlayer.MaxCharge);
                charge = 0; //resets the charge after shooting
            }else charge = 0; //resets the charge if it wasnt fully charge and additionally some other potetial senarios that don't matter
        }

        public override void ModifyWeaponCrit(Player player, ref float crit){
            crit += 10 * ((float)charge / player.GetModPlayer<ChargeModPlayer>().DefaultCharge);
            player.GetModPlayer<ChargeModPlayer>().GetChargeCritChance(ref crit, GetChargeLevels());
            SafeModifyWeaponCrit(GetChargeLevels(), ref crit);
            crit = Utils.Clamp(crit, 0f, 100f);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
			var line = new TooltipLine(Mod, "Charge Value", $"Charge {chargeAmount}");
			tooltips.Add(line);
        }

        public virtual void SafeModifyWeaponCrit(int chargeLevels, ref float crit)  {}

        public virtual void PostProjectileEffects(ChargerProjectile chargerProj, int chargeLevel) {}
        
        public virtual void ChargeLevelEffects(ref Vector2 veloctiy, ref int type, ref int damage, ref float knockback, ref int chargeLevels, ref int count, float modifier, ref bool consumeAmmo) {}
    }
}