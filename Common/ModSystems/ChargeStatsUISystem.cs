using System.Collections.Generic;
using ChargerClass.Common.Configs;
using ChargerClass.Content.UI.ChargeStats;
using ChargerClass.Content.UI.DartAssemblyStation;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;

namespace ChargerClass.Common.ModSystems;

class ChargeStatsUISystem : ModSystem
{
	internal ChargeStatsState ChargeStatsState;
	private UserInterface UI;
	public static ChargeStatsUISystem Instance = ModContent.GetInstance<ChargeStatsUISystem>();

	private Vector2 UILocation = new(0, 0);

	public override void Load()
	{
		if (!Main.dedServ)
		{
			UI = new UserInterface();
			ChargeStatsState = new ChargeStatsState();
			ChargeStatsState.Activate();
			UI.SetState(null);
		}
	}

	internal void ShowUI()
	{
		UI?.SetState(ChargeStatsState);
	}

	internal void HideUI()
	{
		UI?.SetState(null);
	}

	private GameTime _lastUpdateUiGameTime;

	public override void UpdateUI(GameTime gameTime)
	{
		_lastUpdateUiGameTime = gameTime;
		if (ChargerClassConfig.Instance.ShowChargeStatsToggle)
		{
			if (UI?.CurrentState == null)
			{
				ShowUI();
			}
		}
		else
		{
			if (UI?.CurrentState != null)
			{
				HideUI();
			}
		}
		if (UI?.CurrentState != null)
		{
			UI.Update(gameTime);
		}
	}

	public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
	{
		int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
		if (mouseTextIndex != -1)
		{
			layers.Insert(
				mouseTextIndex,
				new LegacyGameInterfaceLayer(
					"ChargerClass: Relivant stats for the charger class",
					delegate
					{
						if (_lastUpdateUiGameTime != null && UI?.CurrentState != null)
						{
							UI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
						}
						return true;
					},
					InterfaceScaleType.UI
				)
			);
		}
	}

	public override void SaveWorldData(TagCompound tag)
	{
		tag["ChargeStatsUIX"] = ChargeStatsState.Left.Pixels;
		tag["ChargeStatsUIY"] = ChargeStatsState.Top.Pixels;
	}

	public override void LoadWorldData(TagCompound tag)
	{
		ChargeStatsState.Left.Set(tag.GetFloat("ChargeStatsUIX"), 0f);
		ChargeStatsState.Top.Set(tag.GetFloat("ChargeStatsUIY"), 0f);
	}
}
