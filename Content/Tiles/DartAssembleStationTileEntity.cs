using System;
using ChargerClass.Common.ModSystems;
using ChargerClass.Content.Tiles;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

public class DartAssemblyStationTileEntity : ModTileEntity
	{
        public int[] ComponentTypes = new int[4], ComponentCounts = new int[4];

		public void UpdateData(){
			ComponentTypes = DartAssemblyStationUISystem.Instance.DartAssemblyState.ComponentTypes;
			ComponentCounts = DartAssemblyStationUISystem.Instance.DartAssemblyState.ComponentCounts;
		}
		public override void SaveData(TagCompound tag) {
			UpdateData();
			tag["Types"] = ComponentTypes;
            tag["Counts"] = ComponentCounts;
		}

		public override void LoadData(TagCompound tag) {
			ComponentTypes = tag.Get<int[]>("Types");
			ComponentCounts = tag.Get<int[]>("Counts");
			UpdateData();
		}

		public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction, int alterate) {
			if (Main.netMode == NetmodeID.MultiplayerClient) {
				NetMessage.SendTileSquare(Main.myPlayer, i, j, 3);
				NetMessage.SendData(MessageID.TileEntityPlacement, -1, -1, null, i, j, Type, 0f, 0, 0, 0);
				return -1;
			}
			return Place(i, j);
		}
		public override void OnPlayerUpdate(Player player){
			Main.NewText(ComponentCounts[0]);
			if(player.whoAmI != Main.myPlayer) return;
			float x = player.position.X - Position.X * 16;
			float y = player.position.Y - Position.Y * 16;
			if(Main.keyState.IsKeyDown(Keys.Escape) && !Main.oldKeyState.IsKeyDown(Keys.Escape) || Math.Sqrt(x * x + y * y) > 150){
				BasicOpenCloseInteraction(player, Position.X, Position.Y, ID);	
				DartAssemblyStationUISystem.Instance.HideUI();
				ComponentTypes = DartAssemblyStationUISystem.Instance.DartAssemblyState.ComponentTypes;
				ComponentCounts = DartAssemblyStationUISystem.Instance.DartAssemblyState.ComponentCounts;
			}
		}

	public override bool IsTileValidForEntity(int x, int y){
        Tile tile = Main.tile[x, y];
		return tile.HasTile && tile.TileType == ModContent.TileType<DartAssemblyStationTile>() && tile.TileFrameX == 0 && tile.TileFrameY == 0;
    }
}