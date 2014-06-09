using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class GameObj
    {
        public List<Drawable> dbls;

        protected Controller controller;
        protected Vector2 pos, prevPos;

        private List<Collider> colliders;

        public GameObj(Controller controller, Vector2 initialPos, List<Drawable> dbls)
        {
            this.controller = controller;
            pos = initialPos;
            prevPos = initialPos;
            this.dbls = dbls;
            colliders = new List<Collider>();
        }

        public GameObj(Controller controller, Vector2 initialPos, Drawable dbl)
            : this(controller, initialPos, new List<Drawable>())
        {
            dbls.Add(dbl);
        }

        public GameObj(Controller controller, float x, float y, List<Drawable> dbls)
            : this(controller, new Vector2(x, y), dbls)
        {}

        public GameObj(Controller controller, float x, float y, Drawable dbl)
            : this(controller, x, y, new List<Drawable>())
        {
            dbls.Add(dbl);
        }

        public virtual void update()
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.update();
            }

            controller.update();
            pos += controller.deltaP();
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

        public virtual Vector2 getPrevPos()
        {
            return prevPos;
        }
    }
}