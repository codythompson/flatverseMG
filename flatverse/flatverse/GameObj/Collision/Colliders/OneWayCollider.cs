using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    class OneWayCollider : LineSegmentCollider
    {
        public enum Direction
        {
            DOWN, UP, LEFT, RIGHT
        }

        public Direction direction;

        public OneWayCollider(Direction direction, Vector2 lineDelta, Vector2 offset)
            : base(lineDelta, offset)
        {
            this.direction = direction;
        }

        public OneWayCollider(Direction direction, Vector2 lineDelta)
            : base(lineDelta)
        {
            this.direction = direction;
        }

        public override void collideAwayFrom(Collider from, bool allowAdjustment)
        {
            if (!intersects(from.getCollisionPath()))
            {
                return;
            }

            LineSegment line = getLineSegment();
            switch (direction)
            {
                case Direction.DOWN:
                    if (!line.isAboveThis(from.getPrevBounds()))
                    {
                        return;
                    }
                    break;
                case Direction.UP:
                    if (!line.isBelowThis(from.getPrevBounds()))
                    {
                        return;
                    }
                    break;
                case Direction.LEFT:
                    if (!line.isRightOfThis(from.getPrevBounds()))
                    {
                        return;
                    }
                    break;
                case Direction.RIGHT:
                    if (!line.isLeftOfThis(from.getPrevBounds()))
                    {
                        return;
                    }
                    break;
            }

            base.collideAwayFrom(from, allowAdjustment);
        }
    }
}
