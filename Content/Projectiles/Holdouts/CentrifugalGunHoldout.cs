using System;
using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace ChargerClass.Content.Projectiles.Holdouts;

public class CentrifugalGunHoldout : AnimatedChargeWeaponHoldout
{
	public override void SafestSetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 8;
	}

	public override void SafestSetDefaults()
	{
		Projectile.scale = 0.75f;
	}

	public override Vector2 HoldoutOffset(){
		return new Vector2(-16, 12);
	}

	public override Vector2 GetMuzzleOffset() => new Vector2(56, 8);
}
