using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegmentCollider : Collider
    {
        private Vector2 lineDelta;

        public LineSegmentCollider(Vector2 lineDelta, Vector2 offset)
            : base(offset)
        {
            this.lineDelta = lineDelta;
        }

        public LineSegmentCollider(Vector2 lineDelta)
            : this(lineDelta, Vector2.Zero)
        {}

        public override Polygon getCollisionPath()
        {
            Vector2 pPos = getPrevPosPlusOffset();
            Vector2 cPos = getCollPosPlusOffset();
            return new Polygon(new Vector2[] { pPos, pPos + lineDelta, cPos + lineDelta, cPos});
        }

        private Polygon getPlatformPath(Vector2 dir)
        {
            Vector2 pointA = getPosPlusOffset();
            Vector2 pointB = pointA + lineDelta;
            return new Polygon(new Vector2[] { pointA, pointB, pointB + dir, pointA + dir });
        }

        public override Polygon getPlatformPathBottom()
        {
            return getPlatformPath(new Vector2(0, 1));
        }

        public override Polygon getPlatformPathTop()
        {
            return getPlatformPath(new Vector2(0, -1));
        }

        public override Polygon getPlatformPathLeft()
        {
            return getPlatformPath(new Vector2(-1, 0));
        }

        public override Polygon getPlatformPathRight()
        {
            return getPlatformPath(new Vector2(1, 0));
        }

        public override bool intersects(Polygon collisionPath)
        {
            Vector2 cPos = getCollPosPlusOffset();
            return collisionPath.intersects(new LineSegment(cPos, cPos + lineDelta));
        }

        public override bool intersectsPrevPos(Polygon collisionPath)
        {
            Vector2 pPos = getPrevPosPlusOffset();
            return collisionPath.intersects(new LineSegment(pPos, pPos + lineDelta));
        }

        public override Polygon getPrevBounds()
        {
            Vector2 pPos = getPrevPosPlusOffset();
            return new Polygon(new Vector2[] { pPos, pPos + lineDelta});
        }

        public override Polygon getPosBounds()
        {
            Vector2 ps = getPosPlusOffset();
            return new Polygon(new Vector2[] { ps, ps + lineDelta});
        }

        public virtual LineSegment getLineSegment()
        {
            Vector2 ps = getPosPlusOffset();
            return new LineSegment(ps, ps + lineDelta);
        }
    }
}