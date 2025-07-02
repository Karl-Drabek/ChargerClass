using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles.Holdouts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public abstract class LaserProjectile : ModProjectile
{
	private const float MAX_DISTANCE = 2200f;
	public Asset<Texture2D> TextureAsset;
	public int InitialOffset;

	public int spacing = 5;

	public int endsWidth,
		centerWidth;
	public int TotalFrames;
	public int TicsPerFrame;
	private int ticCounter;
	public int frame;

	public bool collide;

	public float Distance
	{
		get => Projectile.ai[0];
		set => Projectile.ai[0] = value;
	}

	public override void SetDefaults()
	{
		InitialOffset = 50;
		TotalFrames = 1;
		TicsPerFrame = 1;
		collide = true;
		centerWidth = 26;
		endsWidth = 22;
		SafeSetDefaults();
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.friendly = true;
		Projectile.penetrate = -1;
		Projectile.tileCollide = false;
		frame = 0;
		ticCounter = 0;
	}

	public virtual void SafeSetDefaults() { }

	public override bool ShouldUpdatePosition() => false;

	public override void CutTiles()
	{
		Player player = Main.player[Projectile.owner];
		DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
		Utils.PlotTileLine(
			player.MountedCenter + InitialOffset * Projectile.velocity,
			player.MountedCenter + Projectile.velocity * Distance,
			(Projectile.height + 16) * Projectile.scale,
			DelegateMethods.CutTiles
		);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
	{
		Player player = Main.player[Projectile.owner];
		float point = default;
		return Collision.CheckAABBvLineCollision(
			targetHitbox.TopLeft(),
			targetHitbox.Size(),
			player.MountedCenter + InitialOffset * Projectile.velocity,
			player.MountedCenter + Projectile.velocity * Distance,
			Projectile.height,
			ref point
		);
	}

	public override bool PreDraw(ref Color lightColor)
	{
		float rotation = Projectile.velocity.ToRotation();
		Player player = Main.player[Projectile.owner];
		Vector2 origin = new Vector2(Projectile.width, Projectile.height) / 2;
		SpriteEffects effects =
			Projectile.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipVertically;
		Vector2 position = player.RotatedRelativePoint(player.MountedCenter, false, true)
			- Main.screenPosition
			+ getLaserOffset();
		Color color = GetLaserColor(lightColor);
		Rectangle? sourceRectangle;
		Vector2 offset;

		if (TotalFrames > 1)
		{
			if (++ticCounter >= TicsPerFrame)
			{
				ticCounter -= TicsPerFrame;
				if (++frame >= TotalFrames)
					frame -= TotalFrames;
			}
		}

		sourceRectangle = new Rectangle(
			endsWidth + 2,
			frame * (Projectile.height + 1),
			centerWidth,
			Projectile.height
		);
		int i;
		for (i = InitialOffset + endsWidth * 2; i < Distance; i += centerWidth)
		{
			offset = Projectile.velocity * i;
			Main.EntitySpriteDraw(
				TextureAsset.Value,
				position + offset,
				sourceRectangle,
				color,
				rotation,
				origin,
				Projectile.scale,
				effects
			);
		}

		int reamainingCenter = (int)Distance - (i - centerWidth);
		sourceRectangle = new Rectangle(
			endsWidth + 2,
			frame * (Projectile.height + 1),
			reamainingCenter,
			Projectile.height
		);

		offset = Projectile.velocity * i;
		Main.EntitySpriteDraw(
			TextureAsset.Value,
			position + offset,
			sourceRectangle,
			color,
			rotation,
			origin,
			Projectile.scale,
			effects
		);

		sourceRectangle = new Rectangle(
			0,
			frame * (Projectile.height + 1),
			endsWidth,
			Projectile.height
		);
		offset = Projectile.velocity * (InitialOffset + endsWidth);
		Main.EntitySpriteDraw(
			TextureAsset.Value,
			position + offset,
			sourceRectangle,
			color,
			rotation,
			origin,
			Projectile.scale,
			effects
		);

		sourceRectangle = new Rectangle(
			centerWidth + endsWidth + 4,
			frame * (Projectile.height + 1),
			endsWidth,
			Projectile.height
		);
		offset = Projectile.velocity * (Distance + endsWidth);
		Main.EntitySpriteDraw(
			TextureAsset.Value,
			position + offset,
			sourceRectangle,
			color,
			rotation,
			origin,
			Projectile.scale,
			effects
		);

		return false;
	}

	public virtual Color GetLaserColor(Color lightColor) => lightColor;

	public sealed override void AI()
	{
		Player player = Main.player[Projectile.owner];
		Projectile.position = player.MountedCenter + Projectile.velocity * InitialOffset;
		if (player.heldProj == -1 || CustomKillcondition(player) || player.dead)
		{
			Projectile.Kill();
			return;
		}
		((ChargeWeaponHoldout)Main.projectile[player.heldProj].ModProjectile).resetTimer();
		UpdateProjectile(player);
		UpdateDistance(player);
		SpawnDusts(player);
		CastLights(player);
		SafeAI(player);
	}

	public void UpdateProjectile(Player player)
	{
		if (Projectile.owner == Main.myPlayer)
		{
			Projectile.velocity = Vector2.UnitX.RotatedBy(player.itemRotation) * player.direction;
			Projectile.direction = player.direction;
			Projectile.rotation = player.itemRotation;
			Projectile.netUpdate = true;
		}
	}

	public void UpdateDistance(Player player)
	{
		if (!collide)
			Distance = MAX_DISTANCE;
		else
		{
			for (Distance = InitialOffset; Distance <= MAX_DISTANCE; Distance += spacing)
			{
				Vector2 start = player.MountedCenter + InitialOffset * Projectile.velocity;
				Vector2 end = player.MountedCenter + Projectile.velocity * (Distance + spacing);
				if (ShouldEndLaser(start, end))
					break;
			}
		}
	}

	public virtual bool ShouldEndLaser(Vector2 start, Vector2 end) =>
		!Collision.CanHitLine(start, 1, 1, end, 1, 1);

	public virtual void SpawnDusts(Player player) { }

	public virtual void CastLights(Player player) { }

	public virtual void SafeAI(Player player) { }

	public virtual bool CustomKillcondition(Player player) => false;

	public virtual Vector2 getLaserOffset() => new(0, 0);
}
