using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Common.Players;

namespace ChargerClass.Common.DrawLayers
{
	public class RayOfBloonDrawLayer : AnimatedDrawLayer
	{
		int framesAtShoot = 0;
		int shotsAtShoot = 0;

		public override void SafeSetStaticDefaults(){
			height = 38;
			width = 84;
			totalFrames = 2;
			ticsPerFrame = 10;
			scale = 1f;
			textureAsset = ModContent.Request<Texture2D>("ChargerClass/Common/DrawLayers/RayOfBloonDrawLayer");
			itemType = ModContent.ItemType<RayOfBloon>();
		}

		public override void PreDraw(ref PlayerDrawSet drawInfo) {
			var chargeWeapon = drawInfo.drawPlayer.HeldItem.ModItem as ChargeWeapon;

			if(chargeWeapon.ShotsRemaining > 0 && drawInfo.drawPlayer.itemAnimation == drawInfo.drawPlayer.itemAnimationMax - 1) shotsAtShoot = chargeWeapon.ShotsRemaining; //if just shot store shotcount

			if(chargeWeapon.ShotsRemaining > 0){ // still shooting
				ticsPerFrame = framesAtShoot + shotsAtShoot - chargeWeapon.ShotsRemaining;
			}else if(chargeWeapon.charge > 0){ //charging
				ticsPerFrame = 30 - (int)Math.Sqrt(784d * ((float)chargeWeapon.charge / drawInfo.drawPlayer.GetModPlayer<ChargeModPlayer>().GetMaxCharge()));
				framesAtShoot = ticsPerFrame; //stores last speed while charging
				if(ticsPerFrame < 1) ticsPerFrame = 1;
			}else{ //finishing animation
				ticsPerFrame = 0;
			}
		}

	}
}