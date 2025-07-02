using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ChargerClass.Content.Items.Ammo.Darts;

public abstract class DartComponent : ModItem
{
	public int Pen,
		DartSheetPlacement,
		AIStyle;
	public bool Collide,
		Bounce;

	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 0;
	}

	public override void SetDefaults()
	{
		Pen = 0;
		Collide = true;
		AIStyle = 1;
		SafeSetDefaults();
		Item.DamageType = ChargerDamageClass.Instance;
		Item.maxStack = 999;
	}

	public virtual void SafeSetDefaults() { }

	public virtual void OnHitNPC(
		Projectile projectile,
		NPC target,
		NPC.HitInfo hit,
		int damageDone,
		float buffTimeMultiplier
	) { }

	public virtual void AI(Projectile projectile, int payloadType) { }

	public virtual void OnKill(Projectile projectile, int timeLeft) { }

	public virtual void OnSpawn(Projectile projectile, IEntitySource source) { }

	public virtual void ModifyHitNPC(
		Projectile projetile,
		NPC target,
		ref NPC.HitModifiers modifiers
	) { }
}
