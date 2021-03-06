﻿using System;
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

        public SpriteFont defaultFont;
        public static TextDrawable DEBUG_STRING;

        public TextureDrawable DOT;

        public LineDrawable LINE_45, LINE_45_NEG, LINE_VER, LINE_HOR;

        public TextureDrawable BLOCK, WINDOW;

        public CollisionManager collMan;

        /*
         * 
         */
        int updateCtr = 0;

        public GameObj main;

        List<GameObj> others;

        public TestGame()
        {
            textures = new Dictionary<string, FVImage>();
            collMan = new CollisionManager(3);
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

            defaultFont = contentManager.Load<SpriteFont>("monospace");
            TestGame.DEBUG_STRING = new TextDrawable(defaultFont, " - ", 1);
            TestGame.DEBUG_STRING.scale = new Vector2(0.25f);
            //TestGame.DEBUG_STRING.color = Utils.colorFromUInt(0xaaffffff);
            TestGame.DEBUG_STRING.color = Color.White;

            DOT = new TextureDrawable(textures["pixel"], .4f);
            LINE_45 = new LineDrawable(textures["pixel"], new Vector2(50, 50), .4f);
            LINE_45_NEG = new LineDrawable(textures["pixel"], new Vector2(50, -50), .4f);
            LINE_VER = new LineDrawable(textures["pixel"], new Vector2(0, 50), .4f);
            LINE_HOR = new LineDrawable(textures["pixel"], new Vector2(50, 0), .4f);

            BLOCK = new TextureDrawable(textures["block"], .5f);

            WINDOW = new TextureDrawable(textures["window"], .4f);

            /*
             * 
             */
            Position position = new Position(new Vector2(200, 200));
            main = new GameObj(position, new DEBUG_CONTROLLER());
            main.addDrawable(BLOCK.clone());
            main.dbls[0].color = Color.ForestGreen; 
            main.addCollider(new DebugCollider(new Vector2(32, 32), "player"));
            collMan.registerColliders(main, 0, false);
            collMan.registerColliders(main, 1, true);
            collMan.registerColliders(main, 2, false);

            // others
            others = new List<GameObj>();

            GameObj other = new GameObj(new Position(new Vector2(700, 300)), new Controller());
            other.addDrawable(LINE_45_NEG.clone());
            other.addCollider(new LineSegmentCollider(new Vector2(50, -50), Vector2.Zero));
            collMan.registerColliders(other, 0, true);
            others.Add(other);

            other = new GameObj(new Position(400, 400), new Controller());
            other.addDrawable(BLOCK.clone());
            other.dbls[0].color = Color.SandyBrown;
            other.addCollider(new RectangleCollider(new Vector2(32, 32)));
            collMan.registerColliders(other, 1, false);
            collMan.registerColliders(other, 2, false);
            others.Add(other);

            other = new GameObj(new Position(568, 400), new Controller());
            other.addDrawable(BLOCK.clone());
            other.dbls[0].color = Color.Yellow;
            other.addCollider(new RectangleCollider(new Vector2(32, 32)));
            collMan.registerColliders(other, 0, true);
            others.Add(other);

            other = new GameObj(new Position(536, 400), new Controller());
            other.addDrawable(WINDOW.clone());
            other.addCollider(new RectangleCollider(new Vector2(32, 32)));
            collMan.registerColliders(other, 0, true);
            others.Add(other);

            int initX = 100;
            for (int i = 0; i < 32 * 2; i += 32)
            {
                other = new GameObj(new Position(i + initX, 600), new Controller());
                other.addDrawable(BLOCK.clone());
                Color color = Color.Yellow;
                //color.A = (byte)i;
                //if (i > 255)
                //{
                //    color.A = (byte)(i - 255);
                //}
                other.dbls[0].color = color;
                other.addCollider(new DebugCollider(new Vector2(32, 32), i + "_other"));
                collMan.registerColliders(other, 1, false);
                others.Add(other);
            }

            other = new GameObj(new Position(600, 500),
                new PointPathController(new Vector2[]{new Vector2(700, 500), new Vector2(1000, 500), new Vector2(1000, 700), new Vector2(500, 700)}, 5));
            other.addDrawable(BLOCK.clone());
            other.dbls[0].color = Color.DarkSlateBlue;
            other.addCollider(new DebugCollider(new Vector2(32, 32), "mover"));
            collMan.registerColliders(other, 0, true);
            others.Add(other);

            other = new GameObj(new Position(950, 500), new Controller());
            other.addDrawable(BLOCK.clone());
            other.dbls[0].color = Color.Azure;
            other.addCollider(new DebugCollider(new Vector2(32, 32), "wall"));
            collMan.registerColliders(other, 2, true);
            others.Add(other);

            other = new GameObj(new Position(1000, 100), new Controller());
            other.addDrawable(LINE_45_NEG.clone());
            other.dbls[0].color = Color.DarkOliveGreen;
            other.addCollider(new OneWayCollider(OneWayCollider.Direction.DOWN, new Vector2(50, -50)));
            collMan.registerColliders(other, 0, true);
            others.Add(other);
        }

        public void update(GameTime gameTime)
        {
            updateCtr++;
            main.update();
            foreach (GameObj other in others)
            {
                other.update();
            }

            // collision
            collMan.collide();

            DEBUG_STRING.text = string.Format("{0}, {1}", main.position.pos.X, main.position.pos.Y);
        }
        public void draw(GameTime gameTime)
        {
            gd.Clear(Color.CornflowerBlue);

            sb.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);

            DEBUG_STRING.simpleDraw(sb, Vector2.Zero);

            main.draw(sb);
            foreach (GameObj other in others)
            {
                other.draw(sb);
            }

            sb.End();
        }
    }
}