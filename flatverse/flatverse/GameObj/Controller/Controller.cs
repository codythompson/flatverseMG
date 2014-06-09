using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class Controller
    {
        protected Vector2 acceleration, velocity;
        protected Vector2 explicitDeltaP;

        private Vector2 computedDeltaP;

        public Controller() {
            acceleration = Vector2.Zero;
            velocity = Vector2.Zero;
            explicitDeltaP = Vector2.Zero;
        }

        public Controller(Vector2 acceleration)
        {
            this.acceleration = acceleration;
            velocity = Vector2.Zero;
            explicitDeltaP = Vector2.Zero;
        }

        public virtual void update()
        {
            velocity += acceleration;
            computedDeltaP = explicitDeltaP + velocity;
            explicitDeltaP = Vector2.Zero;
        }

        public virtual Vector2 deltaP()
        {
            return computedDeltaP;
        }

        public virtual void addAcceleration(Vector2 deltaA)
        {
            acceleration += deltaA;
        }

        public virtual void setAcceleration(Vector2 acceleration)
        {
            this.acceleration = acceleration;
        }

        public virtual void addVelocity(Vector2 deltaV)
        {
            velocity += deltaV;
        }

        public virtual void setVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public virtual void addToExplicitDeltaP(Vector2 deltaDeltaP)
        {
            explicitDeltaP += deltaDeltaP;
        }

        public virtual void setExplicitDeltaP(Vector2 explicitDeltaP)
        {
            this.explicitDeltaP = explicitDeltaP;
        }
    }
}