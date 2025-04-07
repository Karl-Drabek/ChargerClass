using System;
using ChargerClass.Common.Players;
using Terraria;

namespace ChargerClass.Content.Projectiles.Holdouts;

public abstract class AnimatedChargeWeaponHoldout : ChargeWeaponHoldout
{
	private int framesAtShoot = 1;
	private int shotsAtShoot = 1;

	public sealed override void SetStaticDefaults()
	{
		Main.projFrames[Projectile.type] = 1;
        SafestSetStaticDefaults();
	}

	public sealed override void SafeSetDefaults()
	{
        SafestSetDefaults();
		drawSelf = true;
	}

	public override void ChargingAI(Player player)
	{
		ticsPerFrame = 30 - (int)Math.Sqrt(784d * ((float)Charge / player.GetModPlayer<ChargeModPlayer>().GetMaxCharge()));
		framesAtShoot = ticsPerFrame;
		shotsAtShoot = (int)Shots;
		if (ticsPerFrame < 1) ticsPerFrame = 1;
	}

	public override void ShootingAI(Player player)
	{
		ticsPerFrame = framesAtShoot + shotsAtShoot - (int)Shots;
	}

    public virtual void SafestSetStaticDefaults(){}
    public virtual void SafestSetDefaults(){}
}
