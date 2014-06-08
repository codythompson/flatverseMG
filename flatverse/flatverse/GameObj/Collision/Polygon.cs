using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class Polygon
    {
        private LineSegment[] lines;
        private FVRectangle bnds;

        public Polygon(Vector2[] points)
        {
            lines = new LineSegment[points.Length];
            float left = float.PositiveInfinity;
            float right = float.NegativeInfinity;
            float top = float.PositiveInfinity;
            float bot = float.NegativeInfinity;
            for (int i = 1; i < points.Length; i++)
            {
                Vector2 pointA = points[i - 1];
                lines[i - 1] = new LineSegment(pointA, points[i]);
                if (pointA.X < left)
                {
                    left = pointA.X;
                }
                else if (pointA.X > right)
                {
                    right = pointA.X;
                }

                if (pointA.Y < top)
                {
                    top = pointA.Y;
                }
                else if (pointA.Y > bot)
                {
                    bot = pointA.Y;
                }
            }
            Vector2 lastPoint = points[points.Length - 1];
            lines[points.Length - 1] = new LineSegment(lastPoint, points[0]);
            if (lastPoint.X < left)
            {
                left = lastPoint.X;
            }
            else if (lastPoint.X > right)
            {
                right = lastPoint.X;
            }

            if (lastPoint.Y < top)
            {
                top = lastPoint.Y;
            }
            else if (lastPoint.Y > bot)
            {
                bot = lastPoint.Y;
            }
            bnds = new FVRectangle(left, top, right - left, bot - top);
        }

        public FVRectangle bounds()
        {
            return bnds;
        }

        public float left()
        {
            return bnds.left();
        }

        public float right()
        {
            return bnds.right();
        }

        public float top()
        {
            return bnds.top();
        }

        public float bottom()
        {
            return bnds.bottom();
        }

        public bool contains(Vector2 point)
        {
            if (!bnds.contains(point))
            {
                return false;
            }

            LineSegment leftCheck = new LineSegment(new Vector2(float.NegativeInfinity, point.Y), point);
            //LineSegment rightCheck = new LineSegment(point, new Vector2(float.PositiveInfinity, point.Y));
            int leftCnt = 0;
            foreach (LineSegment line in lines)
            {
                if (line.intersects(leftCheck))
                {
                    leftCnt++;
                }
            }

            return leftCnt % 2 == 1;
        }

        public bool intersects(LineSegment line)
        {
            if (!bnds.intersects(line))
            {
                return false;
            }

            return contains(line.getA()) || contains(line.getB());
        }

        public LineSegment[] segments()
        {
            return lines;
        }
    }
}