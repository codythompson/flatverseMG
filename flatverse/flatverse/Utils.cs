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

        public static bool inRangeOf(float value, float valueToMatch, float tolerance)
        {
            return value > valueToMatch - tolerance && value < valueToMatch + tolerance;
        }

        public static bool withinOneOf(float value, float valueToMatch)
        {
            return inRangeOf(value, valueToMatch, .5f);
        }

        public static Color colorFromUInt(uint color)
        {
            byte a = (byte)((color >> 12) & 0xff);
            byte r = (byte)((color >> 8) & 0xff);
            byte g = (byte)((color >> 4) & 0xff);
            byte b = (byte)(color & 0xff);

            return Color.FromNonPremultiplied(r, g, b, a);
        }
    }
}