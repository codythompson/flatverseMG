using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegmentCollider : Collider
    {
        private Vector2 lineDelta;

        public LineSegmentCollider(Vector2 lineDelta, Vector2 offset, float weightClass)
            : base(offset, weightClass)
        {
            this.lineDelta = lineDelta;
        }

        public LineSegmentCollider(Vector2 lineDelta, float weightClass)
            : this(lineDelta, Vector2.Zero, weightClass)
        {}

        public override Polygon getCollisionPath()
        {
            Vector2 pPos = getPrevPosPlusOffset();
            Vector2 cPos = getCollPosPlusOffset();
            return new Polygon(new Vector2[] { pPos, pPos + lineDelta, cPos + lineDelta, cPos});
        }

        public override bool intersects(Polygon collisionPath)
        {
            Vector2 cPos = getCollPosPlusOffset();
            return collisionPath.intersects(new LineSegment(cPos, cPos + lineDelta));
        }

        public override void collideAwayFrom(Collider from)
        {
            if (DEBUG_CONTROLLER.DEBUG_FLAG_UP)
            {
                ;
            }

            base.collideAwayFrom(from);

            if (!from.intersects(getCollisionPath()))
            {
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

            position.pos = collPos;
        }
    }
}