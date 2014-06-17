using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public interface DeltaModifier
    {
        // returns the new velocity
        Vector2 modifyDelta(Vector2 pos, Vector2 vel);
    }
}