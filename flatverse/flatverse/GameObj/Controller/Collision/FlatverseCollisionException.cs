using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class FlatverseCollisionException : FlatverseException
    {
        const string LINE_EXCEPTION = "Failed to create an instance of the line between {0} and {1}";
        public static void throwLineException(Vector2 a, Vector2 b)
        {
            throw new FlatverseCollisionException("LineSegment", string.Format(LINE_EXCEPTION, a, b));
        }

        const string WEIGHT_CLASS_EXCEPTION = "Incompatible weight classes for '{0}' method, weights given: {1} and {2}";
        public static void throwAwayWeightClassException(Object thrower, int weightA, int weightB)
        {
            throw new FlatverseCollisionException(thrower, string.Format(WEIGHT_CLASS_EXCEPTION, "collideAway", weightA, weightB));
        }

        public FlatverseCollisionException(string instanceType, string message)
            : base(string.Format("['{0}' instance]: {1}", instanceType, message))
        {}

        public FlatverseCollisionException(Object thrower, string message)
            : this(thrower.GetType().ToString(), message)
        {}
    }
}