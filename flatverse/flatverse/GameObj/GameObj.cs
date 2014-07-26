using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace flatverse
{
    public class GameObj
    {
        public List<Drawable> dbls;

        public Position position;
        public Controller controller;
        public List<Collider> colliders;

        public GameObj(Position position, Controller controller)
        {
            this.position = position;
            this.controller = controller;
            this.controller.init(position);
            dbls = new List<Drawable>();
            colliders = new List<Collider>();
        }

        public GameObj(Position position, Controller controller, List<Drawable> dbls)
        {
            this.position = position;
            this.controller = controller;
            this.dbls = dbls;
            colliders = new List<Collider>();
        }

        public GameObj(Position position, Controller controller, Drawable dbl)
            : this(position, controller, new List<Drawable>())
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
            position.update();
            foreach (Collider collider in colliders)
            {
                collider.update();
            }
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            foreach (Drawable dbl in dbls)
            {
                dbl.simpleDraw(spriteBatch,position.pos);
            }
        }

        public virtual void addDrawable(Drawable dbl)
        {
            dbls.Add(dbl);
        }

        public virtual void addCollider(Collider collider)
        {
            collider.init(this);
            colliders.Add(collider);
        }

        public virtual List<Collider> getColliders()
        {
            return colliders;
        }
    }
}