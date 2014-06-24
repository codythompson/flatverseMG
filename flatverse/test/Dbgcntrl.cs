using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace flatverse
{
    public class DEBUG_CONTROLLER : InputController
    {
        public static bool DEBUG_FLAG = false;
        public static bool DEBUG_FLAG_UP = false;
        public static List<Vector2> DEBUG_POINTS = new List<Vector2>();

        public DEBUG_CONTROLLER(Vector2 initialPos)
            : base(initialPos)
        {}

        public override void update()
        {
            bool prevFlag = DEBUG_CONTROLLER.DEBUG_FLAG;
            DEBUG_CONTROLLER.DEBUG_FLAG = Keyboard.GetState().IsKeyDown(Keys.Enter);
            DEBUG_FLAG_UP = prevFlag && !DEBUG_CONTROLLER.DEBUG_FLAG;

            if (DEBUG_CONTROLLER.DEBUG_FLAG_UP)
            {
                explicitDeltaP = new Vector2(40, 40);
            }

            base.update();
        }
    }
}