using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace flatverse
{
    public abstract class Collider
    {
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

        public virtual void init(Position ownerPos)
        {
            this.position = ownerPos;
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
        public abstract bool intersects(Polygon collisionPath);
        public abstract bool intersectsPrevPos(Polygon collisionPath);
        public virtual void collideAwayFrom(Collider from)
        {
            if (!from.intersects(getCollisionPath()))
            {
                return;
            }

            if (intersectsPrevPos(from.getCollisionPath()))
            {
                position.pos = position.prevPos;
                collPos = position.pos;
                from.collideAwayFrom(this);
                position.pos += from.missingDelta;
                from.position.pos += from.missingDelta;
                from.collPos += from.missingDelta;

                // TODO RE-COLLIDE!!!!

                return;
            }

            float t = 0.5f;
            float deltT = 0.5f;
            collPos = position.getPosOnTrajectory(t);
            Vector2 prevCollPos = position.prevPos;
            Vector2 lastNonIntersecting = position.prevPos;
            while ((collPos - prevCollPos).Length() >= 1)
            {
                deltT = deltT / 2;
                if (from.intersects(getCollisionPath()))
                {
                    t -= deltT;
                }
                else
                {
                    lastNonIntersecting = collPos;
                    t += deltT;
                }
                prevCollPos = collPos;
                collPos = position.getPosOnTrajectory(t);
            }

            if (from.intersects(getCollisionPath()))
            {
                collPos = lastNonIntersecting;
            }

            collidedWith.Add(from);

            missingDelta = position.pos - collPos;

            position.pos = collPos;
        }

        public virtual void postCollision() 
        {}

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

        public abstract Tuple<Vector2, Vector2?> getTop();
        public abstract Tuple<Vector2, Vector2?> getBottom();
        public abstract Tuple<Vector2, Vector2?> getLeft();
        public abstract Tuple<Vector2, Vector2?> getRight();
    }
}