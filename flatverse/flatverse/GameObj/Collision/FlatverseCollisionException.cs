using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class FlatverseCollisionException : FlatverseException
    {
        const string LINE_EXCEPTION = "LineSegment has failed to create an instance of the line between {0} and {1}";
        public static void throwLineException(Vector2 a, Vector2 b)
        {
            throw new FlatverseCollisionException(string.Format(LINE_EXCEPTION, a, b));
        }

        public FlatverseCollisionException(string message)
            : base(message)
        {

        }
    }
}