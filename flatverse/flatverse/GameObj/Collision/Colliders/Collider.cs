﻿using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public abstract class Collider
    {
        public float weightClass;
        public Position position;
        public Vector2 offset;
        protected Vector2 collPos;

        public Collider(Vector2 offset, float weightClass)
        {
            this.weightClass = weightClass;
            this.offset = offset;
        }

        public virtual void init(Position ownerPos)
        {
            this.position = ownerPos;
        }
        /// <summary>
        /// Should be called after position.update
        /// but before any calls to collideAwayFrom
        /// </summary>
        public abstract void update();
        public abstract Polygon getCollisionPath();
        public abstract bool intersects(Polygon collisionPath);
        public virtual void collideAwayFrom(Collider from)
        {
            if (from.weightClass < weightClass)
            {
                FlatverseCollisionException.throwAwayWeightClassException(this, weightClass, from.weightClass);
            }
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