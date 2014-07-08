using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class DebugCollider : RectangleCollider
    {
        public string name;

        public DebugCollider(Vector2 dims, string name)
            : base(dims)
        {
            this.name = name;
        }
    }
}