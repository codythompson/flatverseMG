using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class LineSegmentCollider : Collider
    {
        public LineSegment line;
        private Vector2 delta;

        public LineSegmentCollider(Vector2 lineDelta, Vector2 offset, int weightClass)
            : base(offset, weightClass)
        {
            delta = lineDelta;
        }

        public override void initialize(Vector2 ownerPos)
        {
            Vector2 a = ownerPos + offset;
            line = new LineSegment(a, a + delta);
        }

        public override void move(Vector2 deltaP)
        {
            line += deltaP;
        }

        public override void collide(Collider other)
        {
            //...
        }
    }

    //Need collision hierarchy - collide using binary search on everything lower in weight
    // have 2 collision runs first w/o gravity second with to allow for horizontal movement.
    // Controller should aggregate colliders
}