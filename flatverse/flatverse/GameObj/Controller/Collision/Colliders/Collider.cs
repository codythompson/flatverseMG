using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public abstract class Collider
    {
        public int weightClass;
        public Vector2 offset;
        protected Vector2 deltaP;
        protected SurfaceInformation surfaceInformation;

        public Collider(Vector2 offset, int weightClass)
        {
            this.weightClass = weightClass;
            this.offset = offset;
        }

        public abstract void initialize(Vector2 ownerPos);
        public abstract void move(Vector2 deltaP);
        public virtual void update()
        {
            deltaP = Vector2.Zero;
        }
        public abstract void collide(Collider other);
        public virtual void addDeltaP(Vector2 deltaP)
        {
            this.deltaP += deltaP;
        }
        public virtual Vector2 getDeltaP()
        {
            return deltaP;
        }
    }
}