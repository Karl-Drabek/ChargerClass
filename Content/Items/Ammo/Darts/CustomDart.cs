using System;
using System.Collections.Generic;
using System.IO;
using ChargerClass.Common.Players;
using ChargerClass.Content.DamageClasses;
using ChargerClass.Content.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ChargerClass.Content.Items.Ammo.Darts;

public class CustomDart : ModItem
{
	public DartComponent Tail,
		Payload,
		Tip;

	private int[] ComponentTypes;
	public int pen;
	private Texture2D texture => TextureAssets.Item[Type].Value;
	public override string Texture => "ChargerClass/Content/Items/Ammo/Darts/DartSheet";
	private static readonly int tailHeight = 10,
		payloadHeight = 14,
		tipHeight = 10,
		width = 10;

	public bool HasComponents
	{
		get => Tail is not null && Payload is not null && Tip is not null;
	}

	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 0;
	}

	public override void SetDefaults()
	{
		Item.width = width;
		Item.height = tailHeight + payloadHeight + tipHeight;
		Item.DamageType = ChargerDamageClass.Instance;
		Item.maxStack = 999;
		Item.consumable = true;
		Item.shoot = ModContent.ProjectileType<CustomDartProjectile>();
		Item.ammo = AmmoID.Dart;
		Item.scale = 1f;

		ComponentTypes = new int[3];
	}

	public void ResetDefaults(DartComponent tail, DartComponent payload, DartComponent tip)
	{
		Tail = tail;
		Payload = payload;
		Tip = tip;

		ComponentTypes[0] = tail.Item.type;
		ComponentTypes[1] = payload.Item.type;
		ComponentTypes[2] = tip.Item.type;
		syncComponents();

		InternalResetDefaults();
	}

	public void ResetDefaults()
	{
		var tail = new Item();
		tail.SetDefaults(ComponentTypes[0]);
		Tail = tail.ModItem as DartComponent;
		var payload = new Item();
		payload.SetDefaults(ComponentTypes[1]);
		Payload = payload.ModItem as DartComponent;
		var tip = new Item();
		tip.SetDefaults(ComponentTypes[2]);
		Tip = tip.ModItem as DartComponent;

		InternalResetDefaults();
	}

	private void InternalResetDefaults()
	{
		Item.shootSpeed = Tail.Item.shootSpeed;
		Item.damage = Tip.Item.damage;
		Item.knockBack = Tip.Item.knockBack;
		Item.rare = Tail.Item.rare > Payload.Item.rare ? Tail.Item.rare : Payload.Item.rare;
		Item.rare = Item.rare > Tip.Item.rare ? Item.rare : Tip.Item.rare;
		Item.value = Tail.Item.value + Payload.Item.value + Tip.Item.value;

		pen = ((DartComponent)Tip.Item.ModItem).Pen;

		Item.NetStateChanged();
	}

	public override void NetSend(BinaryWriter writer)
	{
		writer.Write(ComponentTypes[0]);
		writer.Write(ComponentTypes[1]);
		writer.Write(ComponentTypes[2]);
	}

	public override void NetReceive(BinaryReader reader)
	{
		ComponentTypes[0] = reader.ReadInt32();
		ComponentTypes[1] = reader.ReadInt32();
		ComponentTypes[2] = reader.ReadInt32();
		ResetDefaults();
	}

	public void syncComponents()
	{
		NetMessage.SendData(MessageID.SyncItem, -1, -1, null, Item.whoAmI, 1f);
	}

	public override void SaveData(TagCompound tag)
	{
		tag["Components"] = ComponentTypes;
	}

	public override void LoadData(TagCompound tag)
	{
		ComponentTypes = tag.Get<int[]>("Components");
		syncComponents();
		ResetDefaults();
		syncComponents();
	}

	public override void PickAmmo(
		Item weapon,
		Player player,
		ref int type,
		ref float speed,
		ref StatModifier damage,
		ref float knockback
	)
	{
		ChargeModPlayer modPlayer = player.GetModPlayer<ChargeModPlayer>();
		modPlayer.TailForCustomDart = Tail is null ? 0 : Tail.Type;
		modPlayer.PayloadForCustomDart = Payload is null ? 0 : Payload.Type;
		modPlayer.TipForCustomDart = Tip is null ? 0 : Tip.Type;
	}

	public override void ModifyTooltips(List<TooltipLine> tooltips)
	{
		if (!HasComponents)
			return;
		int i = 0;
		foreach (var line in tooltips)
		{
			if (line.Name == "ItemName")
			{
				line.Text =
					Language.GetText($"Mods.ChargerClass.DartNameSection.{Tail.Name}").Value
					+ Language.GetText($"Mods.ChargerClass.DartNameSection.{Payload.Name}").Value
					+ Language.GetText($"Mods.ChargerClass.DartNameSection.{Tip.Name}").Value;
			}
			else if (line.Name == "Tooltip0")
			{
				int tooltipLine = 0;
				tooltips.Remove(line);

				string tailTooltip = Language
					.GetText($"Mods.ChargerClass.Items.{Tail.Name}.Tooltip")
					.Value;
				string payloadTooltip = Language
					.GetText($"Mods.ChargerClass.Items.{Payload.Name}.Tooltip")
					.Value;
				string tipTooltip = Language
					.GetText($"Mods.ChargerClass.Items.{Tip.Name}.Tooltip")
					.Value;

				if (tailTooltip != string.Empty)
					tooltips.Insert(
						i + tooltipLine,
						new TooltipLine(Mod, $"Tooltip{tooltipLine++}", tailTooltip)
					);
				if (payloadTooltip != string.Empty)
					tooltips.Insert(
						i + tooltipLine,
						new TooltipLine(Mod, $"Tooltip{tooltipLine++}", payloadTooltip)
					);
				if (tipTooltip != string.Empty)
					tooltips.Insert(
						i + tooltipLine,
						new TooltipLine(Mod, $"Tooltip{tooltipLine++}", tipTooltip)
					);
				return;
			}
			i++;
		}
	}

	public override bool CanStack(Item source)
	{
		if (!HasComponents)
			return false;
		if (source.ModItem is not CustomDart dart || !dart.HasComponents)
			return false;
		return dart.Tail.Item.type == this.Tail.Item.type
			&& dart.Payload.Item.type == this.Payload.Item.type
			&& dart.Tip.Item.type == this.Tip.Item.type;
	}

	public override bool PreDrawInInventory(
		SpriteBatch spriteBatch,
		Vector2 position,
		Rectangle frame,
		Color drawColor,
		Color itemColor,
		Vector2 origin,
		float scale
	)
	{
		scale *= Item.scale * 5f;
		origin = new Vector2(width, tipHeight + payloadHeight + tailHeight) / 2;

		int id = Tip is null ? 0 : Tip.DartSheetPlacement;
		frame = new Rectangle(id * (width + 2), 0, width, tipHeight);
		spriteBatch.Draw(
			texture,
			position,
			frame,
			drawColor,
			0f,
			origin,
			scale,
			SpriteEffects.None,
			0f
		);

		position.Y += tipHeight * scale;
		id = Payload is null ? 0 : Payload.DartSheetPlacement;
		frame = new Rectangle(id * (width + 2), tipHeight + 2, width, payloadHeight);
		spriteBatch.Draw(
			texture,
			position,
			frame,
			drawColor,
			0f,
			origin,
			scale,
			SpriteEffects.None,
			0f
		);

		position.Y += payloadHeight * scale;
		id = Tail is null ? 0 : Tail.DartSheetPlacement;
		frame = new Rectangle(id * (width + 2), payloadHeight + tipHeight + 4, width, tailHeight);
		spriteBatch.Draw(
			texture,
			position,
			frame,
			drawColor,
			0f,
			origin,
			scale,
			SpriteEffects.None,
			0f
		);

		return false;
	}

	public override bool PreDrawInWorld(
		SpriteBatch spriteBatch,
		Color lightColor,
		Color alphaColor,
		ref float rotation,
		ref float scale,
		int whoAmI
	)
	{
		var origin = new Vector2(width, tipHeight + payloadHeight + tailHeight) / 2;
		Vector2 position = Item.position + origin;
		Vector2 normal = new(-(float)Math.Sin(rotation), (float)Math.Cos(rotation));

		int id = Tip is null ? 0 : Tip.DartSheetPlacement;
		var frame = new Rectangle(id * (width + 2), 0, width, tipHeight);
		spriteBatch.Draw(
			texture,
			position - Main.screenPosition,
			frame,
			lightColor,
			rotation,
			origin,
			scale,
			SpriteEffects.None,
			0f
		);

		position += normal * (tipHeight * Item.scale);
		id = Payload is null ? 0 : Payload.DartSheetPlacement;
		frame = new Rectangle(id * (width + 2), tipHeight + 2, width, payloadHeight);
		spriteBatch.Draw(
			texture,
			position - Main.screenPosition,
			frame,
			lightColor,
			rotation,
			origin,
			scale,
			SpriteEffects.None,
			0f
		);

		position += normal * (payloadHeight * Item.scale);
		id = Tail is null ? 0 : Tail.DartSheetPlacement;
		frame = new Rectangle(id * (width + 2), payloadHeight + tipHeight + 4, width, tailHeight);
		spriteBatch.Draw(
			texture,
			position - Main.screenPosition,
			frame,
			lightColor,
			rotation,
			origin,
			scale,
			SpriteEffects.None,
			0f
		);

		return false;
	}
}
