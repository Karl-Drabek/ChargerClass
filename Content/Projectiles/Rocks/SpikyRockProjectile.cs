using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
//Todo use ai[] to subtract velocity from position so the projectile doesnt stay in the middle of the NPCs.
//also incorperate rotation and direction to calculate the offset.
namespace ChargerClass.Content.Projectiles.Rocks
{
	public class SpikyRockProjectile : ModProjectile
	{
        private NPC _target;

        private int _damage;
        private Vector2 _offset;

	    public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spiky Rock Projectile");
        }

		public override void SetDefaults()
		{
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
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

        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit){
            Projectile.position -= Projectile.velocity;
            Projectile.aiStyle = 0; //remove gravity
            _target = target; 
            _offset = Projectile.position - target.position;
            _damage = damage;
            Projectile.timeLeft = 120;
            Projectile.tileCollide = false;
        }

        public override bool? CanHitNPC (NPC target) => _target is null; //don't hit a NPC after locking on

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

            _timer += _damage; //increment the timer by the original damage
            if(_timer >= 100){ //if the timer is greater than the limit, remove the max and deal damage for each removal.
                _target.StrikeNPCNoInteraction(_damage / 100, 0f, _offset.X > 0 ? 0 : 1);
                _timer = _damage % 100;
            }

            Projectile.position = _target.position + _offset; //recalulate the projectile's position based on where it orignaly hit the NPC
        }

        public override void Kill(int timeLeft) {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
	}
}