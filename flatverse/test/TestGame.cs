using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace flatverse
{
    public class TestGame : XNAInterface
    {
        private Game1 xnaGame;

        //convenience refs
        private GraphicsDevice gd;
        private SpriteBatch sb;

        Dictionary<string, FVImage> textures;
        List<GameObj> objs = new List<GameObj>();

        List<LineSegment> segments = new List<LineSegment>();
        List<Drawable> segDbls = new List<Drawable>();
        LineSegment moving;
        Drawable movingDbl, dotA;

        float velMag = 5;

        public TestGame()
        {
            textures = new Dictionary<string, FVImage>();
        }

        public void initialize(Game1 xnaGame)
        {
            this.xnaGame = xnaGame;
        }

        public void loadContent(ContentManager contentManager)
        {
            gd = xnaGame.GraphicsDevice;
            sb = xnaGame.spriteBatch;

            textures["pixel"] = new FVImage(contentManager.Load<Texture2D>("1x1"), null);
            textures["block"] = new FVImage(contentManager.Load<Texture2D>("simpleBlock"), null);
            textures["window"] = new FVImage(contentManager.Load<Texture2D>("blueFramedWindow"), null);

            Drawable redDot1 = new TextureDrawable(textures["pixel"], .9f);
            redDot1.scale = new Vector2(4, 4);
            redDot1.color = Color.Red;
            Drawable redDot0 = redDot1.clone();
            redDot0.depth = 0;

            Drawable line = new LineDrawable(textures["pixel"], new Vector2(16, 15), 1);
            line.scale = new Vector2(1, 8);

            Drawable window = new TextureDrawable(textures["window"], .5f);

            objs.Add(new GameObj(200, 200, redDot0));
            objs.Add(new GameObj(216, 216, redDot1));
            objs.Add(new GameObj(192, 192, window));
            objs.Add(new GameObj(200, 200, line));

            Vector2 a = new Vector2(400, 200);
            Vector2 d = new Vector2(0, 200);
            Vector2 r = new Vector2(200, 0);

            //
            dotA = redDot0.clone();
            dotA.depth = .4f;

            moving = new LineSegment(a + new Vector2(20, 20), a + d + r);
            segments.Add(new LineSegment(a, a + r));
            segments.Add(new LineSegment(a, a + d));
            segments.Add(new LineSegment(a, a + (d + r)));

            movingDbl = new LineDrawable(textures["pixel"], d + r, .7f);
            movingDbl.color = Color.Green;
            segDbls.Add(new LineDrawable(textures["pixel"], r, .8f));
            segDbls.Add(new LineDrawable(textures["pixel"], d, .8f));
            segDbls.Add(new LineDrawable(textures["pixel"], d + r, .8f));
        }

        public void update(GameTime gameTime)
        {
            //
            Vector2 vel = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vel.X -= velMag;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                vel.X += velMag;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                vel.Y += velMag;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                vel.Y -= velMag;
            }

            moving += vel;

            // collision
            for (int i = 0; i < segments.Count; i++)
            {
                LineSegment seg = segments[i];
                if (seg.intersects(moving))
                {
                    segDbls[i].color = Color.Red;
                }
                else
                {
                    segDbls[i].color = Color.White;
                }
            }
            //

            foreach(GameObj obj in objs) {
                obj.update();
            }
        }

        public void draw(GameTime gameTime)
        {
            gd.Clear(Color.CornflowerBlue);

            sb.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            foreach (GameObj obj in objs)
            {
                obj.draw(sb);
            }

            movingDbl.simpleDraw(sb, moving.getA());
            dotA.simpleDraw(sb, moving.getA());
            dotA.simpleDraw(sb, moving.getB());
            for (int i = 0; i < segDbls.Count; i++)
            {
                LineSegment seg = segments[i];
                segDbls[i].simpleDraw(sb, seg.getA());
                dotA.simpleDraw(sb, seg.getA());
                dotA.simpleDraw(sb, seg.getB());
            }

            sb.End();
        }
    }
}