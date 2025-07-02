using ChargerClass.Common.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace ChargerClass.Content.UI.ChargeStats;

class ChargeStatsState : UIState
{
	DraggableUIPanel panel;
	UIText maxChargeText;
	UIText chargeSpeedText;
	UIText chargeDamageText;
	UIText chargeKnockbackText;
	UIText chargeCritText;
	UIText chargeLevelText;
	UIText projectileSpeedText;

	public override void OnInitialize()
	{
		panel = new DraggableUIPanel();
		panel.Width.Set(300, 0);
		panel.Height.Set(250, 0);
		panel.BackgroundColor = new Color(73, 94, 171, 150);
		panel.HAlign = panel.VAlign = 0.5f;
		Append(panel);

		maxChargeText = new UIText($"Max Charge: ");
		maxChargeText.HAlign = 0.1f;
		maxChargeText.VAlign = 0.1f;
		panel.Append(maxChargeText);

		chargeSpeedText = new UIText($"Charge Speed: ");
		chargeSpeedText.HAlign = 0.1f;
		chargeSpeedText.VAlign = 0.2f;
		panel.Append(chargeSpeedText);

		chargeDamageText = new UIText($"Charge Damage: ");
		chargeDamageText.HAlign = 0.1f;
		chargeDamageText.VAlign = 0.3f;
		panel.Append(chargeDamageText);

		chargeCritText = new UIText($"Crit Chance: ");
		chargeCritText.HAlign = 0.1f;
		chargeCritText.VAlign = 0.4f;
		panel.Append(chargeCritText);

		chargeKnockbackText = new UIText($"Knockback: ");
		chargeKnockbackText.HAlign = 0.1f;
		chargeKnockbackText.VAlign = 0.5f;
		panel.Append(chargeKnockbackText);

		projectileSpeedText = new UIText($"Projectile Speed: ");
		projectileSpeedText.HAlign = 0.1f;
		projectileSpeedText.VAlign = 0.6f;
		panel.Append(projectileSpeedText);

		chargeLevelText = new UIText($"Charge Level: ");
		chargeLevelText.HAlign = 0.1f;
		chargeLevelText.VAlign = 0.7f;
		panel.Append(chargeLevelText);

		var header = new UIText("Charge Stats");
		header.HAlign = 0.5f;
		header.VAlign = 0.0f;
		panel.Append(header);
	}

	public override void Update(GameTime gameTime)
	{
		panel.Update(gameTime);

		Player player = Main.LocalPlayer;
		ChargeModPlayer modPlayer = player?.GetModPlayer<ChargeModPlayer>();
		Item item = player?.HeldItem;

		int maxCharge = modPlayer == null ? 0 : modPlayer.GetMaxCharge();
		maxChargeText.SetText($"Max Charge:       +{maxCharge / 10 - 100}%");

		float chargeSpeed = modPlayer == null ? 0 : 100 * ((1 / modPlayer.UseTimeMultiplier(item)) - 1);
		chargeSpeedText.SetText($"Charge Speed:     +{(int)chargeSpeed}%");

		StatModifier damageModifier = StatModifier.Default;
		modPlayer?.ModifyWeaponDamage(item, ref damageModifier);
		chargeDamageText.SetText($"Charge Damage:   +{(int)damageModifier.ApplyTo(100) - 100}%");

		StatModifier knockbackModifier = StatModifier.Default;
		modPlayer?.ModifyWeaponKnockback(item, ref knockbackModifier);
		chargeKnockbackText.SetText($"Knockback:        +{(int)knockbackModifier.ApplyTo(100) - 100}%");

		float crit = item == null ? 0 : item.crit;
		modPlayer?.ModifyWeaponCrit(item, ref crit);
		chargeCritText.SetText($"Crit Chance:       +{(int)crit}%");

		int chargeLevel = 0;
		modPlayer?.ModifyChargeLevel(ref chargeLevel, 0);
		chargeLevelText.SetText($"Charge Level:     +{chargeLevel}");

		Vector2 velocity = new(0, 100);
		modPlayer?.ModifyProjectileSpeed(ref velocity);
		projectileSpeedText.SetText($"Projectile Speed:  +{(int)velocity.Y - 100}%");
	}
}
