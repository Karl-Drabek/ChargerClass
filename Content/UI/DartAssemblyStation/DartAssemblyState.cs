using ReLogic.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using ChargerClass.Content.UI;
using ChargerClass.Content.Items.Weapons;
using ChargerClass.Common.Players;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using System;
using ChargerClass.Common.Sets;
using Terraria.ModLoader;
using ChargerClass.Content.Items.Ammo.Darts;
using ChargerClass.Common.ModSystems;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace ChargerClass.Content.UI.DartAssemblyStation
{
    class DartAssemblyState : UIState
    {
        private VanillaItemSlotWrapper dartTailSlot, dartPayloadSlot, dartTipSlot, dartResultSlot;

        public int TableX, TableY;
        private Item oldItem;

        public int[] ComponentTypes{
			get => new int[4]{dartTailSlot.Item?.type ?? 0,
                            dartPayloadSlot.Item?.type ?? 0,
                            dartTipSlot.Item?.type ?? 0,
                            dartResultSlot.Item?.type ?? 0};
        }

        public void UpdateItems(int[] types, int[] counts){
                dartTailSlot.Item = new Item(types[0], counts[0]);
                dartPayloadSlot.Item = new Item(types[1], counts[1]);
                dartTipSlot.Item = new Item(types[2], counts[2]);
                dartResultSlot.Item = new Item(types[3], counts[3]);
        }
        public int[] ComponentCounts{
			get => new int[4]{dartTailSlot.Item?.stack ?? 0,
                            dartPayloadSlot.Item?.stack ?? 0,
                            dartTipSlot.Item?.stack ?? 0,
                            dartResultSlot.Item?.stack ?? 0};
        }

        public override void OnInitialize() {
            var panel = new UIPanel();
            panel.Width.Set(300, 0);
            panel.Height.Set(200, 0);
            panel.BackgroundColor = new Color(73, 94, 171);
            panel.HAlign = panel.VAlign = 0.5f;
            Append(panel);

            var header = new UIText("Dart Assembly Station");
            header.HAlign = 0.5f;
            panel.Append(header);

            dartTailSlot = new VanillaItemSlotWrapper();
            dartTailSlot.ValidItemFunc = item => Sets.IsDartTail[item.type] || item.type == ItemID.None;
            dartTailSlot.VAlign = 0.5f;
            dartTailSlot.Left = new StyleDimension(10f, 0f);
            panel.Append(dartTailSlot);

            dartPayloadSlot = new VanillaItemSlotWrapper();
            dartPayloadSlot.ValidItemFunc = item => Sets.IsDartPayload[item.type] || item.type == ItemID.None;
            dartPayloadSlot.VAlign = 0.5f;
            dartPayloadSlot.Left = new StyleDimension(70, 0f);
            panel.Append(dartPayloadSlot);

            dartTipSlot = new VanillaItemSlotWrapper();
            dartTipSlot.ValidItemFunc = item => Sets.IsDartTip[item.type] || item.type == ItemID.None;
            dartTipSlot.VAlign = 0.5f;
            dartTipSlot.Left = new StyleDimension(130, 0f);
            panel.Append(dartTipSlot);

            dartResultSlot = new VanillaItemSlotWrapper();
            dartResultSlot.ValidItemFunc = item => item.type == ItemID.None || item.type == dartResultSlot.Item.type;
            dartResultSlot.VAlign = 0.5f;
            dartResultSlot.Left = new StyleDimension(-60f, 1f);
            panel.Append(dartResultSlot);

            oldItem = new Item();
            oldItem.SetDefaults(ItemID.None);
        }

        public IEnumerable<Item> GetItemDrops(){
            yield return new Item(ModContent.ItemType<Items.Placeable.DartAssemblyStation>());
            if(dartTailSlot.Item is not null) yield return dartTailSlot.Item;
            if(dartPayloadSlot.Item is not null) yield return dartPayloadSlot.Item;
            if(dartTipSlot.Item is not null) yield return dartTipSlot.Item;
            if(dartResultSlot.Item is not null) yield return dartResultSlot.Item;
            dartTailSlot.Item.stack = dartPayloadSlot.Item.stack = dartTipSlot.Item.stack = dartResultSlot.Item.stack = 0;
        }
        
        public override void Update(GameTime gameTime){
            if(dartResultSlot.Item is not null && oldItem is not null && dartResultSlot.Item.IsNotSameTypePrefixAndStack(oldItem)){
                int difference = oldItem.stack - dartResultSlot.Item.stack;
                dartTailSlot.Item.stack -= difference;
                dartPayloadSlot.Item.stack -= difference;
                dartTipSlot.Item.stack -= difference;
            }
            if(dartTailSlot.Item.type != ItemID.None && dartPayloadSlot.Item.type != ItemID.None && dartTipSlot.Item.type != ItemID.None){
                if(dartResultSlot.Item.type == ItemID.None){
                    dartResultSlot.Item = new Item();
                    dartResultSlot.Item.SetDefaults(ModContent.ItemType<CustomDart>());
                }
                var dartComp = dartResultSlot.Item.ModItem as CustomDart;
                dartComp.ResetDefaults(dartTailSlot.Item.ModItem as DartComponent, dartPayloadSlot.Item.ModItem as DartComponent, dartTipSlot.Item.ModItem as DartComponent);
                dartResultSlot.Item.stack = dartTailSlot.Item.stack < dartPayloadSlot.Item.stack ? dartTailSlot.Item.stack : dartPayloadSlot.Item.stack;
                dartResultSlot.Item.stack = dartTipSlot.Item.stack < dartResultSlot.Item.stack ? dartTipSlot.Item.stack : dartResultSlot.Item.stack;
            }else{
                dartResultSlot.Item.stack = 0;
            }
            oldItem = dartResultSlot.Item.Clone();
        }
	}
}