using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public abstract class Collider
    {
        public int weightClass;
        public Vector2 offset;
        //protected SurfaceInformation surfaceInformation;

        public Collider(Vector2 offset, int weightClass)
        {
            this.weightClass = weightClass;
            this.offset = offset;
        }

        public abstract void initialize(Vector2 ownerPos, Controller ownerController);
        public abstract void move(Vector2 deltaP);
        public abstract float moveAlongTrajectory(float t);
        //public abstract float moveHalfBack();
        //public abstract float moveHalfForward();
        public abstract void moveToOriginal();
        public abstract Polygon getCollisionPath();
        public abstract bool intersects(Polygon collisionPath);
        public virtual void collideAway(Collider other)
        {
            if (other.weightClass >= weightClass)
            {
                FlatverseCollisionException.throwAwayWeightClassException(this, weightClass, other.weightClass);
            }
        }

    }
}