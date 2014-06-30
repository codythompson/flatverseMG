using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace flatverse
{
    public class Controller
    {
        public Position position;

        public virtual void init(Position position)
        {
            this.position = position;
        }

        public virtual void update()
        {

        }
    }
}