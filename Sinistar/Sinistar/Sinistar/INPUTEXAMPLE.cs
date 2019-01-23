using Microsoft.Xna.Framework;
using Sinistar.Input;
using Sinistar.Input.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinistar
{
    public class INPUTEXAMPLE : GeneralInputListener
    {

        public static Vector2 movementExample = new Vector2();

        public void InputBegan(InputObject input)
        {
            //Movement vector example
            Vector2 inputDir = input.getDirection();
            movementExample.X += inputDir.X;
            movementExample.Y += inputDir.Y;

            Console.WriteLine(movementExample);
        }

        public void InputEnded(InputObject input)
        {
            //Movement vector example
            Vector2 inputDir = input.getDirection();
            movementExample.X -= inputDir.X;
            movementExample.Y -= inputDir.Y;

            Console.WriteLine(movementExample);
        }


        public void GamepadInputBegan(InputObject input) { }

        public void GamepadInputEnded(InputObject input) { }


        public void KeyboardInputBegan(InputObject input) { } 

        public void KeyboardInputEnded(InputObject input) { }

        public void MouseInputBegan(InputObject input) { }

        public void MouseInputEnded(InputObject input) { }

    }
}
