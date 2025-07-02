using ChargerClass.Common.Configs;
using ChargerClass.Content.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

//Todo have the projectile stay where it hit the npc with correct orientation
namespace ChargerClass.Content.Projectiles.Rocks;

public class SpikyRockProjectile : ModProjectile
{
	private NPC _target;

	private int _damage;
	private Vector2 _offset;

	public override void SetDefaults()
	{
		Projectile.width = 12;
		Projectile.height = 12;
		Projectile.aiStyle = -1;
		Projectile.friendly = true;
		Projectile.hostile = false;
		Projectile.DamageType = ChargerDamageClass.Instance;
		Projectile.penetrate = -1;
		Projectile.timeLeft = 180;
		Projectile.alpha = 0;
		Projectile.light = 0.0f;
		Projectile.scale = 0.75f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = true;
		Projectile.extraUpdates = 0;
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		Projectile.position -= Projectile.velocity;
		_target = target;
		_offset = Projectile.Center - _target.Center;
		_damage = hit.Damage / 6;
		Projectile.timeLeft = (int)Projectile.ai[2] * 20;
		Projectile.tileCollide = false;
		Projectile.netUpdate = true;
	}

	public override void OnSpawn(IEntitySource source)
	{
		Projectile.ai[1] = Main.rand.NextFloat(-MathHelper.ToRadians(10), MathHelper.ToRadians(10));
	}

	float ClampAngle(float angle)
	{
		angle %= MathHelper.Pi * 2;
		if (angle < 0)
			angle += MathHelper.Pi * 2;
		return angle;
	}

	public override bool? CanHitNPC(NPC target) => _target is null; //don't hit an NPC after locking on

	//stand in for ai[0]
	private float _timer
	{
		get => Projectile.ai[0];
		set => Projectile.ai[0] = value;
	}

	public override void AI()
	{
		if (_target is null)
		{
			Projectile.rotation += Projectile.ai[1];
			Projectile.rotation = ClampAngle(Projectile.rotation);
			if (Projectile.ai[0]++ > 10)
			{
				Projectile.velocity.Y += 0.14f;
			}
			return;
		}
		if (!_target.active)
		{ //destroy the projectile if the target died.
			Projectile.Kill();
			return;
		}

		_timer++;
		if (_timer >= 20)
		{ //if the timer is greater than the limit, remove the max and deal damage for each removal.
			_target.SimpleStrikeNPC((int)_timer / 20 * _damage, _offset.X > 0 ? 0 : 1);
			_timer %= 20;
			for (int i = 0; i < 3; ++i)
			{
				Dust.NewDustPerfect(Projectile.position, DustID.Blood);
			}
		}
		Projectile.Center = _target.Center + _offset;
	}

	public override void OnKill(int timeLeft)
	{
		Collision.HitTiles(
			Projectile.position + Projectile.velocity,
			Projectile.velocity,
			Projectile.width,
			Projectile.height
		);
		if (ChargerClassConfig.Instance.AudioToggle)
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
	}
}
