using ReLogic.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using ChargerClass.Content.UI;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Common.Players;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ModLoader;

namespace ChargerClass.Content.UI.ChargeMeter
{
    class ChargeMeter : UIState
    {
        private ChargeWeapon chargeWeapon;
        private Color gradientA, gradientB;
        private Rectangle outerHitbox, innerHitbox;
        private Texture2D pixel, devider, frame;
        private int outerWidth, outerHeight, innerWidth, innerHeight, yOffset;

        public override void OnInitialize() {
			gradientA = new Color(229, 130, 43); // Orange
			gradientB = new Color(204, 74, 202); // Purple

            outerWidth = 200;
            outerHeight = 30;
            innerWidth = 100;
            innerHeight = 3;
            yOffset = 40;

            pixel = ModContent.Request<Texture2D>("ChargerClass/Content/UI/ChargeMeter/MeterFill", AssetRequestMode.ImmediateLoad).Value; //I hope this is the best way to pull textures. it is possible these should not be Immediate load because they are not called during game time
            devider = ModContent.Request<Texture2D>("ChargerClass/Content/UI/ChargeMeter/MeterDevider", AssetRequestMode.ImmediateLoad).Value;
            frame = ModContent.Request<Texture2D>("ChargerClass/Content/UI/ChargeMeter/MeterFrameSmall", AssetRequestMode.ImmediateLoad).Value;
        }

        public override void Draw(SpriteBatch spriteBatch) { //only draw if the weapon is a charge weapon.
            if (Main.LocalPlayer.HeldItem.ModItem is ChargeWeapon weapon){
                chargeWeapon = weapon;
                base.Draw(spriteBatch);
            }
            return;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch) {
            base.DrawSelf(spriteBatch);

            outerHitbox = new Rectangle((Main.screenWidth - outerWidth) / 2, (Main.screenHeight - outerHeight) / 2 + yOffset, outerWidth, outerHeight);
            innerHitbox = new Rectangle((Main.screenWidth - innerWidth) / 2, (Main.screenHeight - innerHeight) / 2 + yOffset - 1, innerWidth, innerHeight);

            int MaxCharge = Main.CurrentPlayer.GetModPlayer<ChargeModPlayer>().GetMaxCharge();
            float charge = (float)chargeWeapon.GetTotalCharge() / MaxCharge;
            charge = Utils.Clamp(charge, 0f, 1f);

            int steps = (int)(innerHitbox.Width * charge); //how many pixels of charge to fill the meter with

            for (int i = 0; i < steps; i++) {
                float percent = (float)i / innerHitbox.Width; //how far through the total hitbox the fill is
                spriteBatch.Draw(pixel, new Rectangle(innerHitbox.Left + i, innerHitbox.Y, 1, innerHitbox.Height), Color.Lerp(gradientA, gradientB, percent));
            }
            
            int chargeLevel = MaxCharge / chargeWeapon.chargeAmount; //total levels
            int levelAmount = (int)(chargeWeapon.chargeAmount / (float)MaxCharge * innerHitbox.Width); //pixels per level

            spriteBatch.Draw(frame, outerHitbox, Color.White); //draw the frame first
            

            Color[] pixels = new Color[frame.Width * frame.Height];//array of all pixels in the frame png.
            frame.GetData<Color>(pixels); //populate pixels
            //The above way of getting near pixels to fill in the bar has some issues:
            //it gets far more pixels than neccessary. It would be better to get only a couple pixels in the below for loop but I got errors when I tried this.
            //It also miht be better to just create a seocnd sprite with pixels that allign better to fill it in. This sprite would be smaller and match better.

            for(int i = 1; i <= chargeLevel; i++) {

                Color topColor = pixels[frame.Width * 11 + (i * levelAmount) + 51]; //color taken from one pixel above to cover the normally black part of the frame on the top
                Color bottomColor = pixels[frame.Width * 17 + (i * levelAmount) + 51]; //color taken from one pixel below to cover the normally black part of the frame on the bottem
                
                spriteBatch.Draw(pixel, new Rectangle(innerHitbox.Left + (i * levelAmount) - 1, innerHitbox.Y - 1, 3, 1), topColor); //3x1 on top
                spriteBatch.Draw(pixel, new Rectangle(innerHitbox.Left + (i * levelAmount), innerHitbox.Y, 1, 1), topColor); // 1x1 below that

                spriteBatch.Draw(pixel, new Rectangle(innerHitbox.Left + (i * levelAmount) - 1, innerHitbox.Y + 3, 3, 1), bottomColor); //3x1 on bottem
                spriteBatch.Draw(pixel, new Rectangle(innerHitbox.Left + (i * levelAmount), innerHitbox.Y + 2, 1, 1), bottomColor); //1x1 on top of that

                spriteBatch.Draw(devider, new Rectangle(innerHitbox.Left + (i * levelAmount) - 1, innerHitbox.Y, 3, 3), Color.White); //devider is black and outlines the above area.
                

            }
        }
	}
}