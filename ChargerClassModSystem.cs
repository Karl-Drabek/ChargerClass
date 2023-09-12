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
using ChargerClass.Content.Items.Weapons.Slingshots;
using System;

//TODO finish other chest loot

namespace ChargerClass
{
    class ChargerClassModSystem : ModSystem
    {
        internal ChargeMeter ChargeMeter;

        private UserInterface _chargeMeter;

        public static ModKeybind InhalerKeybind { get; private set; }

        public override void PostWorldGen() {
            int ItemCount = 0;
			for(int c = 0; c < Main.maxChests; c++) {
				Chest chest = Main.chest[c];
				if(chest == null) continue;

				Tile chestTile = Main.tile[chest.x, chest.y];
				//(ExampleMod): If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Frozen Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. An alternate approach is to check the wiki and looking for the "Internal Tile ID" section in the infobox: https://terraria.wiki.gg/wiki/Frozen_Chest
				if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 1 * 36) {

					if (WorldGen.genRand.NextBool(2, 3)) continue; //33% chance
					for (int i = 0; i < Chest.maxItems; i++) {
						if (chest.item[i].type == ItemID.None) {
							chest.item[i].SetDefaults(ItemCount % 2 == 0? ModContent.ItemType<TripleShot>() : ModContent.ItemType<TripleShot>());
                            if(++ItemCount >= 20) break;
							break;
						}
					}
				}
			}
        }

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