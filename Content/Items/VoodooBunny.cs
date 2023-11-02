using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using ChargerClass.Content.Projectiles;
using Terraria.DataStructures;
using ChargerClass.Content.Items.Weapons;

namespace ChargerClass.Content.Items
{
	public class VoodooBunny : ModItem
	{
        public override string Texture => $"Terraria/Images/Item_{ItemID.Bunny}";
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 25;
            ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
        }

        public override void SetDefaults() {
            Item.width = 8;
            Item.height = 7;

            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes() {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.Bunny, 1);
            recipe.AddIngredient(ItemID.GuideVoodooDoll, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }

		public override void Update(ref float gravity, ref float maxFallSpeed){
            if(Item.lavaWet){
                if(Main.LocalPlayer.ZoneUnderworldHeight) for(int i = 0; i < Item.stack; i++) Item.NewItem(new EntitySource_Parent(Item), Item.position, ModContent.ItemType<BunnyGun>());
                Item.active = false;
            }
        }
	}
}