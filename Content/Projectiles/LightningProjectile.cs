using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using ChargerClass.Content.DamageClasses;
using System.Collections.Generic;
using Terraria.DataStructures;
using System.Linq;

// Taken from: https://code.tutsplus.com/how-to-generate-shockingly-good-2d-lightning-effects--gamedev-2681t

namespace ChargerClass.Content.Projectiles
{
	public class LightningProjectile : ModProjectile
	{
        private static Texture2D LightningTexture = ModContent.Request<Texture2D>("ChargerClass/Content/Projectiles/LightningProjectile").Value;
        private List<Bolt> Bolts;
        public const float lightningMaxLength = 1000;
        private Color color;
        private float alpha = 1f;
		public override void SetDefaults()
		{
            Projectile.width = 1;
            Projectile.height = 4;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = ChargerDamageClass.Instance;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 60;
            Projectile.alpha = 0;
            Projectile.light = 0.0f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
        }
        int originalTimeLeft;
        public override void OnSpawn(IEntitySource source){
            originalTimeLeft = Projectile.timeLeft;
            color = Projectile.ai[1] == 1f ? new Color(0, 174, 238) : Color.MediumPurple;
            Vector2 start = Projectile.position;
            Vector2 end = Main.npc[(int)Projectile.ai[0]].Center;
            Bolts = new();

            var mainBolt = new Bolt(start,  end);
            Bolts.Add(mainBolt);
            if(Projectile.ai[1] == 1f){
                int numBranches = Main.rand.Next(3, 6);
                Vector2 diff = end - start;
                // pick a bunch of random points between 0 and 1 and sort them 
                float[] branchPoints = Enumerable.Range(0, numBranches)
                    .Select(x => Main.rand.NextFloat(0, 1f))
                    .OrderBy(x => x).ToArray();
                for (int i = 0; i < branchPoints.Length; i++)
                {
                    // Bolt.GetPoint() gets the position of the lightning bolt at specified fraction (0 = start of bolt, 1 = end) 
                    Vector2 boltStart = mainBolt.GetPoint(branchPoints[i]);
                    // rotate 30 degrees. Alternate between rotating left and right. 
                    Quaternion rot = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, MathHelper.ToRadians(30 * ((i & 1) == 0 ? 1 : -1)));
                    Vector2 boltEnd = Vector2.Transform(diff * (1 - branchPoints[i]) * Main.rand.NextFloat(0.25f, 0.75f), rot) + boltStart;
                    Bolts.Add(new Bolt(boltStart, boltEnd));
                }
            }
            Main.player[Projectile.owner].addDPS(Main.npc[(int)Projectile.ai[0]].SimpleStrikeNPC(Projectile.damage, Projectile.position.X > Main.npc[(int)Projectile.ai[0]] .position.X? -1 : 1, damageVariation: true));
        }
        

        public override void AI(){
            alpha = (float)Projectile.timeLeft / originalTimeLeft;
        }

        public override bool PreDraw(ref Color lightColor) {
            if(Bolts is not null) foreach (Bolt bolt in Bolts) bolt.Draw(color * alpha, Projectile.scale);
            return false;
		}
        class Segment
        {
            public Vector2 StartPos;
            public Vector2 EndPos;
            public Segment(Vector2 startPos, Vector2 endPos){
                StartPos = startPos;
                EndPos = endPos;
            }
            public void Draw(Color color, float scale){
                Vector2 tangent = EndPos - StartPos;
                float rotation = tangent.ToRotation();
                Vector2 newScale = new Vector2(tangent.Length(), scale);

                Main.EntitySpriteDraw(LightningTexture, StartPos - Main.screenPosition, new Rectangle(2,0,1,LightningTexture.Width), color, rotation, Vector2.Zero, newScale, SpriteEffects.None, 0f);
                Main.EntitySpriteDraw(LightningTexture, StartPos - Main.screenPosition, new Rectangle(0,0,2,LightningTexture.Width), color, rotation, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                Main.EntitySpriteDraw(LightningTexture, EndPos - Main.screenPosition, new Rectangle(0,0,2,LightningTexture.Width), color, rotation, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);

                DelegateMethods.v3_1 = color.ToVector3();
			    Utils.PlotTileLine(StartPos, EndPos, LightningTexture.Height * 6, DelegateMethods.CastLight);
            }
        }

        class Bolt{
            public List<Segment> Segments;
            public Bolt(Vector2 origin, Vector2 destination){
                Segments = new List<Segment>();

                Vector2 tangent = destination - origin;
                Vector2 normal = Vector2.Normalize(new Vector2(tangent.Y, -tangent.X));
                float length = tangent.Length();

                //initialize list of random points from 0-1 sorted by position
                List<float> positions = new List<float>();
                positions.Add(0);
                for (int i = 0; i < length / 4; i++) positions.Add(Main.rand.NextFloat(0, 1));
                positions.Sort();

                const float Sway = 200;
                const float Jaggedness = 1 / Sway;
                Vector2 prevPoint = origin;
                float prevDisplacement = 0;
                for (int i = 1; i < positions.Count; i++)
                {
                    float segmentPercent = positions[i] - positions[i - 1];
                    float scale = length * Jaggedness * segmentPercent;
                    // envelope approaches zero when position > 0.95. this negates displacement so the endpoint will be correct
                    float envelope = positions[i] > 0.95f ? 20 * (1 - positions[i]) : 1;
                    float displacement = Main.rand.NextFloat(-Sway, Sway);
                    displacement -= (displacement - prevDisplacement) * (1 - scale);
                    displacement *= envelope;

                    Vector2 point = origin + positions[i] * tangent + displacement * normal;
                    Segments.Add(new Segment(prevPoint, point));
                    prevPoint = point;
                    prevDisplacement = displacement;
                }
                Segments.Add(new Segment(prevPoint, destination));
            }

            public Vector2 GetPoint(float percent) => Segments[(int)(Segments.Count * percent)].StartPos;

            public void Draw(Color color, float scale){
                foreach(Segment segment in Segments) segment.Draw(color, scale);
            }
        }
	}
}