using Terraria;
using Terraria.ModLoader;
using System.Linq;
using System.Collections.Generic;
using ChargerClass.Content.UI.DartAssemblyStation;
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
using ChargerClass.Content.UI;
using Terraria.UI.Gamepad;
using System;

namespace ChargerClass.Common.ModSystems
{
    class DartAssemblyStationUISystem : ModSystem
    {   
        internal DartAssemblyState DartAssemblyState;
        private UserInterface UI;
        public static DartAssemblyStationUISystem Instance = ModContent.GetInstance<DartAssemblyStationUISystem>();

        public override void Load()
        {
            if (!Main.dedServ)
            {
                UI = new UserInterface();
                DartAssemblyState = new DartAssemblyState();
                DartAssemblyState.Activate();
                UI.SetState(null);
            }
        }
        
        internal void ShowUI() {
            UI?.SetState(DartAssemblyState);
        }

        internal void HideUI() {
            UI?.SetState(null);
        }

        private GameTime _lastUpdateUiGameTime;

        public override void UpdateUI(GameTime gameTime) {
            _lastUpdateUiGameTime = gameTime;
            if (UI?.CurrentState != null) {
                UI.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1){
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ChargerClass: Allows player to craft custom darts",
                    delegate
                    {
                        if ( _lastUpdateUiGameTime != null && UI?.CurrentState != null) {
                            UI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
	}
}