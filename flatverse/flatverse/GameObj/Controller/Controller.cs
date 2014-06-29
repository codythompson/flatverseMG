using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace flatverse
{
    public class Controller
    {
        public Position position;

        public virtual void init(Position position)
        {
            this.position = position;
        }

        public virtual void update()
        {

        }

        //protected Vector2 acceleration, velocity;
        //protected Vector2 explicitDeltaP;

        //private Vector2 computedDeltaP;

        //private Vector2 pos, prevPos;

        //private List<DeltaModifier> modifiers;

        //public Controller(Vector2 acceleration, Vector2 initialPos)
        //{
        //    this.acceleration = acceleration;
        //    velocity = Vector2.Zero;
        //    pos = initialPos;
        //    prevPos = initialPos;
        //    modifiers = new List<DeltaModifier>();
        //}

        //public Controller(Vector2 initialPos)
        //    : this(Vector2.Zero, initialPos)
        //{}

        //public virtual void update()
        //{
        //    prevPos = pos;
        //    velocity += acceleration;
        //    computedDeltaP = velocity;
        //    computedDeltaP += explicitDeltaP;
        //    foreach (DeltaModifier mod in modifiers)
        //    {
        //        computedDeltaP = mod.modifyDelta(pos, computedDeltaP);
        //    }
        //    pos += computedDeltaP;

        //    explicitDeltaP = Vector2.Zero;
        //    modifiers.Clear();
        //}

        //public virtual Vector2 getPos()
        //{
        //    return pos;
        //}

        //public virtual Vector2 getPrevPos()
        //{
        //    return prevPos;
        //}

        //public virtual Vector2 deltaP()
        //{
        //    return computedDeltaP;
        //}

        //public virtual void addAcceleration(Vector2 deltaA)
        //{
        //    acceleration += deltaA;
        //}

        //public virtual void setAcceleration(Vector2 acceleration)
        //{
        //    this.acceleration = acceleration;
        //}

        //public virtual void addVelocity(Vector2 deltaV)
        //{
        //    velocity += deltaV;
        //}

        //public virtual void setVelocity(Vector2 velocity)
        //{
        //    this.velocity = velocity;
        //}

        //public virtual void addDeltaModifier(DeltaModifier modifier)
        //{
        //    modifiers.Add(modifier);
        //}

        //public virtual void addExplicitDeltaP(Vector2 explicitDeltaP)
        //{
        //    this.explicitDeltaP += explicitDeltaP;
        //}

        //public virtual void collisionAdjust(Vector2 newPos)
        //{
        //    this.pos = newPos;
        //}
    }
}