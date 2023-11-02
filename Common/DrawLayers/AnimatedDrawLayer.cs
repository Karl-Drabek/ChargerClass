using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
//using System.Numerics;

namespace ChargerClass.Common.DrawLayers;

public abstract class AnimatedDrawLayer : PlayerDrawLayer
{
	protected Asset<Texture2D> textureAsset;
	private Rectangle rect;
	protected int height, width, totalFrames, ticsPerFrame, itemType;
	private int frame, ticCounter, xOffSet, yOffSet;
	protected float scale;

	public override void SetStaticDefaults(){
		frame = ticCounter = xOffSet = yOffSet = 0;
		height = width = ticsPerFrame = totalFrames = 1;
		scale = 1f;

		SafeSetStaticDefaults();

		rect = new Rectangle(0, 0, width, height);
	}

	public virtual void SafeSetStaticDefaults() {}

	public sealed override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.HeldItem?.type == itemType && drawInfo.drawPlayer.ItemAnimationActive;

	public sealed override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

	protected sealed override void Draw(ref PlayerDrawSet drawInfo) {
		PreDraw(ref drawInfo);
		if(++ticCounter >= ticsPerFrame) {
			ticCounter -= ticsPerFrame;
			frame = ++frame % totalFrames;
		}
		rect.Y = (height + 2) * frame;

		Vector2 drawPosition = drawInfo.drawPlayer.Center - Main.screenPosition;
		drawPosition += new Vector2(xOffSet * drawInfo.drawPlayer.direction, yOffSet + drawInfo.drawPlayer.gfxOffY).Floor(); // Adding some offset and removing subpixel movement

		Vector2 origin;
		SpriteEffects effects;
		if(drawInfo.drawPlayer.direction == 1){
			origin = new Vector2(0, height / 2);
			effects = SpriteEffects.None;
		}else{
			origin = new Vector2(width, height / 2);
			effects = SpriteEffects.FlipHorizontally;
		}
		float rotation = drawInfo.drawPlayer.itemRotation;

		Texture2D texture = textureAsset.Value;
		Vector2 pos = (drawPosition + Main.screenPosition) / 16f;
		Color color = Lighting.GetColor((int)pos.X, (int)pos.Y);

		PreQueue(drawInfo.drawPlayer, ref texture, ref drawPosition, ref rect, ref color, ref rotation, ref origin, ref scale, ref effects);
		drawPosition += Vector2.UnitX.RotatedBy(rotation) * WeaponOffset().X * drawInfo.drawPlayer.direction + Vector2.UnitY.RotatedBy(rotation) * WeaponOffset().Y * drawInfo.drawPlayer.direction;
		drawInfo.DrawDataCache.Add(new DrawData(texture, drawPosition, rect, color, rotation, origin, scale, effects));
	}

	public virtual void PreDraw(ref PlayerDrawSet drawInfo) {}

	public virtual Vector2 WeaponOffset() => Vector2.Zero;
	public virtual void PreQueue(Player player, ref Texture2D texture, ref Vector2 drawPosition, ref Rectangle rect, ref Color color, ref float rotation, ref Vector2 origin, ref float scale, ref SpriteEffects effects) {}

}