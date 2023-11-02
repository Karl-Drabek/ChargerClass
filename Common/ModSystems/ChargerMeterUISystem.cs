using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using ChargerClass.Content.UI.ChargeMeter;
using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ChargerClass.Common.ModSystems;

class ChargerMeterUISystem : ModSystem
    {   
        internal ChargeMeter ChargeMeter;
        private UserInterface UI;
        public static ChargerMeterUISystem Instance = ModContent.GetInstance<ChargerMeterUISystem>();

        public override void Load()
        {
            if (!Main.dedServ)
            {
                UI = new UserInterface();
                ChargeMeter = new ChargeMeter();
                ChargeMeter.Activate();
                UI.SetState(ChargeMeter);
            }
        }
        
        /*
        internal void ShowMyUI() {
            MyInterface?.SetState(MyUI);
        }

        internal void HideMyUI() {
            MyInterface?.SetState(null);
        }
        */

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
                    "ChargerClass: Displays charge for charged weapons",
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