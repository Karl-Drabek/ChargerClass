using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class MegaMortarHoldout : ChargeWeaponHoldout
{
	public override void SafeSetDefaults()
	{
		drawSelf = true;
		Projectile.scale = 0.75f;
	}

	public override void ModifyOtherStats(
		int chargeLevel,
		Player player,
		ref int owner,
		ref float ai0,
		ref float ai1,
		ref float ai2
	)
	{
		ai1 = Main.MouseWorld.X;
		ai2 = chargeLevel;
	}

	public override void ModifyMuzzleOffset(ref Vector2 muzzleOffset)
	{
		muzzleOffset = new Vector2(20 * Projectile.spriteDirection, -30);
	}

	public override bool SafePreDraw(ref Color lightColor)
	{
		Player player = Main.player[Projectile.owner];
		SpriteEffects effects =
			Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
		Texture2D texture = TextureAssets.Projectile[Type].Value;
		Vector2 sheetInsertPosition = (
			player.MountedCenter + Vector2.UnitY * player.gfxOffY - Main.screenPosition
		).Floor();
		sheetInsertPosition +=
			Projectile.spriteDirection == 1 ? new Vector2(10, 0) : new Vector2(-10, 0);

		Main.EntitySpriteDraw(
			texture,
			sheetInsertPosition,
			new Rectangle?(new Rectangle(0, 0, texture.Width, texture.Height)),
			lightColor,
			0,
			new Vector2(texture.Width, texture.Height) / 2,
			Projectile.scale,
			effects,
			0f
		);
		return false;
	}

	public override float GetItemRotation() => 0;
}
