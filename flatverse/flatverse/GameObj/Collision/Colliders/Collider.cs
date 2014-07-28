using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace flatverse
{
    public abstract class Collider
    {
        private GameObj owner;
        public Position position;
        public Vector2 offset;
        public Vector2 collPos;
        public Vector2 missingDelta;
        protected List<Collider> collidedWith;

        public Collider(Vector2 offset)
        {
            this.offset = offset;
            collidedWith = new List<Collider>();
        }

        public virtual void init(GameObj owner)
        {
            this.owner = owner;
            this.position = owner.position;
        }
        /// <summary>
        /// Should be called after position.update
        /// but before any calls to collideAwayFrom
        /// </summary>
        public virtual void update()
        {
            collPos = position.pos;
            if (collidedWith.Count > 0)
            {
                collidedWith = new List<Collider>();
            }
        }
        public abstract Polygon getCollisionPath();
        public abstract Polygon getPlatformPathBottom();
        public abstract Polygon getPlatformPathTop();
        public abstract Polygon getPlatformPathLeft();
        public abstract Polygon getPlatformPathRight();
        public abstract Polygon getPrevBounds();
        public abstract Polygon getPosBounds();

        public abstract bool intersects(Polygon collisionPath);
        public abstract bool intersectsPrevPos(Polygon collisionPath);
        public virtual void collideAwayFrom(Collider from, bool allowAdjustment)
        {
            if (!intersects(from.getCollisionPath()))
            {
                return;
            }

            if (from.intersectsPrevPos(getCollisionPath()) && allowAdjustment)
            {
                from.position.pos = from.position.prevPos;
                from.collPos = from.position.pos;
                from.collideAwayFrom(this, false);

                collPos += position.collisionAdjust(missingDelta);
                from.collPos += from.position.collisionAdjust(missingDelta);

                return;
            }

            float t = 0.5f;
            float deltT = 0.5f;
            from.collPos = from.position.getPosOnTrajectory(t);
            Vector2 prevCollPos = from.position.prevPos;
            Vector2 lastNonIntersecting = from.position.prevPos;
            while ((from.collPos - prevCollPos).Length() >= 1)
            {
                deltT = deltT / 2;
                if (intersects(from.getCollisionPath()))
                {
                    t -= deltT;
                }
                else
                {
                    lastNonIntersecting = from.collPos;
                    t += deltT;
                }
                prevCollPos = from.collPos;
                from.collPos = from.position.getPosOnTrajectory(t);
            }

            if (intersects(from.getCollisionPath()))
            {
                from.collPos = lastNonIntersecting;
            }

            from.collidedWith.Add(from);

            from.missingDelta = from.position.pos - from.collPos;

            from.position.pos = from.collPos;
        }

        public Vector2 getPosPlusOffset()
        {
            return position.pos + offset;
        }

        public Vector2 getPrevPosPlusOffset()
        {
            return position.prevPos + offset;
        }

        public Vector2 getCollPosPlusOffset()
        {
            return collPos + offset;
        }
    }
}