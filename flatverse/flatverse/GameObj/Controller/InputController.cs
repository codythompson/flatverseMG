﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace flatverse
{
    public class InputController : Controller
    {
        public Keys leftKey = Keys.A;
        public Keys rightKey = Keys.D;
        public Keys upKey = Keys.W;
        public Keys downKey = Keys.S;

        private bool leftDownFirst, upDownFirst;
        private bool leftDown, rightDown, upDown, downDown;

        //TODO move this somewhere more customizable
        public Vector2 vels = new Vector2(10, 10);

        public InputController()
        {

        }

        public override void update()
        {
            updateFlags();

            if (leftDown)
            {
                position.addSingleFrameVel(new Vector2(-vels.X, 0));
            }
            if (rightDown)
            {
                position.addSingleFrameVel(new Vector2(vels.X, 0));
            }
            if (upDown)
            {
                position.addSingleFrameVel(new Vector2(0, -vels.Y));
            }
            if (downDown)
            {
                position.addSingleFrameVel(new Vector2(0, vels.Y));
            }
            //

            base.update();
        }

        private void updateFlags()
        {
            bool leftD, rightD, upD, downD;
            leftD = Keyboard.GetState().IsKeyDown(leftKey);
            rightD = Keyboard.GetState().IsKeyDown(rightKey);
            upD = Keyboard.GetState().IsKeyDown(upKey);
            downD = Keyboard.GetState().IsKeyDown(downKey);

            if (leftD && rightD)
            {
                rightDown = leftDownFirst;
                leftDown = !leftDownFirst;
            }
            else if (leftD) //left is pressed right is not
            {
                leftDownFirst = true;
                leftDown = true;
                rightDown = false;
            }
            else if (rightD) // right is pressed left is not
            {
                leftDownFirst = false;
                leftDown = false;
                rightDown = true;
            }
            else
            {
                leftDown = false;
                rightDown = false;
            }

            if (upD && downD)
            {
                upDown = upDownFirst;
                downDown = !upDownFirst;
            }
            else if (upD) //up is pressed down is not
            {
                upDownFirst = true;
                upDown = true;
                downDown = false;
            }
            else if (downD) //down is pressed, up is not
            {
                upDownFirst = false;
                upDown = false;
                downDown = true;
            }
            else
            {
                upDown = false;
                downDown = false;
            }
        }
    }
}