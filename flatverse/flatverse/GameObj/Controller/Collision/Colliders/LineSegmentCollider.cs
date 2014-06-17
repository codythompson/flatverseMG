using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegmentCollider : Collider
    {
        public LineSegment line;
        private Vector2 lineDelta;
        private Vector2 prevPos;

        public LineSegmentCollider(Vector2 lineDelta, Vector2 offset, int weightClass)
            : base(offset, weightClass)
        {
            this.lineDelta = lineDelta;
        }

        public override void initialize(Vector2 ownerPos)
        {
            Vector2 a = ownerPos + offset;
            line = new LineSegment(a, a + lineDelta);
            prevPos = line.getA();
        }

        public override void move(Vector2 deltaP)
        {
            prevPos = line.getA();
            line += deltaP;
        }

        public override float moveHalfBack()
        {
            Vector2 halfDistance = (line.getA() - prevPos) / 2;
            line -= halfDistance;
            return halfDistance.Length();
        }

        public override float moveHalfForward()
        {
            Vector2 halfDistance = (line.getA() - prevPos) / 2;
            line += halfDistance;
            return halfDistance.Length();
        }

        public override void moveToOriginal()
        {
            line = new LineSegment(prevPos, prevPos + lineDelta);
        }

        public override Polygon getCollisionPath()
        {
            return new Polygon(new Vector2[] { prevPos, prevPos + lineDelta, line.getB(), line.getA() });
        }

        public override bool intersects(Polygon collisionPath)
        {
            return collisionPath.intersects(line);
        }

        public override void collideAway(Collider other)
        {
            if (DEBUG_CONTROLLER.DEBUG_FLAG)
            {
                ; //TODO add the points of the collision path as a static var
                // to DEBUG_CONTROLLER that will be drawn to visualize
                // the collision path (and the failing bnds check)
            }

            base.collideAway(other);

            if (!intersects(other.getCollisionPath()))
            {
                return;
            }

            float dist = other.moveHalfBack();
            while (dist >= 1)
            {
                if (intersects(other.getCollisionPath()))
                {
                    dist = other.moveHalfBack();
                }
                else
                {
                    dist = other.moveHalfForward();
                }
            }
            if (intersects(other.getCollisionPath()))
            {
                other.moveToOriginal();
            }
        }
    }
}