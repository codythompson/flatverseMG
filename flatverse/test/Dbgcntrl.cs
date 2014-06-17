using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace flatverse
{
    public class DEBUG_CONTROLLER : InputController
    {
        public static bool DEBUG_FLAG = false;

        public DEBUG_CONTROLLER(Vector2 initialPos)
            : base(initialPos)
        {}

        public override void update()
        {
            base.update();
            DEBUG_CONTROLLER.DEBUG_FLAG = Keyboard.GetState().IsKeyDown(Keys.Enter);
            if (DEBUG_CONTROLLER.DEBUG_FLAG)
            {
                explicitDeltaP = new Vector2(40, 40);
            }
        }
    }
}