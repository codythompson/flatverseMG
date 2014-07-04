using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegmentCollider : Collider
    {
        private Vector2 lineDelta;
        //public bool isVertical;

        public LineSegmentCollider(Vector2 lineDelta, Vector2 offset, float weightClass)
            : base(offset, weightClass)
        {
            this.lineDelta = lineDelta;
            //if (Math.Abs(lineDelta.Y) > .5f)
            //{
            //    isVertical = true;
            //}
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

        public override Tuple<Vector2, Vector2?> getTop()
        {
            Vector2 a = getPosPlusOffset();
            Vector2 b = a + lineDelta;

            if (a.Y < b.Y)
            {
                return new Tuple<Vector2, Vector2?>(a, null);
            }
            else if (b.Y < a.Y)
            {
                return new Tuple<Vector2, Vector2?>(b, null);
            }
            else
            {
                if (a.X <= b.X)
                {
                    return new Tuple<Vector2, Vector2?>(a, b);
                }
                else
                {
                    return new Tuple<Vector2, Vector2?>(b, a);
                }
            }
        }

        public override Tuple<Vector2, Vector2?> getBottom()
        {
            Vector2 a = getPosPlusOffset();
            Vector2 b = a + lineDelta;

            if (a.Y > b.Y)
            {
                return new Tuple<Vector2, Vector2?>(a, null);
            }
            else if (b.Y > a.Y)
            {
                return new Tuple<Vector2, Vector2?>(b, null);
            }
            else
            {
                if (a.X <= b.X)
                {
                    return new Tuple<Vector2, Vector2?>(a, b);
                }
                else
                {
                    return new Tuple<Vector2, Vector2?>(b, a);
                }
            }
        }

        public override Tuple<Vector2, Vector2?> getLeft()
        {
            Vector2 a = getPosPlusOffset();
            Vector2 b = a + lineDelta;

            if (a.X < b.X)
            {
                return new Tuple<Vector2, Vector2?>(a, null);
            }
            else if (b.X < a.X)
            {
                return new Tuple<Vector2, Vector2?>(b, null);
            }
            else
            {
                if (a.Y <= b.Y)
                {
                    return new Tuple<Vector2, Vector2?>(a, b);
                }
                else
                {
                    return new Tuple<Vector2, Vector2?>(b, a);
                }
            }
        }

        public override Tuple<Vector2, Vector2?> getRight()
        {
            Vector2 a = getPosPlusOffset();
            Vector2 b = a + lineDelta;

            if (a.X > b.X)
            {
                return new Tuple<Vector2, Vector2?>(a, null);
            }
            else if (b.X > a.X)
            {
                return new Tuple<Vector2, Vector2?>(b, null);
            }
            else
            {
                if (a.Y <= b.Y)
                {
                    return new Tuple<Vector2, Vector2?>(a, b);
                }
                else
                {
                    return new Tuple<Vector2, Vector2?>(b, a);
                }
            }
        }
    }
}