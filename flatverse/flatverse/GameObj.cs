using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class GameObj
    {
        public List<Drawable> dbls;

        protected Vector2 pos, prevPos;

        public GameObj(Vector2 initialPos, List<Drawable> dbls)
        {
            pos = initialPos;
            prevPos = initialPos;
            this.dbls = dbls;
        }

        public GameObj(Vector2 initialPos, Drawable dbl)
            : this(initialPos, new List<Drawable>())
        {
            dbls.Add(dbl);
        }

        public GameObj(float x, float y, List<Drawable> dbls)
            : this(new Vector2(x, y), dbls)
        {}

        public GameObj(float x, float y, Drawable dbl)
            : this(x, y, new List<Drawable>())
        {
            dbls.Add(dbl);
        }

        public virtual void update()
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.update();
            }

            prevPos = pos;
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.simpleDraw(spriteBatch, getPos());
            }
        }

        /*
         * Getters and setters
         */
        public virtual Vector2 getPos()
        {
            return pos;
        }
        public virtual void setPos(Vector2 pos)
        {
            this.pos = pos;
        }
        public virtual void addToPos(Vector2 delta)
        {
            pos += delta;
        }
        public virtual void multiplyPosBy(Vector2 multiplier)
        {
            pos *= multiplier;
        }
        public virtual void multiplyPosBy(float factor)
        {
            pos *= factor;
        }

        public virtual Vector2 getPrevPos()
        {
            return prevPos;
        }


    }
}