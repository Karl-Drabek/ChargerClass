using System.ComponentModel;
using Terraria.ModLoader.Config;
using Terraria.ModLoader;

namespace ChargerClass.Common.Configs;

public class ChargerClassConfig : ModConfig
{
        public static ChargerClassConfig Instance = ModContent.GetInstance<ChargerClassConfig>();

	// ConfigScope.ClientSide should be used for client side, usually visual or audio tweaks.
	// ConfigScope.ServerSide should be used for basically everything else, including disabling items or changing NPC behaviours
	public override ConfigScope Mode => ConfigScope.ClientSide;
	[Header("Info")] // Headers are like titles in a config. You only need to declare a header on the item it should appear over, not every item in the category. 
	// [Label("$Some.Key")] // A label is the text displayed next to the option. This should usually be a short description of what it does. By default all ModConfig fields and properties have an automatic label translation key, but modders can specify a specific translation key.
	[DefaultValue(false)]
	public bool ShotInfoToggle;
	public bool MaxChargeToggle;

}