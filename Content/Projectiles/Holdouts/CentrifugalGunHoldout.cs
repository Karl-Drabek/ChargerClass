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
}
