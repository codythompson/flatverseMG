using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace flatverse
{
    public class DEBUG_CONTROLLER : InputController
    {
        public static bool DEBUG_FLAG = false;
        public static bool DEBUG_FLAG_UP = false;
        public static List<Vector2> DEBUG_POINTS = new List<Vector2>();

        Vector2 oldVels;
        Vector2 slowVels = new Vector2(1, 1);

        public DEBUG_CONTROLLER()
            : base()
        {
            oldVels = vels;
        }

        public override void update()
        {
            bool prevFlag = DEBUG_CONTROLLER.DEBUG_FLAG;
            DEBUG_CONTROLLER.DEBUG_FLAG = Keyboard.GetState().IsKeyDown(Keys.Enter);
            DEBUG_FLAG_UP = prevFlag && !DEBUG_CONTROLLER.DEBUG_FLAG;

            if (DEBUG_CONTROLLER.DEBUG_FLAG_UP)
            {
                //position.singleFrameVel = new Vector2(40, 40);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (this.vels != slowVels)
                {
                    oldVels = this.vels;
                }
                this.vels = slowVels;
            }
            else
            {
                this.vels = oldVels;
            }

            base.update();
        }
    }
}