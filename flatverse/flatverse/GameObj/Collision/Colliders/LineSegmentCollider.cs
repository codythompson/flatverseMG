using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegmentCollider : Collider
    {
        private Vector2 lineDelta;
        //public bool isVertical;

        public LineSegmentCollider(Vector2 lineDelta, Vector2 offset)
            : base(offset)
        {
            this.lineDelta = lineDelta;
            //if (Math.Abs(lineDelta.Y) > .5f)
            //{
            //    isVertical = true;
            //}
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

        //public override Tuple<Vector2, Vector2?> getTop()
        //{
        //    Vector2 a = getPosPlusOffset();
        //    Vector2 b = a + lineDelta;

        //    if (a.Y < b.Y)
        //    {
        //        return new Tuple<Vector2, Vector2?>(a, null);
        //    }
        //    else if (b.Y < a.Y)
        //    {
        //        return new Tuple<Vector2, Vector2?>(b, null);
        //    }
        //    else
        //    {
        //        if (a.X <= b.X)
        //        {
        //            return new Tuple<Vector2, Vector2?>(a, b);
        //        }
        //        else
        //        {
        //            return new Tuple<Vector2, Vector2?>(b, a);
        //        }
        //    }
        //}

        //public override Tuple<Vector2, Vector2?> getBottom()
        //{
        //    Vector2 a = getPosPlusOffset();
        //    Vector2 b = a + lineDelta;

        //    if (a.Y > b.Y)
        //    {
        //        return new Tuple<Vector2, Vector2?>(a, null);
        //    }
        //    else if (b.Y > a.Y)
        //    {
        //        return new Tuple<Vector2, Vector2?>(b, null);
        //    }
        //    else
        //    {
        //        if (a.X <= b.X)
        //        {
        //            return new Tuple<Vector2, Vector2?>(a, b);
        //        }
        //        else
        //        {
        //            return new Tuple<Vector2, Vector2?>(b, a);
        //        }
        //    }
        //}

        //public override Tuple<Vector2, Vector2?> getLeft()
        //{
        //    Vector2 a = getPosPlusOffset();
        //    Vector2 b = a + lineDelta;

        //    if (a.X < b.X)
        //    {
        //        return new Tuple<Vector2, Vector2?>(a, null);
        //    }
        //    else if (b.X < a.X)
        //    {
        //        return new Tuple<Vector2, Vector2?>(b, null);
        //    }
        //    else
        //    {
        //        if (a.Y <= b.Y)
        //        {
        //            return new Tuple<Vector2, Vector2?>(a, b);
        //        }
        //        else
        //        {
        //            return new Tuple<Vector2, Vector2?>(b, a);
        //        }
        //    }
        //}

        //public override Tuple<Vector2, Vector2?> getRight()
        //{
        //    Vector2 a = getPosPlusOffset();
        //    Vector2 b = a + lineDelta;

        //    if (a.X > b.X)
        //    {
        //        return new Tuple<Vector2, Vector2?>(a, null);
        //    }
        //    else if (b.X > a.X)
        //    {
        //        return new Tuple<Vector2, Vector2?>(b, null);
        //    }
        //    else
        //    {
        //        if (a.Y <= b.Y)
        //        {
        //            return new Tuple<Vector2, Vector2?>(a, b);
        //        }
        //        else
        //        {
        //            return new Tuple<Vector2, Vector2?>(b, a);
        //        }
        //    }
        //}
    }
}