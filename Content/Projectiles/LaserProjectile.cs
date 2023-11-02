using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;

namespace ChargerClass.Content.Projectiles;

public abstract class LaserProjectile : ModProjectile
{
	public Asset<Texture2D> TextureAsset;
	public int InitialOffset;
	public int Spacing;
	public int TotalFrames;
	public int TicsPerFrame;
	private int ticCounter;
	public int frame;

	public float Distance {
		get => Projectile.ai[0];
		set => Projectile.ai[0] = value;
	}

	public override void SetDefaults() {
		InitialOffset = 50;
		TotalFrames = 1;
		TicsPerFrame = 1;
		SafeSetDefaults();
		Spacing = 5;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.friendly = true;
		Projectile.penetrate = -1;
		Projectile.tileCollide = false;
		frame = 0;
		ticCounter = 0;
	}

	public virtual void SafeSetDefaults() {}
	
	public override bool ShouldUpdatePosition() => false;

	public override void CutTiles() {
		Player player = Main.player[Projectile.owner];
		DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
		Utils.PlotTileLine(player.Center + InitialOffset * Projectile.velocity, player.Center + Projectile.velocity * Distance, (Projectile.width + 16) * Projectile.scale, DelegateMethods.CutTiles);
	}

	public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
		Player player = Main.player[Projectile.owner];
		float point = default;
		return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), player.Center + InitialOffset * Projectile.velocity, player.Center + Projectile.velocity * Distance, Projectile.width, ref point);
	}

	public override bool PreDraw(ref Color lightColor) {
		Player player = Main.player[Projectile.owner];
		Vector2 origin = new Vector2(Projectile.width, Projectile.height) / 2;
		SpriteEffects effects = player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
		Vector2 position = player.Center - Main.screenPosition;
		Color color = GetLaserColor(lightColor);
		Rectangle? sourceRectangle;
		Vector2 offset;

		if(TotalFrames > 1){
			if(++ticCounter >= TicsPerFrame){
				ticCounter -= TicsPerFrame;
				if(++frame >= TotalFrames) frame -= TotalFrames;
			}
		}

		sourceRectangle = new Rectangle(Projectile.width, frame * (Projectile.height + 1), Projectile.width, Projectile.height);
		for(int i = InitialOffset + Spacing; i < Distance; i += Spacing){
			offset = Projectile.velocity * i;
			Main.EntitySpriteDraw(TextureAsset.Value, position + offset, sourceRectangle, color, Projectile.rotation, origin, Projectile.scale, effects);
		}

		sourceRectangle = new Rectangle(0, frame * (Projectile.height + 1), Projectile.width, Projectile.height);
		offset = Projectile.velocity * InitialOffset;
		Main.EntitySpriteDraw(TextureAsset.Value, position + offset, sourceRectangle, color, Projectile.rotation, origin, Projectile.scale, effects);
		
		sourceRectangle = new Rectangle(Projectile.width * 2, frame * (Projectile.height + 1), Projectile.width, Projectile.height);
		offset = Projectile.velocity * Distance;
		Main.EntitySpriteDraw(TextureAsset.Value, position + offset, sourceRectangle, color, Projectile.rotation, origin, Projectile.scale, effects);

		return false;
	}

	public virtual Color GetLaserColor(Color lightColor) => lightColor;

	public override void AI() {
		Player player = Main.player[Projectile.owner];
		Projectile.position = player.Center + Projectile.velocity * InitialOffset;
		UpdateProjectile(player);
		UpdateDistance(player);
		SpawnDusts(player);
		CastLights(player);
	}

	public void UpdateProjectile(Player player) {
		if (Projectile.owner == Main.myPlayer) {
			Projectile.velocity = Vector2.UnitX.RotatedBy(player.itemRotation) * player.direction;
			Projectile.direction = player.direction;
			Projectile.rotation = player.itemRotation;
			Projectile.netUpdate = true;
		}
	}

	public void UpdateDistance(Player player){
		for (Distance = InitialOffset; Distance <= 2200f; Distance += Spacing) {
			Vector2 projEnd = player.Center + Projectile.velocity * (Distance + 5f);
			if (!Collision.CanHitLine(player.Center + InitialOffset * Projectile.velocity, 1, 1, projEnd, 1, 1)) break;
		}
	}
	
	public virtual void SpawnDusts(Player player){}

	public virtual void CastLights(Player player) {}
}