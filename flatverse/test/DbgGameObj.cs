﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class DbgGameObj : GameObj
    {
        public Drawable ptDbl;
        //public LineDrawable lineDbl;
        public Polygon collPath;

        public DbgGameObj(Position position, Controller controller, Drawable ptDbl/*, LineDrawable lineDbl*/)
            : base(position, controller)
        {
            this.ptDbl = ptDbl;
            //this.lineDbl = lineDbl;
            //addDrawable(this.ptDbl);
            //addDrawable(this.lineDbl);
        }

        public override void update()
        {
            base.update();

            //if (DEBUG_CONTROLLER.DEBUG_FLAG_UP && getColliderCount() > 0)
            //{
            //    collPath = getCollider(0).getCollisionPath();
            //}
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);

            if (collPath != null)
            {
                foreach (Vector2 pt in collPath.points())
                {
                    ptDbl.simpleDraw(spriteBatch, pt);
                }
            }
        }
    }
}