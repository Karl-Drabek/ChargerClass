using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChargerClass.Common.ModSystems;

class ModLightingSystem : ModSystem
{
	public static ModLightingSystem Instance = ModContent.GetInstance<ModLightingSystem>();
	public float lightMuliplyer = 1;
	private bool resetLighting;

	public float timeSpeed = 1;

	public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
	{
		tileColor *= lightMuliplyer;
		backgroundColor *= lightMuliplyer;
	}

	public override void ModifyTimeRate(
		ref double timeRate,
		ref double tileUpdateRate,
		ref double eventUpdateRate
	)
	{
		timeRate *= timeSpeed;
		tileUpdateRate *= timeSpeed;
		eventUpdateRate *= timeSpeed;
	}

	public void ResetLighting()
	{
		resetLighting = true;
	}

	private float fastforward = 1;

	public void resetTime(float amount)
	{
		fastforward = amount;
		timeSpeed = 100;
	}

	public override void OnWorldUnload()
	{
		lightMuliplyer = 1;
		timeSpeed = 1;
	}

	public override void NetSend(BinaryWriter writer)
	{
		writer.Write((double)lightMuliplyer);
		writer.Write((double)timeSpeed);
	}

	public override void PreUpdateWorld()
	{
		if (resetLighting)
		{
			if (lightMuliplyer < 1)
			{
				lightMuliplyer += 0.03f;
				if (lightMuliplyer > 1)
				{
					lightMuliplyer = 1f;
				}
				NetMessage.SendData(MessageID.WorldData);
			}
			else
			{
				resetLighting = false;
			}
		}
		if (fastforward > 0)
		{
			fastforward -= timeSpeed;
			if (fastforward < 0)
			{
				timeSpeed = 1;
			}
			NetMessage.SendData(MessageID.WorldData);
		}
	}

	public override void NetReceive(BinaryReader reader)
	{
		lightMuliplyer = (float)reader.ReadDouble();
		timeSpeed = (float)reader.ReadDouble();
	}
}
