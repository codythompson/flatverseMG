//using System;
//using System.Collections.Generic;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace flatverse
//{
//    public class TestGame2 : XNAInterface
//    {
//        private Game1 xnaGame;

//        private GraphicsDevice gd;
//        private SpriteBatch sb;

//        Dictionary<string, FVImage> textures;
//        List<GameObj> objs = new List<GameObj>();

//        GameObj main;

//        Vector2 mainLineDelt;

//        Polygon tP;
//        DrawableCollection tpds;

//        GameObj collA;

//        GridDrawable gDbl;

//        public TestGame2()
//        {
//            textures = new Dictionary<string, FVImage>();
//        }

//        public void setResolution(GraphicsDeviceManager gdm)
//        {
//            gdm.PreferredBackBufferWidth = 1200;
//            gdm.PreferredBackBufferHeight = 800;
//        }

//        public void initialize(Game1 xnaGame)
//        {
//            this.xnaGame = xnaGame;
//        }

//        public void loadContent(ContentManager contentManager)
//        {
//            gd = xnaGame.graphics.GraphicsDevice;
//            sb = xnaGame.spriteBatch;

//            textures["pixel"] = new FVImage(contentManager.Load<Texture2D>("1x1"), null);
//            textures["block"] = new FVImage(contentManager.Load<Texture2D>("simpleBlock"), null);
//            textures["window"] = new FVImage(contentManager.Load<Texture2D>("blueFramedWindow"), null);

//            Drawable dot = new TextureDrawable(textures["pixel"], .4f);
//            dot.color = Color.Green;
//            dot.scale = new Vector2(4, 4);
//            mainLineDelt = new Vector2(20, 30);
//            Drawable lineD = new LineDrawable(textures["pixel"], mainLineDelt, 0.2f);
//            main = new DbgGameObj(new DEBUG_CONTROLLER(new Vector2(200, 50)), dot.clone());
//            main.addDrawable(lineD);
//            main.addCollider(new LineSegmentCollider(mainLineDelt, Vector2.Zero, 1));

//            Vector2 collADelt = new Vector2(100, -150);
//            Drawable collADbl = new LineDrawable(textures["pixel"], collADelt, 0.01f);
//            collADbl.color = Color.Purple;
//            Collider collACol = new LineSegmentCollider(collADelt, Vector2.Zero, 2);
//            collA = new GameObj(new Controller(new Vector2(400, 400)), collADbl);
//            collA.addCollider(collACol);

//            Vector2[] pPts = new Vector2[5];
//            pPts[0] = new Vector2(200, 200);
//            pPts[1] = pPts[0] + new Vector2(50, 100);
//            pPts[2] = pPts[1] + new Vector2(-50, 0);
//            pPts[3] = pPts[2] + new Vector2(50, 50);
//            pPts[4] = pPts[3] + new Vector2(-150, 75);
//            tP = new Polygon(pPts);

//            LineSegment[] tpLines = tP.segments();
//            Drawable[] tpDbls = new Drawable[tpLines.Length];
//            for (var i = 0; i < tpLines.Length; i++)
//            {
//                LineSegment line = tpLines[i];
//                LineDrawable ldbl = new LineDrawable(textures["pixel"], line.getB() - line.getA(), .5f);
//                ldbl.offset = line.getA() - pPts[0];
//                tpDbls[i] = ldbl;
//            }
//            tpds = new DrawableCollection(tpDbls, .5f);

//            gDbl = new GridDrawable(textures["pixel"], 12, 8, 1200, 800, .9f, 100, 100);
//            gDbl.color = Color.LightGray;
//        }

//        public void update(GameTime gameTime)
//        {
//            main.update();

//            collA.getColliders()[0].collideAway(main.getColliders()[0]);

//            if (tP.intersects(new LineSegment(main.getPos(), main.getPos() + mainLineDelt)))
//            {
//                tpds.color = Color.Red;
//            }
//            else
//            {
//                tpds.color = Color.White;
//            }
//        }

//        public void draw(GameTime gameTime)
//        {
//            gd.Clear(Color.CornflowerBlue);

//            sb.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

//            main.draw(sb);
//            collA.draw(sb);
//            tpds.simpleDraw(sb, tP.segments()[0].getA());
//            gDbl.simpleDraw(sb, Vector2.Zero);

//            sb.End();
//        }
//    }
//}