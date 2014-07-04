using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class DebugCollider : RectangleCollider
    {
        public Drawable top, bot, left, right;

        public DebugCollider(Vector2 dims, Vector2 offset, float weightClass)
            : base(dims, offset, weightClass)
        {}

        public DebugCollider(float x, float y, Vector2 offset, float weightClass)
            : base(new Vector2(x, y), offset, weightClass)
        { }

        public DebugCollider(Vector2 dims, float weightClass)
            : base(dims, Vector2.Zero, weightClass)
        { }

        public DebugCollider(float x, float y, float weightClass)
            : base(x, y, Vector2.Zero, weightClass)
        { }

        public override void postCollision()
        {
            //naiive impl
            foreach (Collider collider in collidedWith)
            {
                if (top != null)
                {
                    if (Utils.withinOneOf(collider.getBottom().Item1.Y, rect.top()) && top != null)
                    {
                        top.visible = true;
                    }
                    else
                    {
                        top.visible = false;
                    }
                }
            }
        }
    }
}