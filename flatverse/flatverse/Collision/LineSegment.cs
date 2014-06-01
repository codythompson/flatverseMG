using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegment
    {
        private interface LineSegmentRep
        {
            Vector2 left();
            Vector2 right();
            Vector2 top();
            Vector2 bottom();
            Vector2 delta();
            Vector2 slope();
            Vector2 yIntercept();
            float yAt(float x);
            //TODO FINISH interface and finsish vert
        }

        private class VertLineSegment
        {
            private float x, topY, botY;

            public VertLineSegment(Vector2 a, Vector2 b)
            {
                if (a.X != b.X)
                {
                    FlatverseCollisionException.throwLineException(a, b);
                }

                x = a.X;
                if (a.Y >= b.Y)
                {
                    topY = a.Y;
                    botY = b.Y;
                }
                else
                {
                    topY = b.Y;
                    botY = a.Y;
                }
            }
        } 

        private class NonVertLineSegment
        {
            private Vector2 a, b;
            private float slp, yIcpt;

            public NonVertLineSegment(Vector2 a, Vector2 b)
            {
                if (a.X == b.X)
                {
                    FlatverseCollisionException.throwLineException(a, b);
                }

                this.a = a;
                this.b = b;

                slp = (b.Y - a.Y) / (b.X - a.X);
                yIcpt = a.Y - (a.X * slp);
            }

            public virtual Vector2 left()
            {
                if (a.X > b.X)
                {
                    return b;
                }
                return a;
            }

            public virtual Vector2 right()
            {
                if (a.X > b.X)
                {
                    return a;
                }
                return b;
            }

            public virtual Vector2 top()
            {
                if (a.Y > b.Y)
                {
                    return b;
                }
                return a;
            }

            public virtual Vector2 bottom()
            {
                if (a.Y > b.Y)
                {
                    return a;
                }
                return b;
            }

            public virtual Vector2 delta()
            {
                return right() - left();
            }

            public virtual float slope()
            {
                return slp;
            }

            public virtual float yIntercept()
            {
                return yIcpt;
            }

            public virtual float yAt(float x)
            {
                float y = (x * slp) + yIcpt;

                if (y < bottom().Y || y > top().Y)
                {
                    return float.NaN;
                }
                return y;
            }

            public virtual bool contains(Vector2 point)
            {
                return yAt(point.X) == point.Y;
            }

            public virtual bool containsX(float x)
            {
                return left().X <= x && right().X >= x;
            }

            public virtual bool containsY(float y)
            {
                return top().Y <= y && bottom().Y >= y;
            }

            public virtual bool intersects(NonVertLineSegment line)
            {
                if (line.slope() == slp) // parallel
                {
                    if (line.yIntercept() == yIcpt) // coinciding lines
                    {
                        return ((line.right().X >= left().X && line.left().X <= left().X) ||
                            (line.right().X >= right().X && line.left().X <= right().X));
                    }
                    else // parallel non coinciding lines
                    {
                        return false;
                    }
                }

                float intersectionX = (line.yIntercept() - yIcpt) / (slp - line.slope());

                return line.containsX(intersectionX);
            }
        }
    }
}