using System.Collections.Generic;
using System.Linq;
using ChargerClass.Content.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Content.Mounts;

public class RailRailGunMount : ModMount
{
	public override void SetStaticDefaults()
	{
		// Movement
		MountData.jumpHeight = 12; // How high the mount can jump.
		MountData.acceleration = 0.05f; // The rate at which the mount speeds up.
		MountData.jumpSpeed = 4f; // The rate at which the player and mount ascend towards (negative y velocity) the jump height when the jump button is pressed.
		MountData.blockExtraJumps = false; // Determines whether or not you can use a double jump (like cloud in a bottle) while in the mount.
		MountData.constantJump = false; // Allows you to hold the jump button down.
		MountData.heightBoost = 20; // Height between the mount and the ground
		MountData.fallDamage = 2f; // Fall damage multiplier.
		MountData.runSpeed = 10f; // The speed of the mount
		MountData.dashSpeed = 8f; // The speed the mount moves when in the state of dashing.
		MountData.flightTimeMax = 0; // The amount of time in frames a mount can be in the state of flying.

		// Misc
		MountData.fatigueMax = 0;
		MountData.buff = ModContent.BuffType<RailRailGunBuff>(); // The ID number of the buff assigned to the mount.

		// Effects
		MountData.spawnDust = DustID.t_SteampunkMetal; // The ID of the dust spawned when mounted or dismounted.

		// Frame data and player offsets
		MountData.totalFrames = 1; // Amount of animation frames for the mount
		MountData.playerYOffsets = Enumerable.Repeat(48, MountData.totalFrames).ToArray(); // Fills an array with values for less repeating code
		MountData.xOffset = 30;
		MountData.yOffset = -8;
		MountData.playerHeadOffset = 22;
		MountData.bodyFrame = 3;
		// Standing
		MountData.standingFrameCount = 1;
		MountData.standingFrameDelay = 12;
		MountData.standingFrameStart = 0;
		// Running
		MountData.runningFrameCount = 1;
		MountData.runningFrameDelay = 12;
		MountData.runningFrameStart = 0;
		// Flying
		MountData.flyingFrameCount = 0;
		MountData.flyingFrameDelay = 0;
		MountData.flyingFrameStart = 0;
		// In-air
		MountData.inAirFrameCount = 1;
		MountData.inAirFrameDelay = 12;
		MountData.inAirFrameStart = 0;
		// Idle
		MountData.idleFrameCount = 1;
		MountData.idleFrameDelay = 12;
		MountData.idleFrameStart = 0;
		MountData.idleFrameLoop = true;
		// Swim
		MountData.swimFrameCount = MountData.inAirFrameCount;
		MountData.swimFrameDelay = MountData.inAirFrameDelay;
		MountData.swimFrameStart = MountData.inAirFrameStart;

		if (!Main.dedServ)
		{
			MountData.textureWidth = MountData.backTexture.Width();
			MountData.textureHeight = MountData.backTexture.Height();
		}
	}
}
