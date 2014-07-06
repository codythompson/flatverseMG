using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class PointPathController : Controller
    {
        public Vector2[] points;
        public int pointIndex;
        public float velMag;

        public PointPathController(Vector2[] points, float velMag)
        {
            this.points = points;
            this.velMag = velMag;
            pointIndex = 0;
        }

        public override void init(Position position)
        {
            base.init(position);
            if (points.Length > 1 && position.pos == points[pointIndex])
            {
                pointIndex++;
            }
        }

        public override void update()
        {
            Vector2 vel = (points[pointIndex] - position.pos);
            vel.Normalize();
            vel *= velMag;
            if (((position.pos + vel) - points[pointIndex]).Length() < vel.Length())
            {
                vel = points[pointIndex] - position.pos;
                pointIndex++;
                if (pointIndex >= points.Length)
                {
                    pointIndex = 0;
                }
            }
            position.singleFrameVel += vel;

            base.update();
        }
    }
}