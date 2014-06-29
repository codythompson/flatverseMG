using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace flatverse
{
    public class TestGame : XNAInterface
    {
        private Game1 xnaGame;

        private GraphicsDevice gd;
        private SpriteBatch sb;

        Dictionary<string, FVImage> textures;

        public TextureDrawable DOT;

        public LineDrawable LINE_45, LINE_45_NEG, LINE_VER, LINE_HOR;

        public TextureDrawable BLOCK;

        /*
         * 
         */
        public GameObj main;

        public TestGame()
        {
            textures = new Dictionary<string, FVImage>();
        }

        public virtual void setResolution(GraphicsDeviceManager gdm)
        {
            gdm.PreferredBackBufferWidth = 1200;
            gdm.PreferredBackBufferHeight = 800;
        }

        public virtual void initialize(Game1 xnaGame)
        {
            this.xnaGame = xnaGame;
        }

        public virtual void loadContent(ContentManager contentManager)
        {
            gd = xnaGame.graphics.GraphicsDevice;
            sb = xnaGame.spriteBatch;

            textures["pixel"] = new FVImage(contentManager.Load<Texture2D>("1x1"), null);
            textures["block"] = new FVImage(contentManager.Load<Texture2D>("simpleBlock"), null);
            textures["window"] = new FVImage(contentManager.Load<Texture2D>("blueFramedWindow"), null);

            DOT = new TextureDrawable(textures["pixel"], .4f);
            LINE_45 = new LineDrawable(textures["pixel"], new Vector2(50, 50), .4f);
            LINE_45_NEG = new LineDrawable(textures["pixel"], new Vector2(50, -50), .4f);
            LINE_VER = new LineDrawable(textures["pixel"], new Vector2(0, 50), .4f);
            LINE_HOR = new LineDrawable(textures["pixel"], new Vector2(50, 0), .4f);

            BLOCK = new TextureDrawable(textures["block"], .5f);

            /*
             * 
             */
            Position position = new Position(new Vector2(200, 200));
            main = new GameObj(position, new InputController());
            main.addDrawable(BLOCK.clone());
        }

        public void update(GameTime gameTime)
        {
            main.update();
        }
        public void draw(GameTime gameTime)
        {
            gd.Clear(Color.CornflowerBlue);

            sb.Begin();

            main.draw(sb);

            sb.End();
        }
    }
}