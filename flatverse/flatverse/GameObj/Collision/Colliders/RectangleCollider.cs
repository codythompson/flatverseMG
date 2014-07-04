﻿using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class RectangleCollider : Collider
    {
        protected FVRectangle rect, prevRect;
        protected Vector2 dims;

        public RectangleCollider(Vector2 dims, Vector2 offset, float weightClass)
            : base(offset, weightClass)
        {
            this.dims = dims;
        }

        public RectangleCollider(float x, float y, Vector2 offset, float weightClass)
            : this(new Vector2(x, y), offset, weightClass)
        { }

        public RectangleCollider(Vector2 dims, float weightClass)
            : this(dims, Vector2.Zero, weightClass)
        { }

        public RectangleCollider(float x, float y, float weightClass)
            : this(x, y, Vector2.Zero, weightClass)
        { }

        public override void init(Position ownerPos)
        {
            base.init(ownerPos);
            rect = new FVRectangle(getPosPlusOffset(), dims);
            prevRect = new FVRectangle(getPrevPosPlusOffset(), dims);
        }

        public override void update()
        {
            base.update();
            rect.moveTo(getPosPlusOffset());
            prevRect.moveTo(getPrevPosPlusOffset());
        }

        public override Polygon getCollisionPath()
        {
            Vector2 delta = collPos - position.prevPos;
            rect.moveTo(getCollPosPlusOffset());

            if (delta.X == 0 && delta.Y == 0)
            {
                return new Polygon(new Vector2[] { rect.topLeft(), rect.topRight(), rect.bottomRight(), rect.bottomLeft() });
            }

            Vector2[] points = new Vector2[6];

            if (delta.X >= 0)
            {
                // going down and to the right
                if (delta.Y >= 0)
                {
                    points[0] = prevRect.bottomLeft();
                    points[1] = prevRect.topLeft();
                    points[2] = prevRect.topRight();

                    points[3] = rect.topRight();
                    points[4] = rect.bottomRight();
                    points[5] = rect.bottomLeft();
                }
                // going up and to the right
                else
                {
                    points[0] = prevRect.bottomRight();
                    points[1] = prevRect.bottomLeft();
                    points[2] = prevRect.topLeft();

                    points[3] = rect.topLeft();
                    points[4] = rect.topRight();
                    points[5] = rect.bottomRight();
                }
            }
            else
            {
                // going down and to the left
                if (delta.Y >= 0)
                {
                    points[0] = prevRect.topLeft();
                    points[1] = prevRect.topRight();
                    points[2] = prevRect.bottomRight();

                    points[3] = rect.bottomRight();
                    points[4] = rect.bottomLeft();
                    points[5] = rect.topLeft();
                }
                // going up and to the left
                else
                {
                    points[0] = prevRect.bottomLeft();
                    points[1] = prevRect.bottomRight();
                    points[2] = prevRect.topRight();

                    points[3] = rect.topRight();
                    points[4] = rect.topLeft();
                    points[5] = rect.bottomLeft();
                }
            }

            return new Polygon(points);
        }

        public override bool intersects(Polygon collisionPath)
        {
            rect.moveTo(getCollPosPlusOffset());
            return collisionPath.intersects(rect);
        }

        public override Tuple<Vector2, Vector2?> getTop()
        {
            return new Tuple<Vector2, Vector2?>(rect.topLeft(), rect.topRight());
        }

        public override Tuple<Vector2, Vector2?> getBottom()
        {
            return new Tuple<Vector2, Vector2?>(rect.bottomLeft(), rect.bottomRight());
        }

        public override Tuple<Vector2, Vector2?> getLeft()
        {
            return new Tuple<Vector2, Vector2?>(rect.topLeft(), rect.bottomLeft());
        }

        public override Tuple<Vector2, Vector2?> getRight()
        {
            return new Tuple<Vector2, Vector2?>(rect.topRight(), rect.topRight());
        }
    }
}