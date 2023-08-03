using ReLogic.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Test.Projectiles
{
	public class CentrifeugalGunChamber : ModProjectile
	{
	    public override void SetStaticDefaults() {
            DisplayName.SetDefault("Centrifeugal Gun Chamber");
						// Total count animation frames
			Main.projFrames[Projectile.type] = 4;
        }

		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hide = false;
			Projectile.ignoreWater = true;
			Projectile.scale = 1f;
        }

		public float Time{
			get => Projectile.ai[0];
			set => Projectile.ai[0] = value;
		}
		//virtual void 	DrawBehind (int index, List< int > behindNPCsAndTiles, List< int > behindNPCs, List< int > behindProjectiles, List< int > overPlayers, List< int > overWiresUI)
 	    //When used in conjunction with "Projectile.hide = true", allows you to specify that this projectile should be drawn behind certain elements. Add the index to one and only one of the lists. For example, the Nebula Arcanum projectile draws behind NPCs and tiles.
        
		public override bool PreDraw (ref Color lightColor){

			Player player = Main.player[Projectile.owner];
			SpriteEffects spriteEffects = SpriteEffects.None;
			player.direction = Main.MouseWorld.X > player.Center.X ? 1 : -1;
			if (player.direction == 1) spriteEffects = SpriteEffects.FlipHorizontally;
			Asset<Texture2D> texture = ModContent.Request<Texture2D>("ChargerClass/Projectiles/CentrifeugalGunChamber", AssetRequestMode.ImmediateLoad);
			int frameHeight = texture.Height() / Main.projFrames[Projectile.type];
			int frameTop = frameHeight * Projectile.frame;
			Main.EntitySpriteDraw(texture.Value,
								Projectile.position,
								new Rectangle(0, frameTop, texture.Value.Width, frameHeight),
								lightColor,
								player.itemRotation,
								new Vector2((float)texture.Value.Width / 2f, 0),
								Projectile.scale,
								spriteEffects,
								0);
			return true;
		}

		public override void AI(){
			Player player = Main.player[Projectile.owner];
			Projectile.position = player.Center;
			Projectile.rotation = player.itemRotation;
            Time++;
			int speed = Time switch{
				<= 40f => 2,
				<= 80f => 3,
				<= 120f => 4,
				_ => 1
			};

			Projectile.frameCounter += speed; //Increase the frame counter by the speed
			if (Projectile.frameCounter >= 4) //If the frame counter is greater than the required for a frame change
			{
				Projectile.frameCounter -= 4; //reduce it by the required for a frame change (you can use modulo if speed is greater than 4)
				Projectile.frame++; //increment the frame (this can be more if the speed is greater than 4)
				Projectile.frame %= Main.projFrames[Projectile.type];//make sure the frame is between 0 and max
			}

			if (Main.myPlayer == Projectile.owner)
			{
				if (Main.mouseLeft)
				{
				}else Projectile.Kill();
			}
		}
        
	}
}