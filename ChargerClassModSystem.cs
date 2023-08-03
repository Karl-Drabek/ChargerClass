using Terraria;
using Terraria.ModLoader;
using System.Linq;
using System.Collections.Generic;
using ChargerClass.Content.UI.ChargeMeter;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.ModLoader.Core;
using Terraria.ModLoader.UI.ModBrowser;
using Terraria.Social.Steam;
using Terraria.UI;
using Terraria.UI.Gamepad;
using ChargerClass.Content.Items;
using System;

namespace ChargerClass
{
    class ChargerClassModSystem : ModSystem
    {
        internal ChargeMeter ChargeMeter;

        private UserInterface _chargeMeter;

        public static Random Random = new Random();

        public static ModKeybind InhalerKeybind { get; private set; }

        public override void Load()
        {
            if (!Main.dedServ)
            {
                ChargeMeter = new ChargeMeter();
                ChargeMeter.Activate();
                _chargeMeter = new UserInterface();
                _chargeMeter.SetState(ChargeMeter);
            }
            InhalerKeybind = KeybindLoader.RegisterKeybind(Mod, "InhalerKeybind", "P");
        }

        public override void Unload() {
			InhalerKeybind = null;
		}

        public override void UpdateUI(GameTime gameTime)
        {   
            _chargeMeter?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ChargerClass: Displays charge for charged weapons",
                    delegate
                    {
                        _chargeMeter.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
	}
}