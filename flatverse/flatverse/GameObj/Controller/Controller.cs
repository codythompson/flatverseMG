using System;
using Microsoft.Xna.Framework;

namespace flatverse
{
    public interface Controller
    {
        void update();
        Vector2 deltaP();
    }
}