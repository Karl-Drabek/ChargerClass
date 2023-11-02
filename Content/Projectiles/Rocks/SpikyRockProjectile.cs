using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
//Todo have the projectile stay where it hit the npc with correct orientation
namespace ChargerClass.Content.Projectiles.Rocks;

public class SpikyRockProjectile : ModProjectile
{
        private NPC _target;

        private int _damage;
        private Vector2 _offset;

	public override void SetDefaults()
	{
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 180;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;

            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override Color? GetAlpha(Color lightColor) {
            return new Color(155, 155, 155, 0) * Projectile.Opacity;
        }

        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone){
            Projectile.position -= Projectile.velocity;
            Projectile.aiStyle = 0; //remove gravity
            _target = target;
            _offset = Projectile.Center - _target.Center;
            _damage = hit.Damage / 6;
            Projectile.timeLeft = (int)Projectile.ai[2] * 20;
            Projectile.tileCollide = false;
        }

        public override bool? CanHitNPC (NPC target) => _target is null; //don't hit an NPC after locking on

        //stand in for ai[0]
        private float _timer{
		get => Projectile.ai[0];
		set => Projectile.ai[0] = value;
	}

        public override void AI(){
            if(_target is null) return; //should be aiStyle 1 if there is no target;

            if(!_target.active){ //destroy the projectile if the target died.
                Projectile.Kill();
                return;
            }

            _timer++;
            if(_timer >= 20){ //if the timer is greater than the limit, remove the max and deal damage for each removal.
                _target.SimpleStrikeNPC((int)_timer / 20 * _damage, _offset.X > 0 ? 0 : 1);
                _timer %= 20;
            }
            Projectile.Center = _target.Center + _offset;
        }

        public override void OnKill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
}