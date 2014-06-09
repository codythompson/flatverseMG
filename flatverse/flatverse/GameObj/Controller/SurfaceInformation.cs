using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public class SurfaceInformation
    {
        public enum Orientation : uint
        {
            NONE = 0,
            ON_SMALL_Y = 1,
            ON_BIG_Y = 2,
            ON_SMALL_X = 4,
            ON_BIG_X = 8
        }

        public Orientation orientation;

        public SurfaceInformation()
        {
            orientation = Orientation.NONE;
        }

        public void addOrientation(Orientation newOrientation)
        {
            orientation |= newOrientation;
        }

        public bool isNone()
        {
            return orientation == Orientation.NONE;
        }

        public bool isOn(Orientation orientationCheck)
        {
            return (orientation & orientationCheck) == orientationCheck;
        }
    }
}