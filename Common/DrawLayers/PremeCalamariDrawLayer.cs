using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Common.Players;

namespace ChargerClass.Common.DrawLayers;

public class PremeCalamariDrawLayer : AnimatedDrawLayer
{
	public override void SafeSetStaticDefaults(){
		height = 28;
		width = 82;
		totalFrames = 4;
		ticsPerFrame = 10;
		scale = 1f;
		textureAsset = ModContent.Request<Texture2D>("ChargerClass/Common/DrawLayers/PremeCalamariDrawLayer");
		itemType = ModContent.ItemType<PremeCalamari>();
	}

	public override void PreDraw(ref PlayerDrawSet drawInfo) {
		var chargeWeapon = drawInfo.drawPlayer.HeldItem.ModItem as ChargeWeapon;
		if(chargeWeapon.charge > 0) ticsPerFrame = 20 - (int)Math.Sqrt((100 * ((float)chargeWeapon.charge / drawInfo.drawPlayer.GetModPlayer<ChargeModPlayer>().GetMaxCharge())));
	}
	public override Vector2 WeaponOffset() => new Vector2(-10, 0);

}