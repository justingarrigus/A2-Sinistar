using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Sinistar.Input
{

    public enum InputDeviceType
    {
        Keyboard,
        Mouse,
        Gamepad,
        Joystick,
        DPad
    }

    public enum GamepadCode
    {
        None,
        GamepadX, GamepadA, GamepadB, GamepadY,
        GamepadRB, GamepadLB, GamepadRT, GamepadLT,
        GamepadStart, GamepadBack, GamepadBigButton,
        DPadL, DPadR, DPadU, DPadD,
        JoysticLeft, JoystickRight
    }
    public enum MouseCode
    {
        None,
        MouseLeftBtn, MouseRightBtn, MouseMiddleBtn,
        MouseScrollUp, MouseScrollDown
    }

    public class InputObject
    {
        public static Keys KeyboardMoveUp = Keys.W;
        public static Keys KeyboardMoveDown = Keys.S;
        public static Keys KeyboardMoveLeft = Keys.A;
        public static Keys KeyboardMoveRight = Keys.D;

        public static MouseCode MouseMoveUp = MouseCode.None;
        public static MouseCode MouseMoveDown = MouseCode.None;
        public static MouseCode MouseMoveLeft = MouseCode.None;
        public static MouseCode MouseMoveRight = MouseCode.None;

        
        public readonly InputDeviceType deviceType;
        public readonly GamepadCode gamepadCode;
        public readonly Keys keyboardCode;
        public readonly MouseCode mouseCode;

        private GamePadState gpdState;
        private MouseState mosState;

        public InputObject(InputDeviceType deviceType, GamePadState gpdState, MouseState mosState, Keys keyBtn, GamepadCode gpdBtn, MouseCode musBtn)
        {
            this.gamepadCode = gpdBtn;
            this.keyboardCode = keyBtn;
            this.mouseCode = musBtn;

            this.gpdState = gpdState;
            this.mosState = mosState;
        }

        /// <summary>
        ///     Attempts to find the position of the input given that the input can produce a position.
        /// </summary>
        /// <returns></returns>
        public Point getPosition()
        {
            if (deviceType == InputDeviceType.Mouse)
            {
                return new Point(mosState.X, mosState.Y);
            }
            return Point.Zero;
        }

        /// <summary>
        ///     Attempts to find the direction of the input given that the input can produce a direction.
        /// </summary>
        /// <returns></returns>
        public Vector2 getDirection()
        {
            Vector2 direction = new Vector2(0, 0);

            //Joysticks
            if (deviceType == InputDeviceType.Joystick)
            {
                if (gamepadCode == GamepadCode.JoysticLeft)
                {
                    Vector2 mv = gpdState.ThumbSticks.Left;
                    mv.Normalize();
                    return mv;
                }
                else
                {
                    Vector2 mv = gpdState.ThumbSticks.Right;
                    mv.Normalize();
                    return mv;
                }
            }
            //Dpad
            else if (deviceType == InputDeviceType.DPad)
            {
                switch (gamepadCode)
                {
                    case (GamepadCode.DPadU):
                        direction.Y += 1;
                        break;
                    case (GamepadCode.DPadD):
                        direction.Y -= 1;
                        break;
                    case (GamepadCode.DPadL):
                        direction.X -= 1;
                        break;
                    case (GamepadCode.DPadR):
                        direction.X += 1;
                        break;
                }
            }
            //Keyboard
            else if (deviceType == InputDeviceType.Keyboard)
            {
                switch (keyboardCode)
                {
                    case (Keys.W):
                        direction.Y += 1;
                        break;
                    case (Keys.S):
                        direction.Y -= 1;
                        break;
                    case (Keys.A):
                        direction.X -= 1;
                        break;
                    case (Keys.D):
                        direction.X += 1;
                        break;
                }
                
            }

            direction.Normalize();
            return direction;
        }
    }

}
