using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        }

        public void update(GameTime gameTime)
        {
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

            //spriteBatch.Draw(textures["pixel"], new Vector2(400, 400), null, Color.Gray, 0, pos, scale, SpriteEffects.None, depth);

            sb.End();
        }
    }
}