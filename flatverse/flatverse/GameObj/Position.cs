using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class Position
    {
        public Vector2 pos, prevPos;
        protected Vector2 singleFrameVel;
        public Vector2 vel;
        public Vector2 accel;

        public Position(Vector2 initialPos)
        {
            pos = initialPos;
            prevPos = initialPos;
            singleFrameVel = Vector2.Zero;
            vel = Vector2.Zero;
            accel = Vector2.Zero;
        }

        public Position(float x, float y)
            : this(new Vector2(x, y))
        {}

        public virtual void update()
        {
            prevPos = pos;
            Vector2 frameDelta = vel + singleFrameVel;
            pos += frameDelta;

            vel += accel;

            singleFrameVel = Vector2.Zero;
        }

        public virtual Vector2 getPosOnTrajectory(float t)
        {
            return prevPos + ((pos - prevPos) * t);
        }

        public virtual Vector2 delta()
        {
            return pos - prevPos;
        }

        public virtual bool noChange()
        {
            return pos == prevPos;
        }

        public virtual void addSingleFrameVel(Vector2 vel)
        {
            singleFrameVel += vel;
        }
    }
}