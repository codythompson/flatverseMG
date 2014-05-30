using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public static class Utils
    {
        public static float vectorToAngle(Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
    }
}