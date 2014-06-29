using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class Position
    {
        public Vector2 pos, prevPos;
        public Vector2 singleFrameVel;
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

        public virtual void update()
        {
            prevPos = pos;
            Vector2 frameDelta = vel + singleFrameVel;
            pos += frameDelta;
            vel += accel;

            singleFrameVel = Vector2.Zero;
        }
    }
}