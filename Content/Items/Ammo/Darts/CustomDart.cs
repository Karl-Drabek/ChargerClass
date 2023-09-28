using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles; 
using Terraria.DataStructures;
using ChargerClass.Content.Items;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System.Collections.Generic;
using Terraria.ModLoader.IO;

namespace ChargerClass.Content.Items.Ammo.Darts
{
	public class CustomDart : ModItem
	{
        public DartComponent Tail, Payload, Tip;

        private int[] ComponentTypes;
        public int pen;
        private Texture2D texture;
        private static readonly int tailHeight = 10, payloadHeight = 14, tipHeight = 10, width = 10;

        public bool HasComponents{
            get => Tail is not null && Payload is not null && Tip is not null;
        }

        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 0;
        }

        public override void SetDefaults() {
            Item.width = 20;
            Item.height = 42;
            Item.DamageType = ChargerDamageClass.Instance;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<CustomDartProjectile>();
            Item.ammo = AmmoID.Dart;
            Item.scale = 1f;

            texture = ModContent.Request<Texture2D>("ChargerClass/Content/Items/Ammo/Darts/CustomDart").Value;
            ComponentTypes = new int[3];
        }

        public void ResetDefaults(DartComponent tail, DartComponent payload, DartComponent tip){
            Tail = tail;
            Payload = payload;
            Tip = tip;

            ComponentTypes[0] = Tail.Item.type;
            ComponentTypes[1] = Payload.Item.type;
            ComponentTypes[2] = Tip.Item.type;

            Item.shootSpeed = tail.Item.shootSpeed;
            Item.damage = tip.Item.damage;
            Item.knockBack = tip.Item.knockBack;
            Item.rare = tail.Item.rare > payload.Item.rare ? tail.Item.rare : payload.Item.rare;
            Item.rare = Item.rare > tip.Item.rare ? Item.rare : tip.Item.rare;
            Item.value = tail.Item.value + payload.Item.value + tip.Item.value;
        }

        public override void SaveData(TagCompound tag) {
			tag["Components"] = ComponentTypes;
		}

		public override void LoadData(TagCompound tag) {
			ComponentTypes = tag.Get<int[]>("Components");
            var tail = new Item();
            tail.SetDefaults(ComponentTypes[0]);
            var payload = new Item();
            payload.SetDefaults(ComponentTypes[1]);
            var tip = new Item();
            tip.SetDefaults(ComponentTypes[2]);

            ResetDefaults(tail.ModItem as DartComponent, payload.ModItem as DartComponent, tip.ModItem as DartComponent);
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips){
            foreach(var line in tooltips){
                if(line.Name == "ItemName" && HasComponents){
                    line.Text = Language.GetText($"Mods.ChargerClass.DartNameSection.{Tail.Name}").Value +
                        Language.GetText($"Mods.ChargerClass.DartNameSection.{Payload.Name}").Value +
                        Language.GetText($"Mods.ChargerClass.DartNameSection.{Tip.Name}").Value;
                }
            }
        }


        public override bool CanStack(Item source){
            if(!HasComponents) return false;
            if(source.ModItem is not CustomDart dart || !dart.HasComponents) return false;
            return dart.Tail.Item.type == this.Tail.Item.type && dart.Payload.Item.type == this.Payload.Item.type && dart.Tip.Item.type == this.Tip.Item.type;
        }
        
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale){
            scale *= Item.scale * 5f;
            origin = new Vector2(width, tipHeight + payloadHeight + tailHeight) / 2;
            
            int id = Tip is null? 0 : Tip.Item.type - ModContent.ItemType<Tips.HypodermicNeedle>();
            frame = new Rectangle(id * (width + 2), 0, width, tipHeight);
            spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);

            position.Y += tipHeight * scale;
            id = Payload is null? 0 : Payload.Item.type - ModContent.ItemType<Payloads.DartCannister>();
            frame = new Rectangle(id * (width + 2),  tipHeight + 2, width, payloadHeight);
            spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);

            position.Y += payloadHeight * scale;
            id = Tail is null? 0 : Tail.Item.type - ModContent.ItemType<Tails.FeatheredTail>();
            frame = new Rectangle(id * (width + 2), payloadHeight + tipHeight + 4, width, tailHeight);
            spriteBatch.Draw(texture, position, frame, drawColor, 0f, origin,   scale, SpriteEffects.None, 0f);

            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI){
            Main.NewText("test");
            var origin = new Vector2(width, tipHeight + payloadHeight + tailHeight) / 2;
            
            int id = Tip is null? 0 : Tip.Item.type - ModContent.ItemType<Tips.HypodermicNeedle>();
            var frame = new Rectangle(id * (width + 2), 0, width, tipHeight);
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, frame, Color.White, rotation, origin, Item.scale, SpriteEffects.None, 0f);

            Item.position.Y += tipHeight * Item.scale;
            id = Payload is null? 0 : Payload.Item.type - ModContent.ItemType<Payloads.DartCannister>();
            frame = new Rectangle(id * (width + 2),  tipHeight + 2, width, payloadHeight);
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, frame, Color.White, rotation, origin, Item.scale, SpriteEffects.None, 0f);

            Item.position.Y += payloadHeight * Item.scale;
            id = Tail is null? 0 : Tail.Item.type - ModContent.ItemType<Tails.FeatheredTail>();
            frame = new Rectangle(id * (width + 2), payloadHeight + tipHeight + 4, width, tailHeight);
            spriteBatch.Draw(texture, Item.position - Main.screenPosition, frame, Color.White, rotation, origin, Item.scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}