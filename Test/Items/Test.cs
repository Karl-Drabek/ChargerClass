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

namespace ChargerClass.Test.Items
{
	public abstract class Test : ModItem
	{
        public sealed override void SetDefaults() {
            Item.useTime = 15;
            Item.useAnimation = 15;
            SafeSetDefaults();
            Item.DamageType = ModContent.GetInstance<ChargerDamageClass>();
            Item.damage = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
        }

        public virtual void SafeSetDefaults() {}
    }
}