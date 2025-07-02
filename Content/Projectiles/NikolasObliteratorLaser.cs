using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Projectiles;

public class NikolasObliteratorLaser : LaserProjectile
{
	public override void SafeSetDefaults()
	{
		Projectile.width = 78;
		Projectile.height = 26;
		centerWidth = 30;
		endsWidth = 22;
		Projectile.timeLeft = 60;
		InitialOffset = 70;
		TextureAsset = ModContent.Request<Texture2D>(
			"ChargerClass/Content/Projectiles/RailgunLaser"
		);
	}

	public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.immune[Projectile.owner] = 5;
	}

	public override void SafeAI(Player player)
	{
		for (int i = InitialOffset; i < Distance; i += centerWidth)
		{
			if (!Main.rand.NextBool(1, 100))
				continue;
			Vector2 position = player.Center + Projectile.velocity * i;
			NPC closestNPC = null;
			float currentDistanceSquared = 90_000;
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (
					Collision.CanHit(position, 1, 1, target.position, 1, 1)
					&& target.CanBeChasedBy()
				)
				{
					float squareDistanceToNPC = Vector2.DistanceSquared(target.Center, position);
					if (squareDistanceToNPC < currentDistanceSquared)
					{
						closestNPC = target;
						currentDistanceSquared = squareDistanceToNPC;
					}
				}
			}
			if (closestNPC is not null)
			{
				Projectile.NewProjectileDirect(
					Projectile.GetSource_FromThis(),
					position,
					Vector2.Zero,
					ModContent.ProjectileType<LightningProjectile>(),
					Projectile.damage,
					Projectile.knockBack,
					Projectile.owner,
					closestNPC.whoAmI,
					2f
				);
			}
		}
	}
}
