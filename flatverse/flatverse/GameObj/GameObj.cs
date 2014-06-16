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

        private List<Collider> colliders;

        public GameObj(Controller controller, List<Drawable> dbls)
        {
            this.controller = controller;
            this.dbls = dbls;
            colliders = new List<Collider>();
        }

        public GameObj(Controller controller, Drawable dbl)
            : this(controller, new List<Drawable>())
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
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.simpleDraw(spriteBatch, controller.getPos());
            }
        }

        /*
         * Getters and setters
         */
        public virtual Vector2 getPos()
        {
            return controller.getPos();
        }

        public virtual Vector2 getPrevPos()
        {
            return controller.getPrevPos();
        }
    }
}