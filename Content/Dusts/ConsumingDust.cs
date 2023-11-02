using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ChargerClass.Content.Dusts;

public class ConsumingDust : ModDust
{
        public override void OnSpawn(Dust dust) {
		dust.color = Color.Purple;
	}
	public override bool Update(Dust dust) { // Calls every frame the dust is active
            Vector2 dustToPlayer = Main.LocalPlayer.position - dust.position;
            Vector2 dirToMouse = Vector2.Normalize(Main.MouseScreen + Main.screenPosition - dust.position);
            dust.position += Vector2.Normalize(Vector2.Normalize(dustToPlayer) * 10 + dirToMouse * 4f) * 10;

		dust.rotation += dust.velocity.X * 0.15f;

            float len = dustToPlayer.Length();
            dust.scale = len / (len + 150f);

            if(dust.scale < 0.1f) dust.active = false;

		Lighting.AddLight(dust.position, 1f, 1f, 1f);
		return false;
	}
}